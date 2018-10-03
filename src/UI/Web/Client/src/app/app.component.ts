import { Component, ViewChild } from '@angular/core';
import { NavComponent } from '../app/nav/nav.component';
@Component({
  selector: 'app-root',
  template: `
  <nav></nav>
  <router-outlet>`,
  styleUrls: ['./app.component.css']
})
export class AppComponent {}
