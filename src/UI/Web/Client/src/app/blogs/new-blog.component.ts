import { Component } from '@angular/core';

import { BlogService } from '../services/blog.service';
import { AuthService } from '../services/auth.service';


@Component({
    selector: 'new-blog',
    template: `
    <mat-card class="card">
        <mat-card-content>
            <mat-form-field>
                <textarea [(ngModel)]="message.text" matInput=""  placeholder="Blog"></textarea>
            </mat-form-field>
            <mat-card-actions>
                <button (click)="post()" mat-button color="primary">POST</button>
            </mat-card-actions>
        </mat-card-content>
    </mat-card>
    `
})
export class NewBlogComponent {
    message = {
        owner: this.auth.name,
        text: ""
    };

    constructor(private blogService: BlogService, private auth: AuthService) {}
    post() {
        this.blogService.postBlog(this.message);
    }
}