import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerConfig } from './server.config';
import { Observable } from 'rxjs';

@Injectable()
export class QuestionsService {

    private readonly _questions = ':5004/api/questions';
    constructor(private httpClient: HttpClient) {
    }

    public GetAllQuestionsWithAnswers(): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions);
    }

    public GetGuestionById(questionId): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions + '/' + questionId);
    }

    public AddAnswerForAQuestion(questionId: Observable<any>) {
        return this.httpClient.get(ServerConfig.endpoint + this._questions + '/' + questionId);
    }

    public ApproveAnswerForAQuestion(questionId: any, answerId: any) {

    }
}
