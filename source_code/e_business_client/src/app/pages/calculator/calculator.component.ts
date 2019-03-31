import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CoreService, KeyValuePair } from '../../shared/services';

@Component({
  templateUrl: 'Calculator.component.html'
})

export class CalculatorComponent {
  public currencyList: KeyValuePair[];
  public interestRateCalculationList: KeyValuePair[];
  public calculator: Calculator;
  public calculationList: Calculation[];

  constructor() {
    var date = new Date();

    console.log(date.getDate());
    this.calculator = new Calculator(0, 1, 0, 0, 0, new Date(), 1);

    this.currencyList = [
      new KeyValuePair(1, "Dollar ($)"),
      new KeyValuePair(2, "Euro (€)")
    ];

    this.interestRateCalculationList = [
      new KeyValuePair(1, "Actual/360"),
      new KeyValuePair(2, "30/360")
    ];

    this.calculationList = [
      new Calculation(1, 30000, 532, 210, 322, 29678),
      new Calculation(2, 29678, 532, 207.75, 324.25, 29353.75),
      new Calculation(3, 29353.75, 532, 205.48, 326.52, 29027.23),
      new Calculation(4, 29027.23, 532, 203.19, 328.81, 28698.42),
      new Calculation(5, 28698.42, 532, 200.89, 331.11, 28367.31),
    ];
  }

  calculateClick() {    
    console.log("calculateClick");
   }
   
}

export class Calculator {
  constructor(
    public id: number,
    public currency: number,
    public loanAmount: number,
    public interestRate: number,
    public months: number,
    public loanStartDate: Date,
    public interestRateCalculation: number,

  ) { }
}

export class Calculation {
  constructor(
    public month: number,
    public startingBalance: number,
    public repayment: number,
    public interestPaid: number,
    public principalPaid: number,
    public newBalance: number,

  ) { }
}
