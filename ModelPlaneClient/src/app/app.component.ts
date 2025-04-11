import { NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BannerComponent } from './components/banner/banner.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    NgFor,
    BannerComponent,
    NavbarComponent
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'ModelPlaneClient';
  planes: any;

  ngOnInit(): void {
    this.http.get(`${environment.apiUrl}/planes`).subscribe({
      next: response => this.planes = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed'),
    });
  }
}
