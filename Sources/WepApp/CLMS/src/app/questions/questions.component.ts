import { Component, OnInit } from '@angular/core';
import { QuestionsService } from '../services/questions.service';
import { AnswerModel } from '../services/Models/answer.model';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
    selector: 'app-questions',
    templateUrl: './questions.component.html',
    styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

    public questions: any;
    public isAdminOrTeacher = true;
    public email: string;

    constructor(private userService: UserService, private questionsSerivce: QuestionsService, private router: Router) {
    }

    public ngOnInit() {

        this.isAdminOrTeacher = this.userService.role !== 'Student';
        console.log(this.userService.role);
        this.questionsSerivce.GetAllQuestionsWithAnswers().subscribe((data) => {
            this.questions = data;
            console.log(this.questions);
        });

        this.email = this.userService.getEmail();
    }

    public submit(id) {
        const val = (document.getElementById('q' + id) as (HTMLInputElement)).value;
        this.questionsSerivce.AddAnswerForAQuestion(this.questions[id].id, val);
    }

    public changeRouteToAdd() {
        this.router.navigate(['/questions/add']);
    }

    public approve(i, j) {
        // console.log(i, j);
        if (this.isAdminOrTeacher) {
            this.questionsSerivce.ApproveAnswerForAQuestion(this.questions[i].id, this.questions[i].answers[j].id).subscribe();
        }
    }
}
