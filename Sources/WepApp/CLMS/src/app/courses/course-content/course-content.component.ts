import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-course-content',
  templateUrl: './course-content.component.html',
  styleUrls: ['./course-content.component.css']
})
export class CourseContentComponent implements OnInit {
  public course: any;
  public ownsCourse: boolean;
  constructor(private courseService: CourseService, private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.courseService.getCourseContent(params.get("id")).subscribe((data) => {
        console.log(data);
        this.ownsCourse = this.userService.getEmail() == data.holderEmail;
        this.course = data;
      })
    })
    
  }

}
