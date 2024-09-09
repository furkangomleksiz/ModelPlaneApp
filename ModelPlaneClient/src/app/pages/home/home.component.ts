import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgFor],  // Add NgFor here
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  planes: any[] = [];
  private apiUrl = 'http://localhost:5005/api/Planes';  // Replace with your actual API endpoint

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(this.apiUrl).subscribe({
      next: (response) => this.planes = response,
      error: (error) => console.error('Error fetching planes:', error)
    });
  }
}
