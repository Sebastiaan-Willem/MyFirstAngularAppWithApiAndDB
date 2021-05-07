import { Component, OnInit } from '@angular/core';
import { AppUser } from '../AppUser';
import {UserService} from '../user.service';

@Component({
  selector: 'app-user-overview',
  templateUrl: './user-overview.component.html',
  styleUrls: ['./user-overview.component.css']
})
export class UserOverviewComponent implements OnInit {
  users: AppUser[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void{
    this.userService.getUsers().subscribe(x => this.users = x);
  }

  addUser(name:string){
    name = name.trim();
    if(!name){return;}

    this.userService.addUser({name} as AppUser).subscribe(x => this.users.push(x));
  }

  deleteUser(user: AppUser){
    if(!user){return;}
    this.userService.deleteUser(user).subscribe(() => this.users = this.users.filter(x => x != user));
                                  //get everythingthing that's NOT equal to the to be deleted element
  }

}
