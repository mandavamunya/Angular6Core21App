import { Component, OnInit } from '@angular/core';

import { UserService } from '../services/user.service';

@Component({
    selector: 'user',
    template: `
    <!--
    <mat-card class="card">
        <mat-card-content>
            <mat-form-field>
                <input [(ngModel)]="model.firstName" matInput="" value="{{owner}}" placeholder="First Name">
            </mat-form-field>
            <mat-form-field>
                <input [(ngModel)]="model.lastName" matInput=""  placeholder="Last Name">
            </mat-form-field>
            <mat-card-actions>
                <button (click)="post()" mat-raised-button color="primary">Save Changes</button>
            </mat-card-actions>
        </mat-card-content>
    </mat-card>
    -->
    `
})
export class UserComponent implements OnInit {
    model = {
        firstName: "",
        lastName: ""
    };

    constructor(private userService: UserService) {}

    ngOnInit() {
        this.userService.getUser().subscribe(res => {
            this.model.firstName = res.firstName;
            this.model.lastName = res.lastName;
        });
    }

    post() {
        this.userService.saveUser(this.model).subscribe();
    }
}