import { Component, OnInit } from '@angular/core';
import { QuestionsService } from '../services/questions.service';

@Component({
    selector: 'app-questions',
    templateUrl: './questions.component.html',
    styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {


    public questions: any;

    constructor(private questionsSerivce: QuestionsService) {
        this.questionsSerivce.GetAllQuestionsWithAnswers().subscribe((data) => {
            this.questions = data;
        });
    }

    public ngOnInit() {
    }

    public submit(id) {
        const val = (document.getElementById('q' + id) as (HTMLInputElement)).value;
        console.log(id, val);
    }
}
