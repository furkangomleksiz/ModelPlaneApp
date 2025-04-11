import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router'; 
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-advanced-search',
  templateUrl: './advanced-search.component.html',
  styleUrls: ['./advanced-search.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule]
})
export class AdvancedSearchComponent {

  // Dropdown options (add more options as needed)
  airlines = ['Belgian Air Force', 'Martinair Holland', 'American Airlines', 'Delta Air Lines'];
  manufacturers = ['AeroClassics', 'Dragon Wings', 'Gemini Jets', 'Herpa', 'Hogan', 'JC Wings', 'Phoenix Models'];
  models = ['A300', 'A310', 'A318', 'A319', 'A320', 'A321', 'A330', 'A340', 'A350', 'A380', 'B707'];
  countries = ['Belgium', 'Germany', 'USA', 'France'];
  continents = ['Europe', 'Asia', 'North America', 'South America', 'Africa', 'Australia'];
  scales = ['1:200', '1:400', '1:500', '1:600'];

  // Search criteria model with explicit types
  searchCriteria: {
    airline: string;
    manufacturer: string;
    model: string;
    country: string;
    continent: string;
    scale: string;
    partNumber: string;
    wings900Id: string,
    registration: string;
    productionYears: string;  // Add productionYears
    rollingGears: boolean | null;
    includesStand: boolean | null;
    sortBy: string;
    order: string;
  } = {
      airline: '',
      manufacturer: '',
      model: '',
      country: '',
      continent: '',
      scale: '',
      partNumber: '',
      wings900Id: '',
      registration: '',
      productionYears: '',  // Initialize productionYears
      rollingGears: null,
      includesStand: null,
      sortBy: '',
      order: ''
    };

  searchResults: any[] = [];

  constructor(private http: HttpClient) { }

  // Trigger search logic
  onSearch() {
    const params = new URLSearchParams();

    // Add parameters based on the form selections
    if (this.searchCriteria.manufacturer) params.append('manufacturer', this.searchCriteria.manufacturer);
    if (this.searchCriteria.airline) params.append('airline', this.searchCriteria.airline);
    if (this.searchCriteria.model) params.append('model', this.searchCriteria.model);
    if (this.searchCriteria.country) params.append('country', this.searchCriteria.country);
    if (this.searchCriteria.continent) params.append('continent', this.searchCriteria.continent);
    if (this.searchCriteria.scale) params.append('scale', this.searchCriteria.scale);
    if (this.searchCriteria.partNumber) params.append('partNumber', this.searchCriteria.partNumber);
    if (this.searchCriteria.wings900Id) params.append('wings900Id', this.searchCriteria.wings900Id);
    if (this.searchCriteria.registration) params.append('registration', this.searchCriteria.registration);
    if (this.searchCriteria.productionYears) params.append('productionYears', this.searchCriteria.productionYears);

    if (this.searchCriteria.rollingGears !== null) {
      params.append('rollingGears', this.searchCriteria.rollingGears.toString());
    }
    if (this.searchCriteria.includesStand !== null) {
      params.append('includesStand', this.searchCriteria.includesStand.toString());
    }

    if (this.searchCriteria.sortBy) params.append('sortBy', this.searchCriteria.sortBy);
    if (this.searchCriteria.order) params.append('order', this.searchCriteria.order);

    // Make the GET request to the API with the search parameters
    this.http.get<any[]>(`${environment.apiUrl}/planes/search?` + params.toString()).subscribe(
      result => {
        this.searchResults = result;
        console.log('Search result:', this.searchResults);
      },
      error => {
        console.error('Error during search:', error);
      }
    );
  }

  // Optional: Reset the form
  onReset() {
    this.searchCriteria = {
      airline: '',
      manufacturer: '',
      model: '',
      country: '',
      continent: '',
      scale: '',
      partNumber: '',
      wings900Id: '',
      registration: '',
      productionYears: '',  // Reset productionYears
      rollingGears: null,
      includesStand: null,
      sortBy: '',
      order: ''
    };

    // Clear the search results
    this.searchResults = [];
  }


  
  
}
