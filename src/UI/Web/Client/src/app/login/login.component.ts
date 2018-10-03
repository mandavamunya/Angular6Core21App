import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, NgControlStatusGroup } from '@angular/forms';

import { AuthService } from '../services/auth.service';

@Component({
    selector: 'login',
    template: `
        <mat-card>
            <mat-card-content>
                <mat-form-field>
                    <input matInput [(ngModel)]="loginData.email" placeholder="Email" type="email">
                </mat-form-field>
            </mat-card-content>
            <mat-card-content>
                <mat-form-field>
                    <input matInput [(ngModel)]="loginData.password" placeholder="Password" type="password">
                </mat-form-field>
            </mat-card-content>
            <button mat-raised-button color="primary" (click)=login()>Login</button>
        </mat-card>
    `
})
export class LoginComponent {
    constructor(private auth: AuthService) {}

    loginData = {
        email: '',
        password: ''
    }

    login() {
        this.auth.login(this.loginData);
    }
}