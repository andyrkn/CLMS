import { Component, OnInit } from '@angular/core';
import { QuestionsService } from 'src/app/services/questions.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {


  public name = "";
  public error = "";
  constructor(private questionService : QuestionsService, private router : Router) { }

  ngOnInit() {
  }

  public submit(): void {
     this.questionService.CreateQuestion(this.name)
			.subscribe(
				() => this.router.navigate(['/questions']),
				(error) => {
					this.error = error.error;
				});
	}

}
