import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment'; // adjust if needed

@Component({
  selector: 'app-model-upload',
  standalone: true,
  templateUrl: './model-upload.component.html',
  styleUrls: ['./model-upload.component.css'],
  imports: [CommonModule, FormsModule],
})
export class ModelUploadComponent {
  plane = {
    wings900Id: null,
    manufacturer: '',
    scale: '',
    airline: '',
    model: '',
    partNumber: '',
    registration: '',
    country: '',
    continent: '',
    productionYears: '',
    rollingGears: false,
    notes: '',
    engines: '',
    unitsMade: null,
    includesStand: false,
    imageUrls: []
  };

  selectedFiles: File[] = [];

  constructor(private http: HttpClient) {}

  onFileSelected(event: any) {
    this.selectedFiles = Array.from(event.target.files);
  }

  onSubmit() {
    const token = localStorage.getItem('auth_token');  // Optional if you're using JWT auth
    const headers = token ? { headers: { Authorization: `Bearer ${token}` } } : {};

    this.http.post<any>(`${environment.apiUrl}/planes`, this.plane, headers).subscribe({
      next: (planeId) => {
        if (this.selectedFiles.length > 0) {
          this.uploadImages(planeId);
        } else {
          console.log('Plane created without images');
        }
      },
      error: (error) => console.error('Error creating plane:', error),
    });
  }

  uploadImages(planeId: string) {
    const token = localStorage.getItem('auth_token');
    const uploadUrl = `${environment.apiUrl}/planes/${planeId}/upload-image`;

    this.selectedFiles.forEach((file) => {
      const formData = new FormData();
      formData.append('file', file);

      this.http.post(uploadUrl, formData, {
        headers: token ? { Authorization: `Bearer ${token}` } : {},
      }).subscribe({
        next: () => console.log(`Image uploaded for plane ${planeId}`),
        error: (error) => console.error('Error uploading image:', error),
      });
    });
  }
}
