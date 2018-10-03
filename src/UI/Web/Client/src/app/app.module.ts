import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule, MatToolbarModule, MatGridListModule } from '@angular/material';

import { BlogService } from '../app/services/blog.service';
import { UserService } from '../app/services/user.service';
import { AuthService } from './services/auth.service';


import { AppComponent } from './app.component';
import { BlogsComponent } from './blogs/blogs.component';
import { NewBlogComponent } from '../app/blogs/new-blog.component';
import { FeaturedPostComponent } from '../app/blogs/featured-post.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from '../app/register/register.component';
import { LoginComponent } from '../app/login/login.component';
import { UserComponent } from '../app/user/user.component';

const routes = [{
  path: '',
  component: HomeComponent
},
{
  path: 'blogs',
  component: BlogsComponent
},
{
  path: 'blogs/:id',
  component: BlogsComponent
},
{
  path: 'register',
  component: RegisterComponent
},
{
  path: 'login',
  component: LoginComponent
},
{
  path: 'user',
  component: UserComponent
}
];

@NgModule({
  declarations: [
    AppComponent,
    BlogsComponent,
    NewBlogComponent,
    FeaturedPostComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpModule,
    CommonModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule, MatToolbarModule, MatGridListModule
  ],
  exports: [
    MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule, MatToolbarModule, MatGridListModule
  ],
  providers: [
    HttpClientModule,
    UserService,BlogService,
    AuthService, 
    { provide: 'BASE_URL', useFactory: getBaseUrl }],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

