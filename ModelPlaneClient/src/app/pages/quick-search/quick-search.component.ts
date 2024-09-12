import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

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

  aircrafts = [
    'Cessna 172',
    'A300',
    'A318',
    'A319',
    'A320',
    'A321',
    'A330',
    'A340',
    'A350',
    'A380',
    'B707',
    'B727',
    'B737',
    'B747',
    'B757',
    'B767',
    'B777',
    'B787',
    'DC-10',
    'L1011',
    'CRJ',
    'VC-10'
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
    aircraft: '',
    manufacturer: '',
    scale: '',
    partNumber: '',
    modelId: ''
  };

  // Holds the results of the search
  searchResults: any[] = [];

  constructor(private http: HttpClient) {}

  // Trigger search logic
  onSearch() {
    console.log('Search criteria:', this.searchCriteria);

    // Call API to search database with this.searchCriteria
    this.http.post<any[]>('/api/planes/search', this.searchCriteria).subscribe(result => {
      this.searchResults = result;
      console.log('Search result:', this.searchResults);
    });
  }
}
