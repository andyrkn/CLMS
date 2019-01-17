import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-questions',
    templateUrl: './questions.component.html',
    styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {


    public questions: any;

    constructor() {
        this.questions = [
            'What Is x',
            'What Is a',
            'What Is b',
            'What Is c',
            'What Is d',
            'What Is e',
            'What Is f'
        ];
    }

    public ngOnInit() {
    }

    public submit(id) {
        const val = (document.getElementById('q' + id) as (HTMLInputElement)).value;
        console.log(id, val);
    }
}
