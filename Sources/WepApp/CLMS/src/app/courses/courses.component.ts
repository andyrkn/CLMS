import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  public courses: any;

  constructor(private dataService: DataService) { }

  public ngOnInit() {
    this.courses = this.dataService.getCourses();
  }

}
