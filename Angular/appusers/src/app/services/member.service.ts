import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Member } from '../Members'

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl='https://localhost:44389/api/users/members';

  //add token to HTTP Header via HttpOptions
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('user') || '{}').token}`
    })
  };

  constructor(private httpClient: HttpClient) { }

  getMembers(){
    return this.httpClient.get<Member[]>(this.baseUrl, this.httpOptions);
  }

  getMember(id: number){
    return this.httpClient.get<Member>(`this.baseUrl/${id}`, this.httpOptions);
  }
}
