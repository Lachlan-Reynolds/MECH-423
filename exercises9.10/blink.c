//***************************************************************************************
//  MSP430 Blink the LED Demo - Software Toggle P1.0
//
//  Description; Toggle P1.0 by xor'ing P1.0 inside of a software loop.
//  ACLK = n/a, MCLK = SMCLK = default DCO
//
//                MSP430x5xx
//             -----------------
//         /|\|              XIN|-
//          | |                 |
//          --|RST          XOUT|-
//            |                 |
//            |             P1.0|-->LED
//
//  Texas Instruments, Inc
//  July 2013
//***************************************************************************************

#include <msp430.h>
#include <stdio.h>
#include <stdio.h>


#define BUF_SIZE 51 // N elements of the circular buffer
#define ENTER 13
#define START_BYTE 255
#define COMMAND_BYTE_2 2
#define COMMAND_BYTE_3 3

#define ESCAPE_BYTE_0 0
#define ESCAPE_BYTE_1 1
#define ESCAPE_BYTE_2 2
#define ESCAPE_BYTE_3 3
#define PACKET_SIZE 5
//#define MAX_DUTY 65535.0
//define TIMER_B1_MAX_COUNT 1000

const float MAX_DUTY= 65535.0;
const float TIMER_B1_MAX_COUNT=1000;

volatile unsigned char buffer [BUF_SIZE];   // Note that N-1 is the actual capacity, see put function
volatile unsigned int writeIndx = 0;
volatile unsigned int readIndx  = 0;
volatile unsigned int state=0;
volatile unsigned int found_255=0;

volatile unsigned int command_byte=0;
volatile unsigned int data_byte_1=0;
volatile unsigned int data_byte_2=0;
volatile unsigned int escape_byte=0;

volatile float data_byte_all=0;

volatile unsigned int buffer_count=0;

volatile unsigned int duty_cycle;
// Transmit a character via UART
void UART_WriteChar(unsigned volatile char data) {
    while (!(UCA0IFG & UCTXIFG)); // Wait until the TX buffer is ready
    UCA0TXBUF = data; // Send data
}

// Transmit a string via UART
void UART_WriteString(unsigned volatile char* str) {
    while (*str)
    {
        UART_WriteChar(*str);
        str++;
    }
}

void UART_WriteBuf(void)
{
    unsigned int idx=readIndx;
    while(idx% BUF_SIZE !=writeIndx){
        UART_WriteChar(buffer[idx]);
        idx++;
    }
}

int put (volatile unsigned char item)
{
  if ((writeIndx + 1) % BUF_SIZE == readIndx)
  {
     UART_WriteString("\nBuffer overflow. Value not written \n");
     // buffer is full, avoid overflow
     return 0;
  }
  buffer[writeIndx] = item;
  writeIndx = (writeIndx + 1) % BUF_SIZE;
  buffer_count++;
  return 1;
}


int get (volatile unsigned char * value)
{
  if (readIndx == writeIndx)
  {
     UART_WriteString("\nBuffer empty. Value not returned \n");
     // buffer is empty
     return 0;
  }

  *value = buffer[readIndx];
  readIndx = (readIndx + 1) % BUF_SIZE;
  buffer_count--;
  return 1;
}

void setup_ACLK_1MHz(void)
{
    CSCTL0 = CSKEY;                                             // Enter key to access clocks
    CSCTL1 |= DCOFSEL_3;                                        // Set max. DCO setting =8MHz
    CSCTL2 = SELA_3 + SELS_3 + SELM_3;                          // set ACLK = SMCLK =MCLK = DCO
    CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;                          // ALCK div to 1/8, SMCLK to 1/8, MCLK to 1/8
    CSCTL0_H=0;                                                 // Disable CS register edit
}


void setup_UART_9600(void)
{
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;

    UCA0CTLW0 |= UCSWRST;                                       // Put the UART in software reset
    UCA0CTLW0 |= UCSSEL__SMCLK;                                 // Run the UART using ACLK
    UCA0MCTLW = UCOS16 + UCBRF_8 + 0x2000;                      // Baud rate = 9600 from an 1 MHz clock
    UCA0BRW = 6;                                                // Baud rate = 9600 from an 1 MHz clock
    UCA0CTLW0 &= ~UCSWRST;                                      // release UART for operation
    UCA0IE |= UCRXIE;                                           // Enable recieved interrupt
}


void processPacket(void)
{

    volatile unsigned int i=0;
    volatile unsigned int index_found;
    volatile unsigned char start_byte=0;

    //get(&start_byte)
    while(buffer_count>=PACKET_SIZE && start_byte!=255)
    {

        get(&start_byte);

    }
    if(start_byte==255)
    {
        get(&command_byte);
        get(&data_byte_1);
        get(&data_byte_2);
        get(&escape_byte);
    }
    else
    {
        return;
    }


    //Check command byte
    if(command_byte==COMMAND_BYTE_2)
    {
        PJOUT|=BIT0;
    }

    if(command_byte==COMMAND_BYTE_3)
    {
        PJOUT &= ~BIT0;

    }

    if(escape_byte & BIT0)
    {
        data_byte_1=255;
    }

    if(escape_byte & BIT1)
    {
        data_byte_2=255;
    }

    data_byte_all = data_byte_1 << 8 | data_byte_2;
-
    //unsigned int increment = TIMER_B1_MAX_COUNT / MAX_DUTY;
    duty_cycle = data_byte_all * (TIMER_B1_MAX_COUNT / MAX_DUTY);

    TB1CCR1 = (int)duty_cycle;
}

void setup_timer_ACLK(void)
{
    // Convigure timer to ru
    TB1CCR0 = TIMER_B1_MAX_COUNT;                // PWM Period
    TB1CCTL1 = OUTMOD_7;                        // CCR1 reset/set
    TB1CTL |= TBSSEL__ACLK | MC__UP | TBCLR;                           // SMCLK, up mode, clear TAR
}

void main(void) {
    WDTCTL = WDTPW | WDTHOLD;               // Stop watchdog timer

    PJDIR|=BIT0+BIT1;
    PJOUT&= ~(BIT0+BIT1);

    P3DIR |=BIT4;
    P3SEL0 |=BIT4;

    setup_ACLK_1MHz();
    setup_UART_9600();
    setup_timer_ACLK();

    _EINT();

    while(1)
    {
        processPacket();

    }
}
/*
//Exercise 9 ISR
#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned volatile char RxByte = 0;
    RxByte = UCA0RXBUF;                 // Get the new byte from the Rx buffer
    unsigned volatile char retVal=0;


    if(RxByte==ENTER)
    {

        get(&retVal);
        while(!(UCA0IFG & UCTXIFG));
        UCA0TXBUF=retVal;
    }
    else
    {
        put(RxByte);

    }
    //UART_WriteBuf();

}
*/

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned volatile char RxByte = 0;
    RxByte = UCA0RXBUF;                 // Get the new byte from the Rx buffer

    put(RxByte);
}
