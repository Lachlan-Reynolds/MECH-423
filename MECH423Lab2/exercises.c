/*
 * exercises.c
 *
 *  Created on: Sep 29, 2023
 *      Author: Lachlan Reynolds
 */


#include "exercises.h"
#define TRANSITION_1 39
#define TRANSITION_2 40
#define TRANSITION_3 41
#define TRANSITION_4 41.5
#define TRANSITION_5 42
#define TRANSITION_6 42.5
#define TRANSITION_7 43
#define AVERAGE_OVER 10


void exercise1 (void)
{
    WDTCTL = WDTPW + WDTHOLD;                 // Stop WDT

        CSCTL0=CSKEY;           //Password for setting the MCLK
        CSCTL1|=DCOFSEL_3;      //configure clock as 8MHz
        CSCTL2|=SELS__DCOCLK;   //configure the SMCLK to run off the DCO
        CSCTL3|=DIVS__32;       //Divide by 32
        P3DIR|=BIT4;            //Configure P3.4 as an output
        P3SEL1|=BIT4;           //Select tertiary mode
        P3SEL0|=BIT4;           //Select tertiary mode


         while(1)               //inf loop
         {
         }
}

void exercise2(void)
{
    int i;
        PJDIR|=BIT0 +BIT1+BIT2+BIT3;                 //Set PJ.0, PJ.1, PJ.2, PJ.3 as output
        P3DIR|=BIT4+BIT5+BIT6+BIT7;                  //Set P3.4, P3.5, P3.6, P3.7 as output

        PJOUT &= ~(BIT0 +BIT1+BIT2+BIT3);
        P3OUT &= ~(BIT4+BIT5+BIT6+BIT7);


        while(1)
        {
            PJOUT ^=BIT0+BIT1;            //toggle LED1 and 2
            P3OUT^=BIT4+BIT7;            //Toggle LED 4 and 8

            for(i=0;i<20000;i++)
            {
                _NOP();
            }

        }
}

void exercise3(void)
{

    PJDIR |=BIT0;


        P4DIR &= ~BIT0;                  //Enable P4.0 as input
        P4OUT |=BIT0;                    //Enable Pullup
        P4REN |=BIT0;

        P4IE |=BIT0;                     //Enable interrupt
        P4IES &= ~BIT0;                  //Trigger on rising edge
        P4IFG &= ~BIT0;                //Start as no interrupt pending

        __bis_SR_register(GIE);

        while(1)
        {

        }
}


void exercise4 (void)
{
    int i;
       WDTCTL = WDTPW | WDTHOLD; // stop watchdog timer

       PJDIR |=BIT0;                                               //Set J.0 to power LED1

       // Configure clocks
       CSCTL0 = 0xA500;                                            // Write password to modify CS registers
       CSCTL1 = DCOFSEL0 + DCOFSEL1;                               // DCO = 8 MHz
       CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1;     // MCLK = DCO, ACLK =DCO, SMCLK = DCO

       // Configure ports for UART
       P2SEL0 &= ~(BIT0 + BIT1);
       P2SEL1 |= BIT0 + BIT1;

       UCA0CTLW0 |= UCSWRST;                                       // Put the UART in software reset
       UCA0CTLW0 |= UCSSEL0;                                       // Run the UART using ACLK
       UCA0MCTLW = UCOS16 + UCBRF0 + 0x4900;                       // Baud rate = 9600 from an 8 MHz clock
       UCA0BRW = 52;
       UCA0CTLW0 &= ~UCSWRST;                                      // release UART for operation
       UCA0IE |= UCRXIE;                                           // Enable UART Rx interrupt

       // Global interrupt enable
       _EINT();

       while (1)
       {
           // Periodically transmit an "A" character

           while (!(UCA0IFG & UCTXIFG));
           UCA0TXBUF = 'A';
           for (i=0;i<20000;i++)
               _NOP();

       }


}

void exercise5(int period)
{

    

}


