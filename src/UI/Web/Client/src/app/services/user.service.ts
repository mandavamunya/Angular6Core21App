import { Http } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { Subject } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { AuthService } from './auth.service';

@Injectable()
export class UserService {

    constructor(private http: Http, private sb: MatSnackBar, private auth: AuthService,
        @Inject('BASE_URL') private baseUrl: string) {}

    getUser() {
       return this.http.get(this.baseUrl + 'api/users/me', this.auth.tokenHeader)
       .pipe(
         map(res => res.json())
       );
    }

    saveUser(userData) {
        console.log(userData);
        return this.http.post(this.baseUrl + 'api/users/me', userData, this.auth.tokenHeader)
        .pipe(
          map(res => console.log(res.json()))
        );
     }

    private handleError(error) {
        console.error(error);
        this.sb.open(error, 'close', {duration: 2000});
    }
}