import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment';


@Component({
  selector: 'app-quick-search',
  templateUrl: './quick-search.component.html',
  styleUrls: ['./quick-search.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class QuickSearchComponent {

  // Updated dropdown options from enums
  airlines = [
    'Belgian Air Force',
    'Martinair Holland',
    'American Airlines',
    'Delta Air Lines',
    'Lufthansa',
    'British Airways',
    'Emirates',
    'Qatar Airways',
    'Singapore Airlines'
  ];

  models = [
    'Airbus Industries A400M',
    'Boeing 747-400',
    'Embraer E190',
    'Cessna 172',
    'Airbus A320',
    'Boeing 737-800',
    'Airbus A350',
    'Airbus A380',
    'Boeing 777-300ER',
    'Boeing 787-9 Dreamliner',
    'Lockheed C-130 Hercules',
    'McDonnell Douglas DC-10',
    'Antonov An-225 Mriya'
  ];

  manufacturers = [
    'Admiral Toys',
    'Herpa',
    'Gemini Jets',
    'Dragon Wings',
    'Phoenix Models',
    'AeroClassics',
    'JC Wings',
    'Hogan Wings'
  ];

  scales = [
    '1:87',  // OneEightySeven
    '1:200', // TwoHundred
    '1:400', // FourHundred
    '1:500', // FiveHundred
    '1:600'  // SixHundred
  ];

  // Search criteria model
  searchCriteria = {
    airline: '',
    model: '',         // Updated from aircraft to model
    manufacturer: '',
    scale: '',
    partNumber: '',
    wings900Id: ''
  };


  // Holds the results of the search
  searchResults: any[] = [];

  constructor(private http: HttpClient) { }

  
  // Trigger search logic
onSearch() {
  const params = new URLSearchParams();

  // Add selected values directly as they are strings
  if (this.searchCriteria.manufacturer) params.append('manufacturer', this.searchCriteria.manufacturer);
  if (this.searchCriteria.airline) params.append('airline', this.searchCriteria.airline);
  if (this.searchCriteria.model) params.append('model', this.searchCriteria.model);  // Changed from aircraft to model
  if (this.searchCriteria.scale) params.append('scale', this.searchCriteria.scale);

  if (this.searchCriteria.partNumber) {
    params.append('partNumber', this.searchCriteria.partNumber);
  }

  if (this.searchCriteria.wings900Id) {
    params.append('modelId', this.searchCriteria.wings900Id);  // Ensure this refers to Wings900Id
  }

  // Make HTTP GET request with the search criteria
  this.http.get<any[]>(`${environment.apiUrl}/planes/search?` + params.toString()).subscribe(
    result => {
      this.searchResults = result;
      console.log('Search result:', this.searchResults);
    },
    error => {
      console.error('Error during search:', error);
      alert('An error occurred while performing the search.');
    }
  );
}

}
