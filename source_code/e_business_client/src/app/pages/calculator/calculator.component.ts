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

  constructor(private http: HttpClient, private coreService: CoreService) {
    var date = new Date();
    
    console.log(date.getDate());
    this.calculator = new Calculator(0, 2, 10000, 5.5, 12, new Date(), 1);

    this.currencyList = [
      new KeyValuePair(1, "Dollar ($)"),
      new KeyValuePair(2, "Euro (€)")
    ];

    this.interestRateCalculationList = [
      new KeyValuePair(1, "Actual/360"),
      new KeyValuePair(2, "30/360")
    ];
  }

   calculateClick() {    
    console.log("calculateClick");
    this.http.post<Calculation[]>(this.coreService.baseUrl + 'api/calculator/calculations', this.calculator).subscribe(result => {
      console.log(result);
      this.calculationList = result;
    }, error => console.error(error));
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
    public no: number,
    public date: Date,
    public startingBalance: number,
    public repayment: number,
    public interestPaid: number,
    public principalPaid: number,
    public newBalance: number,

  ) { }
}
