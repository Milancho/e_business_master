import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  templateUrl: 'bpm.component.html'
})

export class BpmComponent {
  public json: string;
  public object: object;
  
  constructor() {
    this.json = '{ "flow": [{ "stateFrom": "New Application", "flowContidion": [{ "stateTo": "Send To Board", "userRoles": ["Loan Officer"], "validators": [{ "validator": "Range", "field": "Amount", "errorMessage": "Value for {0} must be between {1} and {2}.", "expression": "(10 000,60 000)" }], "action": "api/applications/{id:int}/changestate/{state:int}" }, { "stateTo": "Canceled", "userRoles": ["Loan Officer", "Finance Manager", "Credit Manager", "Administrator"], "validators": [], "action": "api/applications/{id:int}/changestate/{state:int}" }] }, { "stateFrom": "Send To Board", "flowContidion": [{ "stateTo": "Approve", "userRoles": ["Loan Officer", "Finance Manager", "Credit Manager", "Administrator"], "validators": [], "action": "api/applications/{id:int}/changestate/{state:int}" }, { "stateTo": "Rejected", "userRoles": ["Loan Officer", "Finance Manager", "Credit Manager", "Administrator"], "validators": [], "action": "api/applications/{id:int}/changestate/{state:int}" }, { "stateTo": "Canceled", "userRoles": ["Loan Officer", "Finance Manager", "Credit Manager", "Administrator"], "validators": [], "action": "api/applications/{id:int}/changestate/{state:int}" }] }, { "stateFrom": "Approve", "flowContidion": [{ "stateTo": "Canceled", "userRoles": ["Loan Officer", "Finance Manager", "Credit Manager", "Administrator"], "validators": [], "action": "api/applications/{id:int}/changestate/{state:int}" }, { "stateTo": "Terminated", "userRoles": [""], "validators": [], "action": "Job" }, { "stateTo": "Expired", "userRoles": [""], "validators": [], "action": "Job" }] }], "State": [{ "key": 1, "value": "New Application" }, { "key": 2, "value": "Send To Board" }, { "key": 3, "value": "Approve" }, { "key": 4, "value": "Canceled" }, { "key": 5, "value": "Terminated" }, { "key": 6, "value": "Rejected" }, { "key": 7, "value": "Expired" }], "validatorAttributes": [{ "key": 1, "value": "Range" }, { "key": 2, "value": "RegularExpression" }, { "key": 3, "value": "Required" }, { "key": 4, "value": "StringLength" }, { "key": 5, "value": "Validation" }] }';
    this.object = JSON.parse(this.json);
    console.log(this.object);
  }
}
