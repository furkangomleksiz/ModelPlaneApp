import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [CommonModule, FormsModule],
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private http: HttpClient, private router: Router) {}

  onLogin() {
    this.http.post<any>(`${environment.apiUrl}/auth/login`, {
      username: this.username,
      password: this.password
    }).subscribe({
      next: (response) => {
        localStorage.setItem('auth_token', response.token);  // Store token
        this.router.navigate(['/model-upload']);  // Redirect to upload page
      },
      error: () => alert('Invalid login credentials')
    });
  }
}
