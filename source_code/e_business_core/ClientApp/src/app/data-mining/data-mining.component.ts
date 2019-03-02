import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-data-mining',
  templateUrl: './data-mining.component.html',
  styleUrls: ['./data-mining.component.css'],
})


export class DataMiningComponent {
  public educationList: any[];
  public genderList: any[];
  public maritalStatusList: any[];
  public message: string;
  public model: CustomerModel;
  public customers: CustomerModel[];
  public days: number[] = [31];
  public monthList: Array<KeyValue>;
  public years: Array<number>;
  public myHttpClient: HttpClient;
  public myBaseUrl: string;
  public isLoading = false;
  public object: object;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
    this.object = { foo: 'bar', baz: 'qux', nested: { xyz: 3, numbers: [1, 2, 3, 4, 5] } };
    
    this.myHttpClient = http;
    this.myBaseUrl = baseUrl;

    this.model = new CustomerModel("", 0, "", 0, "", 0, "", 10, 12, 1986, 0, "", "");
    this.years = new Array<number>();

    //days
    for (var m = 0; m <= 31; m++) {
      this.days[m] = m;
    }
    //months
    this.monthList = new Array<KeyValue>(new KeyValue(1, "Јануари"), new KeyValue(2, "Февруари"), new KeyValue(3, "Март"), new KeyValue(4, "Април"), new KeyValue(5, "Мај"), new KeyValue(6, "Јуни"), new KeyValue(7, "Јули"), new KeyValue(8, "Август"), new KeyValue(9, "Септември"), new KeyValue(10, "Октомври"), new KeyValue(11, "Ноември "), new KeyValue(12, "Декември"));
    //year
    for (var y = 1960; y <= 2015; y++) {
      this.years.push(y);
    }

    http.get<CustomerModel[]>(baseUrl + 'api/dm').subscribe(result => {
      console.log(result);
      this.customers = result;
    }, error => console.error(error));

    http.get<any[]>(baseUrl + 'api/SampleData/GetEducations').subscribe(result => {
      this.educationList = result;
    }, error => console.error(error));

    http.get<any[]>(baseUrl + 'api/SampleData/GetGender').subscribe(result => {
      this.genderList = result;
    }, error => console.error(error));

    http.get<any[]>(baseUrl + 'api/SampleData/GetMaritalStatus').subscribe(result => {
      this.maritalStatusList = result;
    }, error => console.error(error));

  }

  public predictionClick() {
    this.isLoading = true;
    this.message = "";

    this.myHttpClient.post<CustomerPrediction>(this.myBaseUrl + 'api/dm', this.model).subscribe(result => {
      var description = (result.isGoodClient) ? "Добар" : "Лош";
      this.message =
        this.model.name + " е '" + description + "' клиент !!! Моделот има точнот од: " + Math.round(result.score * 100) + "%";
      this.isLoading = false;
    }, error => console.error(error));

  }
}


export class CustomerModel {
  constructor(
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

export class NgbdDatepickerPopup {
  model;
}

export class KeyValue {
  constructor(
    public key: number,
    public value: string,
  ) { }
}

//public class Customer {
//  public string Name;
//  /// <summary>
//  /// ElementarySchool = 6, HighSchool = 7, HigherSchool = 8, College = 9 
//  /// </summary>
//  public float EducationId;
//  /// <summary>
//  ///  Male = 1, Female = 2, 
//  /// </summary>
//  public float Gender;
//  /// <summary>
//  /// Single = 1, Married = 2, Widower = 3, Divorced = 4,
//  /// </summary>
//  public float MaritalStatus;
//  public float Age;
//  [JsonIgnore]
//  public string Label;
//}
