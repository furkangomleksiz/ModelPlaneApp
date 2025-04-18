import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { QuickSearchComponent } from './pages/quick-search/quick-search.component';
import { AdvancedSearchComponent } from './pages/advanced-search/advanced-search.component';
import { PlaneDetailsComponent } from './pages/plane-details/plane-details.component';  // Import the PlaneDetailComponent
import { LoginComponent } from './pages/login/login.component';
import { ModelUploadComponent } from './pages/model-upload/model-upload.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },  // Home page
  { path: 'quick-search', component: QuickSearchComponent },  // Quick Search page
  { path: 'advanced-search', component: AdvancedSearchComponent },  // Advanced Search page
  { path: 'plane-details/:id', component: PlaneDetailsComponent },   // Plane Detail page with ID parameter
  { path: 'login', component: LoginComponent },
  { path: 'model-upload', component: ModelUploadComponent },
];
