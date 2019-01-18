import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServerConfig } from './server.config';
import { Observable } from 'rxjs';
import { UserService } from './user.service';
import { AnswerModel } from './Models/answer.model';
import { QuestionModel } from './Models/question.model';

@Injectable()
export class QuestionsService {


    private readonly _questions = ':5004/api/questions';
    constructor(
        private httpClient: HttpClient,
        private userService: UserService) {
    }

    public CreateQuestion(questionName: string) {
        const body = { 'Name': questionName };

        return this.httpClient.post(ServerConfig.endpoint + this._questions, body, { headers: this.authHeaders() });
    }

    public GetAllQuestionsWithAnswers(): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions, { headers: this.authHeaders() });
    }

    public GetGuestionById(questionId): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions + '/' + questionId, { headers: this.authHeaders() });
    }

    public AddAnswerForAQuestion(questionId: string, answer: string) {
        const answerModel = new AnswerModel(answer);
        const body = { 'AnswerText': answerModel.AnswerText };

        this.httpClient.post(ServerConfig.endpoint + this._questions + '/' + questionId + '/answer', body, { headers: this.authHeaders() })
            .subscribe((res) => {
                console.log(res);
            }, (err) => { console.log(err); });
    }

    public ApproveAnswerForAQuestion(questionId: any, answerId: any) {
        return this.httpClient
            .put(ServerConfig.endpoint + this._questions + '/' + questionId + '/answer' + '/' + answerId, { headers: this.authHeaders() });
    }

    private authHeaders(): HttpHeaders {
        return new HttpHeaders({ 'Authorization': `Bearer ${this.userService.getToken()}` });
    }
}

