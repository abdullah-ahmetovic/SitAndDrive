import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { HeroSectionComponent } from '../hero-section/hero-section.component';
import { SearchBarComponent } from '../search-bar/search-bar.component';
import { CarCardComponent } from '../car-card/car-card.component';
import { FooterComponent } from '../footer/footer.component';
import { AuthService } from '../../services/auth.service';
import { CarService } from '../../services/car.service';
import { CarListItem } from '../../models/car.model';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatIconModule,
    HeroSectionComponent,
    SearchBarComponent,
    CarCardComponent,
    FooterComponent,
  ],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent implements OnInit {
  cars: CarListItem[] = [];
  loading = true;
  error = '';

  constructor(
    private auth: AuthService,
    private carService: CarService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadCars();
  }

  loadCars(): void {
    this.loading = true;
    this.error = '';
    this.carService.getCars(1, 8).subscribe({
      next: (result) => {
        this.cars = result.items;
        this.loading = false;
      },
      error: () => {
        this.error = 'Greska pri ucitavanju automobila. Pokusajte ponovo.';
        this.loading = false;
      }
    });
  }

  onRentNow(car: CarListItem): void {
    if (this.auth.isLoggedIn()) {
      this.router.navigate(['/cars']);
    } else {
      this.router.navigate(['/login']);
    }
  }
}
