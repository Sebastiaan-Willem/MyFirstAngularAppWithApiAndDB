import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Member } from '../Members'

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl='https://localhost:44389/api/members';

  constructor(private httpClient: HttpClient) { }

  getMembers(){
    return this.httpClient.get<Member[]>(this.baseUrl);
  }

  getMember(id: number){
    return this.httpClient.get<Member>(this.baseUrl);
  }
}
