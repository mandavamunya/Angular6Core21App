import { Component } from '@angular/core';
import { BlogsComponent } from '../blogs/blogs.component';
import { NewBlogComponent } from '../blogs/new-blog.component';

@Component({
  selector: 'home',
  template: `
  <featured-post></featured-post>`
})
export class HomeComponent {}
