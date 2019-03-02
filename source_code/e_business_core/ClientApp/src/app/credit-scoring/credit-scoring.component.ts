import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-credit-scoring',
  templateUrl: './credit-scoring.component.html',
  styleUrls: ['./credit-scoring.component.css'],
})

export class CreditScoringComponent {
  public cardStatusList: CardStatus[];
  public personalDataList: Array<PersonalData>;
  public familyDataList: Array<FamilyData>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.personalDataList = new Array<PersonalData>();
    this.familyDataList = new Array<FamilyData>();

    http.get<PersonalData[]>(baseUrl + 'api/cs/personaldata').subscribe(result => {
      console.log(result);
      this.personalDataList = result;
    }, error => console.error(error));

    http.get<FamilyData[]>(baseUrl + 'api/cs/familydata').subscribe(result => {
      console.log(result);
      this.familyDataList = result;
    }, error => console.error(error));

    http.get<CardStatus[]>(baseUrl + 'api/cs/cardstatus').subscribe(result => {
      console.log(result);
      this.cardStatusList = result;
    }, error => console.error(error));
    
  }
}

export class CardStatus {
  constructor(
    public score: number,
    public decision: string
  ) {
  }
}

export class BaseData {
  public group: string;
  public weight: string;
  public score: string;
}

export class PersonalData extends BaseData {
  public education: string;
  public age: string;
}

export class FamilyData extends BaseData {
  public gender: string;
  public maritalStatus: string;
}
