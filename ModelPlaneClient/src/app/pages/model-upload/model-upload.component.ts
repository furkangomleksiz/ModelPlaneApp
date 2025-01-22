import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';



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

  constructor(private http: HttpClient) { }

  onFileSelected(event: any) {
    this.selectedFiles = Array.from(event.target.files);
  }

  onSubmit() {
    // First, submit the plane details
    this.http.post<any>('http://localhost:5005/api/Planes', this.plane).subscribe({
      next: (response) => {
        const planeId = response;
        if (this.selectedFiles.length > 0) {
          this.uploadImages(planeId);
        }
      },
      error: (error) => console.error('Error creating plane:', error)
    });
  }

  uploadImages(planeId: string) {
    const uploadUrl = `http://localhost:5005/api/Planes/${planeId}/upload-image`;
    this.selectedFiles.forEach((file) => {
      const formData = new FormData();
      formData.append('file', file);

      this.http.post(uploadUrl, formData).subscribe({
        next: () => console.log(`Image uploaded for plane ${planeId}`),
        error: (error) => console.error('Error uploading image:', error)
      });
    });
  }
}
