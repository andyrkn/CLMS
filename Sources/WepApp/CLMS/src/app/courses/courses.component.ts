import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { CourseService } from '../services/course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  public courses: [] = [];
  public isAdmin: boolean = false;

  constructor(private userService: UserService, private courseService: CourseService, private router: Router) { }

  public ngOnInit() {
    this.isAdmin = this.userService.role === 'Admin';

    this.courseService.getAll().subscribe((data) => {
      this.courses = data;
    });
  }

  public content(id: string) {
    this.router.navigate(['courses/content', id]);
  }
}
