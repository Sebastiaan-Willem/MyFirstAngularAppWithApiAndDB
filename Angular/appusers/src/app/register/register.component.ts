import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
   //reactive forms -> add elements to the reactive form & add validation per individual component between ()
    registerUser = new FormGroup({
    username: new FormControl('default value',Validators.required),
    password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(8)])
    //multiple validators need to be passed as an Array []
  });

 
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

 
  

  register(){
    console.log(this.registerUser.value);
  }

}
