/*
 * exercise8.c
 *
 *  Created on: Oct 15, 2023
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


void exercise8(void)
{
    int i=0;
    int j;
    unsigned int voltage_NTC=0;
    double average=0;
    double sum=0.0;

    WDTCTL = WDTPW + WDTHOLD;                                   // Stop WDT

    exercise8_setup();
    ADC10MCTL0 |= ADC10INCH_4;
    ADC10CTL0 |=ADC10ENC;                                       //ENABLE ADC



     ADC10CTL0 |=ADC10SC;                                        //Start conversion
     while(!(ADC10IFG & ADC10IFG0));                             // Wait until conversion complete
     voltage_NTC=ADC10MEM0>>2;                                       // Store value of ADC10MEM0


     while (!(UCA0IFG & UCTXIFG));                           // Wait until the previous Tx is finished
     UCA0TXBUF = voltage_NTC;                                // Send 255

     while(i<AVERAGE_OVER)
     {
         sum+=voltage_NTC;
         i++;
    break;

        }

    if(i>AVERAGE_OVER-1)
    {
        average=sum/AVERAGE_OVER;
        tempToLED(average);
        sum=0.0;
        i=0;
    }

    for(j=0;j<3000;j++)
    {
        _NOP();
    }



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
