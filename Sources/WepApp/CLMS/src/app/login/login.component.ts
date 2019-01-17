import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public email: string;
  public password: string;
  public invalidData = false;

  constructor(private userService: UserService) { }

  public ngOnInit() {
  }

  public login() {
    this.invalidData = false;
    this.userService.login(this.email, this.password).subscribe((res) => { if (!res) { this.invalidData = true; } });
  }

}
