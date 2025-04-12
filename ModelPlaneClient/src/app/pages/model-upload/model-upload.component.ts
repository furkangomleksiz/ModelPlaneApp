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

  success = false;
  uploadedPlane: any = null;
  uploadedImageUrl: string = '';
  isSubmitting = false;


  constructor(private http: HttpClient) { }

  onFileSelected(event: any) {
    this.selectedFiles = Array.from(event.target.files);
  }

  onSubmit() {
    if (this.isSubmitting) return;  // prevent double submits
  
    this.isSubmitting = true;
    const token = localStorage.getItem('auth_token');
    const headers = token ? { headers: { Authorization: `Bearer ${token}` } } : {};
  
    this.http.post<any>(`${environment.apiUrl}/planes`, this.plane, headers).subscribe({
      next: (planeId) => {
        this.uploadedPlane = { ...this.plane, id: planeId };
        if (this.selectedFiles.length > 0) {
          this.uploadImages(planeId);
        } else {
          this.success = true;
          this.resetForm();
          this.isSubmitting = false;
        }
      },
      error: (error) => {
        console.error('Error creating plane:', error);
        this.isSubmitting = false;
      }
    });
  }
  
  uploadImages(planeId: string) {
    const token = localStorage.getItem('auth_token');
    const uploadUrl = `${environment.apiUrl}/planes/${planeId}/upload-image`;
  
    const formData = new FormData();
    formData.append('file', this.selectedFiles[0]);
  
    this.http.post<any>(uploadUrl, formData, {
      headers: token ? { Authorization: `Bearer ${token}` } : {},
    }).subscribe({
      next: (res) => {
        this.uploadedImageUrl = res.url;
        this.success = true;
        this.resetForm();
        this.isSubmitting = false;
      },
      error: (error) => {
        console.error('Error uploading image:', error);
        this.isSubmitting = false;
      }
    });
  }

  resetForm() {
    this.plane = {
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
    this.selectedFiles = [];
  }

}
