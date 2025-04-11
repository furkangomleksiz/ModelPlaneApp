import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-plane-details',
  templateUrl: './plane-details.component.html',
  styleUrls: ['./plane-details.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class PlaneDetailsComponent implements OnInit {
  planeDetails: any;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<any>(`${environment.apiUrl}/planes/${id}`).subscribe(
      (response) => {
        this.planeDetails = response;
      },
      (error) => {
        console.error('Error fetching plane details:', error);
      }
    );
  }





}
