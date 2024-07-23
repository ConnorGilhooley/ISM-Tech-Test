// src/app/app.component.ts
import { Component } from '@angular/core';
import { DoorsComponent } from './doors/doors.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [DoorsComponent]
})
export class AppComponent {
  title = 'door-management';
}
