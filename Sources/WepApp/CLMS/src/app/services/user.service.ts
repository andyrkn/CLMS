import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ServerConfig } from './server.config';
import { Observable, from, BehaviorSubject } from 'rxjs';
import { UserModel } from './Models/user.model';
import { Router } from '@angular/router';

@Injectable()
export class UserService {

    private readonly _users = ':5000/api/users';
    private readonly _usersLogin = ':5000/api/token';
    private readonly _token = 'TOKEN';

    private _loginSubject = new BehaviorSubject<boolean>(false);

    constructor(private httpClient: HttpClient, private router: Router) { }

    private saveToken(token) {
        localStorage.setItem(this._token, token);
    }

    private saveEmail(email) {
        localStorage.setItem('email', email);
    }

    private removeToken() {
        localStorage.removeItem(this._token);
    }

    public getToken() {
        return localStorage.getItem(this._token);
    }

    public getEmail() {
        return localStorage.getItem('email');
    }

    public get loginSubject() {
        return this._loginSubject.asObservable();
    }

    public logout() {
        this.removeToken();
        this._loginSubject.next(false);
    }

    public get isLoggedIn() {
        return localStorage.getItem(this._token) ? true : false;
    }

    public login(email: string, password: string) {

        const httpParams = new HttpParams()
            .set('email', email)
            .set('password', password);

        const headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });

        return from(new Promise((resolve) => this.httpClient
            .post(ServerConfig.endpoint + this._usersLogin, httpParams.toString(), { headers: headers })
            .subscribe((data) => {
                this.saveToken(data);
                this.saveEmail(email);
                this._loginSubject.next(true);
                this.router.navigate(['home']);
                resolve(true);
            }, (err) => { resolve(false); })));
    }

    public register(user: UserModel) {
        const body = JSON.stringify(user);

        this.httpClient.post(ServerConfig.endpoint + this._users, body).subscribe((data) => {
            this.login(user.Email, user.Password).subscribe();
        });
    }
}
