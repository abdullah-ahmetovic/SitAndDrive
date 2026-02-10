import { Routes } from '@angular/router';
import { CarListComponent } from './components/car-list/car-list.component';
import { CarFormComponent } from './components/car-form/car-form.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'login', component: LoginPageComponent },
  { path: '', redirectTo: 'cars', pathMatch: 'full' },
  { path: 'cars', component: CarListComponent, canActivate: [authGuard] },
  { path: 'cars/new', component: CarFormComponent, canActivate: [authGuard] },
  { path: 'cars/edit/:id', component: CarFormComponent, canActivate: [authGuard] },
];
