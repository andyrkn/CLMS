import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServerConfig } from './server.config';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable()
export class QuestionsService {

    private authHeaders;

    private readonly _questions = ':5004/api/questions';
    constructor(
        private httpClient: HttpClient,
        private userService: UserService) {

        this.authHeaders = new HttpHeaders({ 'Authorization': this.userService.getToken() });
    }

    public GetAllQuestionsWithAnswers(): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions, { headers: this.authHeaders });
    }

    public GetGuestionById(questionId): Observable<any> {
        return this.httpClient.get(ServerConfig.endpoint + this._questions + '/' + questionId, { headers: this.authHeaders });
    }

    public AddAnswerForAQuestion(questionId: Observable<any>) {
        return this.httpClient.get(ServerConfig.endpoint + this._questions + '/' + questionId, { headers: this.authHeaders });
    }

    public ApproveAnswerForAQuestion(questionId: any, answerId: any) {

    }
}
