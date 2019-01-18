import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServerConfig } from './server.config';
import { Observable } from 'rxjs';
import { UserService } from './user.service';
import { AnswerModel } from './Models/answer.model';
import {QuestionModel} from './Models/question.model';

@Injectable()
export class QuestionsService {

    private authHeaders;

    private readonly _questions = ':5004/api/questions';
    constructor(
        private httpClient: HttpClient,
        private userService: UserService) {

        this.authHeaders = new HttpHeaders({ 'Authorization': this.userService.getToken() });
    }

    public CreateQuestion(questionModel : QuestionModel) {
        const body = {'Name' : questionModel.Name};
    
        this.httpClient.post(ServerConfig.endpoint + this._questions, body, { headers: this.authHeaders })
            .subscribe((res) => {
                console.log(res);
            }, (err) => { console.log(err); });
    }

    public GetAllQuestionsWithAnswers(): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions, { headers: this.authHeaders });
    }

    public GetGuestionById(questionId): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions + '/' + questionId, { headers: this.authHeaders });
    }

    public AddAnswerForAQuestion(questionId: string, answer: string) {
        const answerModel = new AnswerModel(answer, this.userService.getEmail());
        const body = { 'AnswerText': answerModel.AnswerText, 'Email': answerModel.Email };

        console.log(body, questionId);
        this.httpClient.post(ServerConfig.endpoint + this._questions + '/' + questionId + '/answer', body, { headers: this.authHeaders })
            .subscribe((res) => {
                console.log(res);
            }, (err) => { console.log(err); });
    }

    public ApproveAnswerForAQuestion(questionId: any, answerId: any) {
        this.httpClient.put(ServerConfig.endpoint+this._questions+ '/' + questionId + '/answer'+ '/'+answerId, { headers: this.authHeaders })
    }
}
