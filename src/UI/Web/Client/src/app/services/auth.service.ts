import { Injectable, Inject  } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthService {
    NAME_KEY = 'name';
    TOKEN_KEY = 'token';

    constructor(private http: Http, private router: Router, 
        @Inject('BASE_URL') private baseUrl: string) {}

    get name() {
        return localStorage.getItem(this.NAME_KEY);
    }

    get isAuthenticated() {
        return !!localStorage.getItem(this.TOKEN_KEY);
    }

    get tokenHeader() {
        const h = JSON.stringify({'Authorization': 'Bearer' + localStorage.getItem(this.TOKEN_KEY)});
        const header = new Headers({'Authorization': 'Bearer ' + localStorage.getItem(this.TOKEN_KEY)});
        return new RequestOptions({ headers: header });
    }

    login(loginData) {
        this.http.post(this.baseUrl + '/login', loginData).subscribe(res => {
            this.authenticate(res);
        });
    }

    register(user) {
        delete user.confirmPassword;
        this.http.post(this.baseUrl + '/register', user).subscribe( res => {
            this.authenticate(res);
        });
    }

    logout() {
        localStorage.removeItem(this.NAME_KEY);
        localStorage.removeItem(this.TOKEN_KEY);
    }

    authenticate(res) {
        const authResponse = res.json();
            
        if (!authResponse.token) 
            return;

        localStorage.setItem(this.TOKEN_KEY, authResponse.token);
        localStorage.setItem(this.NAME_KEY, authResponse.firstName);
        this.router.navigate(['/']);
    }
}