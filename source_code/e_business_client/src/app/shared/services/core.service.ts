import { Injectable } from '@angular/core';

@Injectable()
export class CoreService {
  constructor() {}

  // public baseUrl: string = 'http://localhost:5000/';
  public baseUrl: string = 'http://devcorenet.com/';
  

  // public get url() {
  //    return "";
  //   // ng build --prod --base_href=/kaf
  //   // npm run build -- --prod
  //   // return "http://192.168.1.32:8081/Core/"
  // }
}