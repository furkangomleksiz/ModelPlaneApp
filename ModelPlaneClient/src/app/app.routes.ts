import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { QuickSearchComponent } from './pages/quick-search/quick-search.component';
import { AdvancedSearchComponent } from './pages/advanced-search/advanced-search.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },  // Home page
  { path: 'quick-search', component: QuickSearchComponent },  // Quick Search page
  { path: 'advanced-search', component: AdvancedSearchComponent }  // Advanced Search page
];
