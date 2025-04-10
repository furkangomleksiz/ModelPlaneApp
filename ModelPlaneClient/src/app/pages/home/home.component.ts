import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],  // Add RouterModule for navigation
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  planes: any[] = [];
  private apiUrl = 'http://localhost:5005/api/Planes';  // Replace with your actual API endpoint

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(this.apiUrl).subscribe({
      next: (response) => this.planes = response.reverse(), // 👈 Reverses the order
      error: (error) => console.error('Error fetching planes:', error)
    });
  }

  getImageUrl(image: string): string {
    // Ensure no duplicate 'images/planes/' in the path
    const basePath = 'http://localhost:5005';
    return image.startsWith('/images/')
      ? `${basePath}${image}`
      : `${basePath}/api/images/${image}`;
  }
}
