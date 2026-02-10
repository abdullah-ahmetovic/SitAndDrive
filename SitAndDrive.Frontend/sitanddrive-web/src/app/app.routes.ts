import { Routes } from '@angular/router';
import { CarListComponent } from './components/car-list/car-list.component';
import { CarFormComponent } from './components/car-form/car-form.component';

export const routes: Routes = [
  { path: '', redirectTo: 'cars', pathMatch: 'full' },
  { path: 'cars', component: CarListComponent },
  { path: 'cars/new', component: CarFormComponent },
  { path: 'cars/edit/:id', component: CarFormComponent },
];
