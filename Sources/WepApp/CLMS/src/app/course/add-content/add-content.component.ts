import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-content',
  templateUrl: './add-content.component.html',
  styleUrls: ['./add-content.component.css']
})
export class AddContentComponent {
  public description: string = '';

  constructor(private courseService: CourseService, private route: ActivatedRoute, private router: Router) {
  }

  public submit() {
    this.route.paramMap.subscribe(params => { 
      this.courseService.addContent(params.get("id"), this.description).subscribe(() => {
        this.router.navigate[`courses/content/${params.get("id")}`];
      });
    });
  }
}