void exercise7_setup(void)
{
    // Configure ADC
        P2DIR|=BIT7;                                                // Configure 2.7 to output
        P2OUT |=BIT7;                                               // Enable HI to power Accelerometer

        P3DIR &= ~ (BIT0 +BIT1 +BIT2);                              // Configure P3.0, P3.1, P3.2 as inputs

        ADC10CTL0 |= ADC10SHT_2 + ADC10ON;                          // Sample and hold for 16 ADC clock cycles, and turn ADC on
        ADC10CTL1 |= ADC10SHP;                                      // ADCCLK = MODOSC; sampling timer

        ADC10CTL0 &= ~ADC10ENC;                                     // SW Disable ADC
        ADC10MCTL0 &= ~(ADC10SREF_0 + ADC10SREF_1);                 //Set Vref+ to VCC (3.3V), and Vref- to GND (0V)

        ADC10CTL1 &= ~(ADC10CONSEQ0 +ADC10CONSEQ1);                 // Configure single channel single sampling
        ADC10CTL0 &=  ~ADC10MSC;                                    // Configure single sampling

        ADC10CTL2 |=ADC10RES;                                       // Rest resolution bit as 10 bits
        // Finish Configuring ADC

        // Configure clock
        CSCTL0 = CSKEY;                                              // Enter key to access clocks
        CSCTL1 |= DCOFSEL_3;                                        // Set max. DCO setting =8MHz
        CSCTL2 = SELA_3 + SELS_3 + SELM_3;                          // set ACLK = SMCLK =MCLK = DCO
        CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;                          // ALCK div to 1/8, SMCLK to 1/8, MCLK to 1/8
        CSCTL0_H=0;                                                 // Disable CS register edit

        // Convigure timer to run at 25hz
        TB1CCR0 = 1000000/25;                                  // PWM Period =SMCLK/25
        TB1CTL |= TBSSEL__SMCLK | MC__UP | TBCLR;                           // SMCLK, up mode, clear TAR
        TB1CCTL0|= CCIE;                                            // Enable timer b interrupts
        // Finishing Configuring Timer

        // Setup UART
        P2SEL0 &= ~(BIT0 + BIT1);
        P2SEL1 |= BIT0 + BIT1;

        UCA0CTLW0 |= UCSWRST;                                       // Put the UART in software reset
        UCA0CTLW0 |= UCSSEL__SMCLK;                                       // Run the UART using ACLK
        UCA0MCTLW = UCOS16 + UCBRF_8 + 0x2000;                       // Baud rate = 9600 from an 1 MHz clock
        UCA0BRW = 6;
        UCA0CTLW0 &= ~UCSWRST;                                      // release UART for operation
        // Finish Configuring UART

        _EINT();
}
/*
void exercise7_while(void)
{
    switch(state)
            {
            case 0:                                                         // X acceleration
                ADC10MCTL0 |= ADC10INCH_12;
                ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC
                ADC10CTL0 |=ADC10SC;                                        //Start conversion
                while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
                accel_x=ADC10MEM0>>2;                                       // Store value of ADC10MEM0 in eacaccel_raw
                state=1;
                _NOP();
                break;
            case 1:                                                         // Y acceleration
                ADC10MCTL0 |= ADC10INCH_13;
                ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC
                ADC10CTL0 |=ADC10SC;                                        //Start conversion

                while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
                accel_y=ADC10MEM0>>2;                                       // Store value of ADC10MEM0 in accel_raw
                state=2;

                _NOP();
                break;
            case 2:
                ADC10MCTL0 |= ADC10INCH_14;
                ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC
                ADC10CTL0 |=ADC10SC;                                        //Start conversion
                while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
                accel_z=ADC10MEM0>>2;                                       // Store value of ADC10MEM0 in accel_raw
                state=0;
                _NOP();
                break;

                   }

            _NOP();
}


void exercise8_setup(void)
{
    // Configure ADC
    P2DIR|=BIT7;                                                // Configure 2.7 to output
    P2OUT |=BIT7;                                               // Enable HI to power NTC

    P1DIR &= ~ BIT4;                                            // Configure P1.4 as inputs
    P1SEL0 |= BIT4;                                             // Configure as teriary function
    P1SEL1 |= BIT4;

    PJDIR |= BIT0 + BIT1 + BIT2 +BIT3;
    P3DIR |= BIT4 + BIT5 + BIT6 + BIT7;

    PJOUT &=  ~(BIT0+ BIT1 + BIT2+BIT3);
    P3OUT &= ~(BIT4+BIT5+BIT6+BIT7);

    ADC10CTL0 |= ADC10SHT_2 + ADC10ON;                          // Sample and hold for 16 ADC clock cycles, and turn ADC on
    ADC10CTL1 |= ADC10SHP;                                      // ADCCLK = MODOSC; sampling timer

    ADC10CTL0 &= ~ADC10ENC;                                     // SW Disable ADC
    ADC10MCTL0 &= ~(ADC10SREF_0 + ADC10SREF_1);                 //Set Vref+ to VCC (3.3V), and Vref- to GND (0V)

    ADC10CTL1 &= ~(ADC10CONSEQ0 +ADC10CONSEQ1);                 // Configure single channel single sampling
    ADC10CTL0 &=  ~ADC10MSC;                                    // Configure single sampling

    ADC10CTL2 |=ADC10RES;                                       // Rest resolution bit as 10 bits
    // Finish Configuring ADC


    // Configure clock
    CSCTL0 = CSKEY;                                             // Enter key to access clocks
    CSCTL1 |= DCOFSEL_3;                                        // Set max. DCO setting =8MHz
    CSCTL2 = SELA_3 + SELS_3 + SELM_3;                          // set ACLK = SMCLK =MCLK = DCO
    CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;                          // ALCK div to 1/8, SMCLK to 1/8, MCLK to 1/8
    CSCTL0_H=0;                                                 // Disable CS register edit
    // Finish Configuring Clock

    // Setup UART
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;

    UCA0CTLW0 |= UCSWRST;                                       // Put the UART in software reset
    UCA0CTLW0 |= UCSSEL__SMCLK;                                 // Run the UART using ACLK
    UCA0MCTLW = UCOS16 + UCBRF_8 + 0x2000;                      // Baud rate = 9600 from an 1 MHz clock
    UCA0BRW = 6;                                                // Baud rate = 9600 from an 1 MHz clock
    UCA0CTLW0 &= ~UCSWRST;                                      // release UART for operation
    // Finish Configuring UART

    _EINT();                                                    // Enable Global Interrupts
}

*/
//ISRs
//Exercise 3 ISR
/*
#pragma vector= PORT4_VECTOR
__interrupt void button_interrupt(void)
{
    if(P4IFG & BIT0)
    {
        PJOUT ^= BIT0;

        P4IFG &= ~BIT0;
    }
}

//Exercise 4 ISR
#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte = 0;
    RxByte = UCA0RXBUF;                 // Get the new byte from the Rx buffer

    if(RxByte=='j')
        PJOUT|=BIT0;

    if(RxByte=='k')
        PJOUT &= ~BIT0;
    while (!(UCA0IFG & UCTXIFG));       // Wait until the previous Tx is finished
    UCA0TXBUF = RxByte;                 // Echo back the received byte

    while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
    UCA0TXBUF = RxByte + 1;                 // Echo back the received byte + 1
}

//Exercise 7 ISR

#pragma vector = TIMER1_B0_VECTOR
__interrupt void TIMER1_B0_ISR(void)
{


        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = 255;                        // Send 255

        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = accel_x;                    // Send ax

        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = accel_y;                    // send ay

        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = accel_z;                    // send az

}*/
void tempToLED(double moving_average)
{
    if(moving_average<TRANSITION_1)
    {
        PJOUT |= BIT0+ BIT1 + BIT2+BIT3;
        P3OUT |= BIT4+BIT5+BIT6+BIT7;

    }
    else if(moving_average> TRANSITION_1 && moving_average<TRANSITION_2)
    {
        PJOUT |= BIT0+ BIT1 + BIT2+BIT3;
        P3OUT |= BIT4+BIT5+BIT6;
        P3OUT &= ~BIT7;
    }

    else if(moving_average>TRANSITION_2 && moving_average<TRANSITION_3)
    {
        PJOUT |= BIT0+ BIT1 + BIT2+BIT3;
        P3OUT |= BIT4+BIT5;
        P3OUT &= ~(BIT6+BIT7);

    }
    else if(moving_average>TRANSITION_3 && moving_average<TRANSITION_4)
    {
        PJOUT |= BIT0+ BIT1 + BIT2+BIT3;
        P3OUT |= BIT4;
        P3OUT &= ~(BIT5+BIT6+BIT7);

    }
    else if(moving_average>TRANSITION_4 && moving_average<TRANSITION_5)
    {
        PJOUT |= BIT0+ BIT1 + BIT2+BIT3;
        P3OUT &= ~(BIT4+BIT5+BIT6+BIT7);
    }
    else if(moving_average>TRANSITION_5 && moving_average<TRANSITION_6)
    {
        PJOUT |= BIT0+ BIT1 + BIT2;
        P3OUT &= ~(BIT4+BIT5+BIT6+BIT7);
        PJOUT &= ~BIT3;

    }
    else if(moving_average>TRANSITION_6 && moving_average<TRANSITION_7)
    {
        PJOUT |= BIT0+ BIT1;
        P3OUT &= ~(BIT4+BIT5+BIT6+BIT7);
        PJOUT &= ~(BIT2 +BIT3);
    }

    PJOUT |= BIT0 + BIT1;

}
