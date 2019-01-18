import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/services/course.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-add-course',
	templateUrl: './add-course.component.html',
	styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent {
	public teacherEmail: string = '';
	public name: string = '';
	public error: string = '';
	
	constructor(private courseService: CourseService, private router: Router) {
	}

	public submit(): void {
		this.courseService.create(this.name, this.teacherEmail)
			.subscribe(
				() => this.router.navigate(['/courses']),
				(error) => {
					this.error = error.error;
				});
	}
}
