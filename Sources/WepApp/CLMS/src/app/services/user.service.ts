import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ServerConfig } from './server.config';
import { from, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { RegisterModel } from './Models/register.model';
import * as jwtDecode from 'jwt-decode';

@Injectable()
export class UserService {

    private readonly _users = ':5000/api/users';
    private readonly _usersLogin = ':5000/api/token';
    private readonly _token = 'TOKEN';
    private readonly _role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

    private _loginSubject = new BehaviorSubject<boolean>(false);

    constructor(private httpClient: HttpClient, private router: Router) { 
        this._loginSubject.next(this.getToken() ? true : false);
    }

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

    public get role() {
        return jwtDecode(this.getToken())[this._role];
    }

    public login(email: string, password: string) {

        const httpParams = new HttpParams()
            .set('email', email)
            .set('password', password);

        const headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });

        return from(new Promise((resolve) => this.httpClient
            .post(ServerConfig.endpoint + this._usersLogin, httpParams.toString(), { headers: headers })
            .subscribe((data: any) => {
                this.saveToken(data.token);
                this.saveEmail(email);
                this._loginSubject.next(true);
                this.router.navigate(['home']);
                resolve(true);
            }, (err) => { resolve(false); })));
    }

    public register(user: RegisterModel) {

        const body = {
            'Email': user.Email,
            'FirstName': user.FirstName,
            'LastName': user.LastName,
            'Password': user.Password,
            'Role': user.Role
        };

        this.httpClient.post(ServerConfig.endpoint + this._users, body).subscribe((data) => {
            console.log('register succes');
            this.login(user.Email, user.Password).subscribe();
        }, (err) => {
            console.log(err);
            this.login(user.Email, user.Password).subscribe();
        });
    }
}
