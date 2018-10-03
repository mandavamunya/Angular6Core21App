import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatCard } from '@angular/material';

import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';

@Component({
    selector: 'blogs',
    template: `
    <div *ngFor="let blog of blogService.blogs">
        <mat-card class="card">
            <mat-card-title [routerLink]="['/blogs', blog.id]" style="cursor: pointer">{{blog.name}}</mat-card-title>
            <mat-card-content>{{blog.publishDate}}</mat-card-content>
        </mat-card>
    </div>
    `
})
export class BlogsComponent implements OnInit {
    messages: any;
    constructor(public blogService: BlogService, 
        public userService: UserService,
        private route: ActivatedRoute) {}

    ngOnInit() {
        const id = this.route.snapshot.params['id'];
        this.blogService.getBlogs(id);
        //this.userService.getUser().subscribe();
    }
}