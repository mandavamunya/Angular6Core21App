import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatCard } from '@angular/material';

import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';

@Component({
    selector: 'featured-post',
    template: `
    <div>
        <mat-grid-list cols="2" >
            <mat-grid-tile>
                <mat-card class="card">
                    <mat-card-title style="cursor: pointer">{{blogService.featuredNews.description}}</mat-card-title>
                    <mat-card-content>{{blogService.featuredNews.content}}</mat-card-content>
                </mat-card>
            </mat-grid-tile>
            <mat-grid-tile>
                <mat-card class="card">
                    <mat-card-title style="cursor: pointer">{{blogService.featuredArticle.description}}</mat-card-title>
                    <mat-card-content>{{blogService.featuredArticle.content}}</mat-card-content>
                </mat-card>   
            </mat-grid-tile>
        </mat-grid-list>     
    </div>
    `
})
export class FeaturedPostComponent implements OnInit {
    messages: any;
    constructor(public blogService: BlogService, 
        public userService: UserService,
        private route: ActivatedRoute) {}

    ngOnInit() {
        this.blogService.getFeaturedArticle();
        this.blogService.getFeaturedNews();
        //this.userService.getUser().subscribe();
    }
}