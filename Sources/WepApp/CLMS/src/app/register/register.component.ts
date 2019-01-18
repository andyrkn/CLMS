import { Component, OnInit } from '@angular/core';
import { RegisterModel } from '../services/Models/register.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public registerModel = new RegisterModel();
  public invalidData = false;
  public rpassword: string;
  public roles = ['Admin', 'Student', 'Professor' ];

  constructor(private userService: UserService) {
    this.registerModel.Role = 1;
  }

  public ngOnInit() {
  }

  public updateRole(index) {
    this.registerModel.Role = index;
  }

  public register() {
    this.userService.register(this.registerModel);
  }
}
