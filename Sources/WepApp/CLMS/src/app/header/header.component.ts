import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public isLoggedIn = false;

  constructor(private userService: UserService) {
    this.userService.loginSubject.subscribe((data) => {
      this.isLoggedIn = data;
    });
  }

  public ngOnInit() {
  }

  public logout() {
    this.userService.logout();
  }
}
