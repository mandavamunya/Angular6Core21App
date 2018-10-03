import { Component, OnInit } from '@angular/core';
import { MatToolbar, MatButton } from '@angular/material';

import { AuthService } from '../services/auth.service';

@Component({
    selector: 'nav',
    template: `
    <mat-toolbar color="primary">
        <button mat-button routerLink="/">Home</button>
        <button mat-button routerLink="/blogs">Blogs</button>
        <span style="flex: 1 1 auto"></span>
        <button *ngIf="!auth.isAuthenticated" mat-button routerLink="/login">Login</button>
        <button *ngIf="!auth.isAuthenticated" mat-button routerLink="/register">Register</button>
        <button *ngIf="auth.isAuthenticated" mat-button routerLink="/">Welcome {{auth.name}}</button>
        <button *ngIf="auth.isAuthenticated" mat-button (click)="auth.logout()">Logout</button>
    </mat-toolbar>
    `
})
export class NavComponent {
    constructor(public auth: AuthService) {}
}