import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppUser } from '../AppUser';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  user: AppUser | undefined;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser(): void {
    //get the ID from the URL and add it to a const
    const id=Number(this.route.snapshot.paramMap.get('id'));
    this.userService.getUser(id)
                    .subscribe(x => this.user = x);
  }

  onBackButtonClicked(): void {
    this.location.back();
  }

  SaveUser() : void{
    this.userService.updateUser(this.user).subscribe(() => this.onBackButtonClicked());
  }

}
