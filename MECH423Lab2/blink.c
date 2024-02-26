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
#include "exercises.h"




volatile unsigned char accel_x =0;
volatile unsigned char accel_y =0;
volatile unsigned char accel_z =0;
volatile unsigned int state=0;

#define TIMER_PERIOD 1000000




int main(void)
{
    WDTCTL = WDTPW | WDTHOLD; // stop watchdog timer


    // Configure ADC
        P2DIR|=BIT7;                                                // Configure 2.7 to output
        P2OUT |=BIT7;                                               // Enable HI to power Accelerometer

        P3DIR &= ~ (BIT0 +BIT1 +BIT2);                              // Configure P3.0, P3.1, P3.2 as inputs
        P3SEL0 |= BIT0+BIT1+BIT2;
        P3SEL1 |=BIT0 +BIT1 +BIT2;


        ADC10CTL0 |= ADC10ON;                          // Sample and hold for 16 ADC clock cycles, and turn ADC on
        ADC10CTL1 |= ADC10SHP + ADC10SSEL_1;                                      // ADCCLK = MODOSC; sampling timer

        ADC10CTL0 &= ~ADC10ENC;                                     // SW Disable ADC
        ADC10MCTL0 &= ~(ADC10SREF_0 + ADC10SREF_1);                 //Set Vref+ to VCC (3.3V), and Vref- to GND (0V)

        ADC10CTL1 |= ADC10CONSEQ0;                 // Configure single channel single sampling
        //ADC10CTL0 &=  ~ADC10MSC;                                    // Configure single sampling

        ADC10CTL2 |=ADC10RES;                                       // Rest resolution bit as 10 bits
        // Finish Configuring ADC

        // Configure clock
        CSCTL0 = CSKEY;                                              // Enter key to access clocks
        CSCTL1 |= DCOFSEL_3;                                        // Set max. DCO setting =8MHz
        CSCTL2 = SELA_3 + SELS_3 + SELM_3;                          // set ACLK = SMCLK =MCLK = DCO
        CSCTL3 = DIVA_3 + DIVS_3 + DIVM_3;                          // ALCK div to 1/8, SMCLK to 1/8, MCLK to 1/8
        CSCTL0_H=0;                                                 // Disable CS register edit

        // Configure timer to run at 25hz
        P3DIR |= BIT4;
        P3SEL0 |=BIT4;
        P3SEL1 |=BIT4;

        TB1CCR0 = TIMER_PERIOD/25;                                  // PWM Period =SMCLK/25
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

    while(1)
    {

        _NOP();
    }

}



#pragma vector = TIMER1_B0_VECTOR
__interrupt void TIMER1_B0_ISR(void)
{


        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = 255;                        // Send 255

        ADC10CTL0 &= ~ADC10ENC;                                       //ENABLE ADC
        ADC10MCTL0 = ADC10INCH_12;
        ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC
        ADC10CTL0 |=ADC10SC;                                        //Start conversion

        while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
        accel_x=ADC10MEM0>>2;                                       // Store value of ADC10MEM0 in eacaccel_raw

        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = accel_x;                    // Send ax

        ADC10CTL0 &= ~ADC10ENC;                                       //ENABLE ADC
        ADC10MCTL0 = ADC10INCH_13;
        ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC
        ADC10CTL0 |=ADC10SC;                                        //Start conversion

        while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
        accel_y=ADC10MEM0>>2;                                       // Store value of ADC10MEM0 in accel_raw

        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = accel_y;                    // send ay

        ADC10CTL0 &= ~ADC10ENC;                                       //ENABLE ADC
        ADC10MCTL0 = ADC10INCH_14;
        ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC
        ADC10CTL0 |=ADC10SC;                                        //Start conversion

        while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
        accel_z=ADC10MEM0>>2;                                       // Store value of ADC10MEM0 in accel_raw

        while (!(UCA0IFG & UCTXIFG));           // Wait until the previous Tx is finished
        UCA0TXBUF = accel_z;                    // send az

}




