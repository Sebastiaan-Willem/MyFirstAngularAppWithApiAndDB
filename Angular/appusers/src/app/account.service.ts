import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  constructor(private http: HttpClient) { }  
  
  baseUrl = 'https://localhost:44389/api/account';

  //API already returns login data in JSON format so this is unnecessary here.
  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  // };

  login(model: any): Observable<any>{
    var url = `${this.baseUrl}/login`;
    return  this.http.post(url, model);
  }


}
