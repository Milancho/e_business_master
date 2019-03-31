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
  // public message: string;
  public customer: Customer;
  public customers: Customer[];
  public myHttpClient: HttpClient;
  public isLoading = false;
  
  constructor(http: HttpClient, private coreService: CoreService) {
    console.log("DM");

    this.myHttpClient = http;    
    this.customer = new Customer(0,"", 0, "", 0, "", 0, "", new Date(), 0, "", "", "");
    http.get<Customer[]>(coreService.baseUrl + 'api/dm').subscribe(result => {
      console.log(result);
      this.customers = result;
    }, error => console.error(error));

    http.get<any>(coreService.baseUrl + 'api/enum').subscribe(result => {
      this.educationList = result.education;
      this.genderList = result.gender;
      this.maritalStatusList = result.maritalStatus;            
    }, error => console.error(error));
  }

  predictionClick() {    
    this.isLoading = true;
    this.customer.message = "Loading...";   
    this.myHttpClient.post<CustomerPrediction>(this.coreService.baseUrl + 'api/dm', this.customer).subscribe(result => {
      var description = (result.isGoodClient) ? "Добар" : "Лош";
      this.customer.message =
        this.customer.name + " е '" + description + "' клиент !!! Моделот има точност од: " + Math.round(result.score * 100) + "%";
      this.isLoading = false;
    }, error => console.error(error));
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
    public birthDate: Date, 
    public аge: number,
    public label: string,
    public labelName: string,
    public message: string
  ) { }
}

export class CustomerPrediction {
  constructor(
    public isGoodClient: boolean,
    public score: number
  ) { }
}
