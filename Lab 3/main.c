#include <msp430.h>

#define PWM_PERIOD 2000 // PWM period in clock cycles
#define PWM_DUTY_CYCLE 1000 // PWM duty cycle (50%)


#define START_BYTE 255
const float MAX_DUTY= 65535.0;
const unsigned int TIMER_B1_MAX_COUNT=2000;

int i = 0;

// UART

void UARTTx(unsigned char Byte){
    // Wait for the UART transmit buffer to be ready
    while (!(UCA1IFG & UCTXIFG));

    // Transmit the byte
    UCA1TXBUF = Byte;
}

void UARTMessage(const char* message) {
    while (*message) {
        UARTTx(*message);
        message++;
    }
}

void UART_setup(void) {
    // Configure UART pins
    P2SEL0 &= ~(BIT5 + BIT6);
    P2SEL1 |= BIT5 + BIT6;

    // Put the UART in software reset
    UCA1CTLW0 |= UCSWRST;

    // Run the UART using ACLK
    UCA1CTLW0 |= UCSSEL__ACLK;

    // Configure Baud Rate
    UCA1MCTLW = UCOS16 + UCBRF0 + 0x4900; // Baud rate = 9600 from an 8 MHz clock
    UCA1BRW = 52;

    // Release UART for operation
    UCA1CTLW0 &= ~BIT0;

    UCA1IE |= UCRXIE; // Enable UART Rx interrupt

    UCA1IFG &= ~BIT0;        //disable rx interrupt flag
}

void setup_ACLK_1MHz(void)
{
    CSCTL0 = CSKEY;                                             // Enter key to access clocks
    CSCTL1 |= DCOFSEL_3;                                        // Set max. DCO setting =8MHz
    CSCTL2 = SELA_3 + SELS_3 + SELM_3;                          // set ACLK = SMCLK =MCLK = DCO
    CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;                          // ALCK div to 1/8, SMCLK to 1/8, MCLK to 1/8
    CSCTL0_H=0;                                                 // Disable CS register edit
}

void setup_timer_ACLK(void)
{
    // Convigure timer to ru
    TB2CCR0 = PWM_PERIOD;                // PWM Period
    TB2CCTL1 = OUTMOD_7;                        // CCR1 reset/set
    TB2CTL |= TBSSEL__ACLK | MC__UP | TBCLR;                           // ACLK, up mode, clear TAR
    TB2CCR1 = PWM_DUTY_CYCLE;
}

void henry_clock_setup(void) {
    // Clock Password
    CSCTL0 = CSKEY;

    // Configure DCO to run at 8 MHz
    CSCTL1 |= DCOFSEL_3;

    // Setup SMCLK and ACLK and MCLK to run on DCO
    CSCTL2 |= SELS__DCOCLK | SELA__DCOCLK | SELM__DCOCLK;
}


void henry_setup_timer_B2(void){


    // Configure Timer B2.1 (TB2CCR1)
    TB2CCTL1 &= ~CAP;  // Capture mode off
    TB2CCTL1 |= OUTMOD_7; // Reset-Set mode (generates square wave)
    TB2CCTL1 &= ~CCIE; // Disable capture/compare interrupt

    TB2CTL |= TBSSEL__ACLK; // Select ACLK as the source
    TB2CTL &= ~TBCLR; // Clear the timer

    // Set Timer B2.1 (TB2CCR1) values
    TB2CCR0 = 2000;   // Set the period
    TB2CCR1 = 1000;   // Set the duty cycle

    // Configure Timer B1 for up mode
    TB2CTL |= MC_1;  // Up mode
}

void timer_output(void)
{
    // TB2.1 (P2.1)
     P2SEL0 |= BIT1; // Set P2.1 to be TB2.1
     P2SEL1 &= ~BIT1;
     P2DIR |= BIT1; // Set P2.1 as an output
}

void direction_set(int direction)
{
    // Configure pins for motor control (direction and enable)
    P3DIR |= BIT6; // AIN1 control pin
    P3DIR |= BIT7; // AIN2 control pin

    if(direction== 1)//CCW
    {
        P3OUT &= ~BIT6; // Set AIN1 to control motor direction
        P3OUT |= BIT7; // Set AIN2 to control motor direction
    }

    else if(direction==0)//CW
    {

        P3OUT |=BIT6; // Set AIN1 to control motor direction
        P3OUT &=  ~BIT7; // Set AIN2 to control motor direction
    }
}


void main(void) {
    WDTCTL = WDTPW | WDTHOLD; // Stop the watchdog timer

    PJDIR |=BIT0;
    PJOUT &= ~BIT0;

    henry_clock_setup();

    henry_setup_timer_B2();
    timer_output();
    direction_set(1);

    UART_setup();

    _EINT();


    while(1){
        //UARTMessage("Send Constant");
        //__delay_cycles(50000);  // Delay
    }
}


// State machine for message parsing
volatile unsigned char state = 0;
volatile unsigned char commandByte, dataByte1, dataByte2, escapeByte;

#pragma vector=USCI_A1_VECTOR
__interrupt void USCI_A1_ISR(void) {

    //UCA1IE &=  ~UCRXIE;                             // Disable RX interrupt
    //_DINT();

    if (UCA1IFG & UCRXIFG) {                //change these conditions, either logic condition is incorrect or bits are not being set properly, and if the second is true then why???
        PJOUT ^=BIT0; // Toggle LED

        unsigned char receivedByte = UCA1RXBUF;
        switch (state) {
            case 0: // Start byte
                if (receivedByte == START_BYTE) {
                    state = 1;
                }
                break;

            case 1: // Command byte
                commandByte = receivedByte;
                if(commandByte == 0){ //CW
                    direction_set(1);
                }
                else{ // CCW
                    direction_set(0);
                }

                state = 2;
                break;

            case 2: // Data byte #1
                dataByte1 = (receivedByte > 255) ? 255 : receivedByte;
                state = 3;
                break;

            case 3: // Data byte #2
                dataByte2 = (receivedByte > 255) ? 255 : receivedByte;
                state = 4;
                break;

            case 4: // Escape byte
                escapeByte = receivedByte;

                // Process the message with commandByte, dataByte1, dataByte2, and escapeByte
                // Ensure they are within the desired range (0 to 255)

                // Handle databyte1
                if (escapeByte & 0x01) {
                    dataByte1 = 255;
                }

                //Handle databyte2
                if (escapeByte & 0x02) {
                    dataByte2 = 0;
                }


                //Combine into 16-bit number
                unsigned int combinedData = (dataByte1 << 8) | dataByte2;

                // Extracting frequency and duty cycle information from the 16-bit data
                unsigned int dutyCycle = combinedData * (TIMER_B1_MAX_COUNT / MAX_DUTY);        // Bits 0-7

                TB2CCR1 = dutyCycle; // Set duty cycle (TB1CCR1)

                state = 0; // Reset state for the next message
                break;
        }
    }
    UCA1IFG &= ~BIT0;                   //Clear rx interrupt flag
}

