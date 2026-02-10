import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

export interface CarCardData {
  name: string;
  type: string;
  pricePerDay: number;
  seats: number;
  transmission: string;
  fuel: string;
  imageUrl: string;
  liked?: boolean;
}

@Component({
  selector: 'app-car-card',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule, MatIconModule],
  templateUrl: './car-card.component.html',
  styleUrl: './car-card.component.scss'
})
export class CarCardComponent {
  @Input() car!: CarCardData;
  @Output() rentNow = new EventEmitter<CarCardData>();
  @Output() toggleLike = new EventEmitter<CarCardData>();

  onRent(): void {
    this.rentNow.emit(this.car);
  }

  onLike(): void {
    this.car.liked = !this.car.liked;
    this.toggleLike.emit(this.car);
  }
}
