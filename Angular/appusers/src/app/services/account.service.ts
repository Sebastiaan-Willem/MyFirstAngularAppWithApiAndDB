import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../User';
import {map} from 'rxjs/operators';
import { FormControl, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  constructor(private http: HttpClient) { }  
  
  baseUrl = 'https://localhost:44389/api/account';
  currentUser?: User;

  //API already returns login data in JSON format so this is unnecessary here.
  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  // };

  

  login(model: any): Observable<any>{
    var url = `${this.baseUrl}/login`;
    return  this.http.post(url, model).pipe(
      map((response: any) => {
        const user: User = response;
          if(user){
            //localstorage = cookies
            localStorage.setItem('user', JSON.stringify(user));
            this.setCurrentUser(user);
          }
      })
      
    );
  }
  setCurrentUser(user: User)
  {
    this.currentUser = user;
  }

  //ERRORRRRRRR
  // getCurrentUser(): User{
  //   if(this.currentUser){
  //     return this.currentUser;
  //   }
    
  // }

  logout(){
    localStorage.removeItem('user');
    this.currentUser = undefined;
  }


}
