import { Component, OnInit } from '@angular/core';
import { AccountService} from '../account.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  //anonymous empty object. Even though name and password don't exist we can still bind to them from the html and javascript will make them for us
  model:any = {};
  loggedIn: boolean = false;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(): void {
    this.accountService.login(this.model)
          .subscribe(x => {
                            //happy path
                            this.loggedIn = true;
                            console.log(x);
                          }, error => {
                            //Error handling -> something went wrong. Display message to user
                            console.log(error);
          });
  }

}
