import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { UserService } from "./user.service";
import { ServerConfig } from "./server.config";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class CourseService {
    private readonly courses = '/api/courses';
    constructor(private httpClient: HttpClient, private userService: UserService) {
    }

    public create(name: string, email: string): Observable<any> {
        const model = {
            "name": name,
            "holderEmail": email
        };
        return this.httpClient.post(ServerConfig.coursesDomain + this.courses, model, { headers: this.authHeaders() });
    }

    public getAll(): Observable<any> {
        return this.httpClient.get(ServerConfig.coursesDomain + this.courses, { headers: this.authHeaders()});
    }

    private authHeaders(): HttpHeaders {
        return new HttpHeaders({ 'Authorization': `Bearer ${this.userService.getToken()}` });
    }
}