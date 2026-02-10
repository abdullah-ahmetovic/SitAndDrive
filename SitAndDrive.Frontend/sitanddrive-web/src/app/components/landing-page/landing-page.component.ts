import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { HeroSectionComponent } from '../hero-section/hero-section.component';
import { SearchBarComponent } from '../search-bar/search-bar.component';
import { CarCardComponent, CarCardData } from '../car-card/car-card.component';
import { FooterComponent } from '../footer/footer.component';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatButtonModule,
    HeroSectionComponent,
    SearchBarComponent,
    CarCardComponent,
    FooterComponent,
  ],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent {
  popularCarsLimit = 8;
  recommendedCarsLimit = 8;

  popularCars: CarCardData[] = [
    { name: 'Koenigsegg', type: 'Sport', pricePerDay: 99.00, seats: 2, transmission: 'Manual', fuel: '90L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Koenigsegg', liked: true },
    { name: 'Nissan GT-R', type: 'Sport', pricePerDay: 80.00, seats: 2, transmission: 'Manual', fuel: '80L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Nissan+GT-R' },
    { name: 'Rolls-Royce', type: 'Sedan', pricePerDay: 96.00, seats: 4, transmission: 'Manual', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Rolls-Royce', liked: true },
    { name: 'All New Rush', type: 'SUV', pricePerDay: 72.00, seats: 6, transmission: 'Manual', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=All+New+Rush' },
    { name: 'CR-V', type: 'SUV', pricePerDay: 80.00, seats: 6, transmission: 'Manual', fuel: '80L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=CR-V' },
    { name: 'All New Terios', type: 'SUV', pricePerDay: 74.00, seats: 6, transmission: 'Manual', fuel: '90L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=All+New+Terios' },
    { name: 'MG ZX Exclusive', type: 'Hatchback', pricePerDay: 76.00, seats: 4, transmission: 'Automatic', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=MG+ZX' },
    { name: 'New MG ZS', type: 'SUV', pricePerDay: 80.00, seats: 6, transmission: 'Manual', fuel: '80L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=New+MG+ZS' },
  ];

  recommendedCars: CarCardData[] = [
    { name: 'All New Rush', type: 'SUV', pricePerDay: 72.00, seats: 6, transmission: 'Manual', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=All+New+Rush' },
    { name: 'CR-V', type: 'SUV', pricePerDay: 80.00, seats: 6, transmission: 'Manual', fuel: '80L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=CR-V', liked: true },
    { name: 'MG ZX Excite', type: 'Hatchback', pricePerDay: 74.00, seats: 4, transmission: 'Automatic', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=MG+ZX+Excite' },
    { name: 'New MG ZS', type: 'SUV', pricePerDay: 80.00, seats: 6, transmission: 'Manual', fuel: '80L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=New+MG+ZS' },
    { name: 'MG ZX Exclusive', type: 'Hatchback', pricePerDay: 76.00, seats: 4, transmission: 'Automatic', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=MG+ZX+Exclusive' },
    { name: 'Nissan GT-R', type: 'Sport', pricePerDay: 80.00, seats: 2, transmission: 'Manual', fuel: '80L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Nissan+GT-R' },
    { name: 'Koenigsegg', type: 'Sport', pricePerDay: 99.00, seats: 2, transmission: 'Manual', fuel: '90L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Koenigsegg' },
    { name: 'Rolls-Royce', type: 'Sedan', pricePerDay: 96.00, seats: 4, transmission: 'Manual', fuel: '70L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Rolls-Royce' },
    { name: 'All New Terios', type: 'SUV', pricePerDay: 74.00, seats: 6, transmission: 'Manual', fuel: '90L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=All+New+Terios' },
    { name: 'BMW 3 Series', type: 'Sedan', pricePerDay: 85.00, seats: 4, transmission: 'Automatic', fuel: '60L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=BMW+3+Series' },
    { name: 'Mercedes C-Class', type: 'Sedan', pricePerDay: 90.00, seats: 4, transmission: 'Automatic', fuel: '65L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Mercedes+C' },
    { name: 'Audi A4', type: 'Sedan', pricePerDay: 88.00, seats: 4, transmission: 'Automatic', fuel: '55L', imageUrl: 'https://placehold.co/300x140/f6f7f9/1a202c?text=Audi+A4' },
  ];

  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  get visiblePopular(): CarCardData[] {
    return this.popularCars.slice(0, this.popularCarsLimit);
  }

  get visibleRecommended(): CarCardData[] {
    return this.recommendedCars.slice(0, this.recommendedCarsLimit);
  }

  onRentNow(car: CarCardData): void {
    if (this.auth.isLoggedIn()) {
      this.router.navigate(['/cars']);
    } else {
      this.router.navigate(['/login']);
    }
  }

  showMoreCars(): void {
    this.recommendedCarsLimit += 4;
  }
}
