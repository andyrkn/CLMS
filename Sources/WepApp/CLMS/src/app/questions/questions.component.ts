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
    constructor(private userService: UserService, private questionsSerivce: QuestionsService, private router: Router) {
    }

    public ngOnInit() {
        console.log(this.userService.role);
        console.log(this.isAdminOrTeacher);
        this.questionsSerivce.GetAllQuestionsWithAnswers().subscribe((data) => {
            this.questions = data;
        });
    }

    public submit(id) {
        const val = (document.getElementById('q' + id) as (HTMLInputElement)).value;
        this.questionsSerivce.AddAnswerForAQuestion(this.questions[id].id, val);
    }

    public changeRouteToAdd() {
        this.router.navigate(['/questions/add']);
    }
}
