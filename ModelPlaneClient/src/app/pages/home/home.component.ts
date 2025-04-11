import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  planes: any[] = [];
  private apiUrl = `${environment.apiUrl}/Planes`;  // ✅ Dynamic from env

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(this.apiUrl).subscribe({
      next: (response) => this.planes = response.reverse(), // Show newest first
      error: (error) => console.error('Error fetching planes:', error)
    });
  }

  getImageUrl(image: string): string {
    const basePath = environment.apiUrl; // ✅ Use env base path for images too
    return image.startsWith('/images/')
      ? `${basePath}${image}`
      : `${basePath}/images/${image}`;
  }
}
