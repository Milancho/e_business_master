import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CoreService } from '../../shared/services';

@Component({
  templateUrl: 'data-mining.component.html'
})

export class DataMiningComponent {  
  public educationList: any[];
  public genderList: any[];
  public maritalStatusList: any[];
  public message: string;
  public customer: Customer;
  public customers: Customer[];
  public days: number[] = [31];
  public monthList: Array<KeyValuePair>;
  public years: Array<number>;
  public myHttpClient: HttpClient;
  public myBaseUrl: string;
  public isLoading = false;

  constructor(http: HttpClient, coreService: CoreService) {
    console.log("DM");

     this.myHttpClient = http;
    
    this.customer = new Customer(0,"", 0, "", 0, "", 0, "", 10, 12, 1986, 0, "", "");
    this.years = new Array<number>();

    //days
    for (var m = 0; m <= 31; m++) {
      this.days[m] = m;
    }
    //months
    this.monthList = new Array<KeyValuePair>(new KeyValuePair(1, "Јануари"), new KeyValuePair(2, "Февруари"), new KeyValuePair(3, "Март"), new KeyValuePair(4, "Април"), new KeyValuePair(5, "Мај"), new KeyValuePair(6, "Јуни"), new KeyValuePair(7, "Јули"), new KeyValuePair(8, "Август"), new KeyValuePair(9, "Септември"), new KeyValuePair(10, "Октомври"), new KeyValuePair(11, "Ноември "), new KeyValuePair(12, "Декември"));
    //year
    for (var y = 1960; y <= 2015; y++) {
      this.years.push(y);
    }

    http.get<Customer[]>(coreService.baseUrl + 'api/dm').subscribe(result => {
      console.log(result);
      this.customers = result;
    }, error => console.error(error));

    // http.get<any[]>(baseUrl + 'api/SampleData/GetEducations').subscribe(result => {
    //   this.educationList = result;
    // }, error => console.error(error));

    // http.get<any[]>(baseUrl + 'api/SampleData/GetGender').subscribe(result => {
    //   this.genderList = result;
    // }, error => console.error(error));

    // http.get<any[]>(baseUrl + 'api/SampleData/GetMaritalStatus').subscribe(result => {
    //   this.maritalStatusList = result;
    // }, error => console.error(error));

  }
}

export class Customer {
  constructor(
    public id: number,
    public name: string,
    public educationId: number,
    public educationName: string,
    public gender: number,
    public genderName: string,
    public maritalStatus: number,
    public maritalStatusName: string,
    public day: number,
    public month: number,
    public year: number,
    public аge: number,
    public label: string,
    public labelName: string
  ) { }
}

export class CustomerPrediction {
  constructor(
    public isGoodClient: boolean,
    public score: number
  ) { }
}

export class KeyValuePair {
  constructor(
    public key: number,
    public value: string,
  ) { }
}