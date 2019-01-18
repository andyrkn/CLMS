import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  private isAdmin: boolean = false;

  constructor(private userService: UserService) { }

  public ngOnInit() {
    this.isAdmin = this.userService.role === "Admin" ;
  }

}
