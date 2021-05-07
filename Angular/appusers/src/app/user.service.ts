import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppUser } from './AppUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor( private http: HttpClient) { }

  private userUrl = 'https://localhost:44389/api/users';

  httpOptions = {
    headers: new HttpHeaders({'Content-type':'application/json'})
  };

  getUsers(): Observable<AppUser[]>{
    return this.http.get<AppUser[]>(this.userUrl);
  }

  getUser(id: number): Observable<AppUser>{
    //edit url with id to get specific user
    const url = `${this.userUrl}/${id}`;
       
    return this.http.get<AppUser>(url); 
  }

  addUser(user: AppUser): Observable<AppUser>{
    return this.http.post<AppUser>(this.userUrl, user, this.httpOptions);
  }

  updateUser(user?: AppUser): Observable<any>{
    return this.http.put(this.userUrl, user, this.httpOptions);
  }

  deleteUser(user: AppUser): Observable<AppUser>{
    const url = `${this.userUrl}/${user.id}`;
    return this.http.delete<AppUser>(url,this.httpOptions);
  }

  
}
