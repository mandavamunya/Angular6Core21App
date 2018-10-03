import { Http } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { Subject } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { AuthService } from './auth.service';

import { Blog } from '../blogs/blog.interface';
import { Post } from '../blogs/post.interface';

@Injectable()
export class BlogService {

    public selectedBlog: Blog = <Blog>{};
    public blogs: Blog[] = [];
    public featuredArticle = <Post>{};
    public featuredNews = <Post>{};

    private blogStore = [];
    private blogSubject = new Subject();

    constructor(private http: Http, private sb: MatSnackBar, private auth: AuthService,
        @Inject('BASE_URL') private baseUrl: string) {}

    getBlogs(id) {
        id = (id) ? '/' + id : '';
        this.http.get(this.baseUrl + 'api/blog' + id)
        .subscribe(response => {
            this.blogs = response.json() as Blog[];
            console.log(this.blogs);
        }, error => {
            this.handleError('Unable to get blog(s)');
        });
    }

    async postBlog(blog) {
        try {
        const response = await this.http.post(this.baseUrl + 'api/blog', blog).toPromise();
        this.blogStore.push(response.json());
        this.blogSubject.next(this.blogStore);
        } catch (error) {
            this.handleError('Unable to post blog');
        }
    }

    async getFeaturedArticle() {
        this.http.get(this.baseUrl + 'api/Post/FeaturedArticle')
        .subscribe(response => {
            this.featuredArticle = response.json() as Post;
            console.log(this.featuredArticle);
        }, error => {
            this.handleError('Unable to get featured article');
        });            
    }

    async getFeaturedNews() {
        this.http.get(this.baseUrl + 'api/Post/FeaturedNews')
        .subscribe(response => {
            this.featuredNews = response.json() as Post;
            console.log(this.featuredNews);
        }, error => {
            this.handleError('Unable to get featured news');
        });            
    }

    private handleError(error) {
        console.error(error);
        this.sb.open(error, 'close', {duration: 2000});
    }
}