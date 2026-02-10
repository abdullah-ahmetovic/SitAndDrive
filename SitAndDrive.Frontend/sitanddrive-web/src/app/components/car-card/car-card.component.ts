import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CarListItem, CarTransmission } from '../../models/car.model';

@Component({
  selector: 'app-car-card',
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatIconModule],
  templateUrl: './car-card.component.html',
  styleUrl: './car-card.component.scss'
})
export class CarCardComponent {
  @Input() car!: CarListItem;
  @Input() liked = false;
  @Output() rentNow = new EventEmitter<CarListItem>();
  @Output() toggleLike = new EventEmitter<CarListItem>();

  get displayName(): string {
    return `${this.car.manufacturerName} ${this.car.carModelName}`;
  }

  get transmissionLabel(): string {
    return this.car.transmission === CarTransmission.Automatic ? 'Automatic' : 'Manual';
  }

  get fuelLabel(): string {
    return `${this.car.fuelConsumption}L`;
  }

  get powerLabel(): string {
    return `${this.car.powerKw} kW`;
  }

  onRent(): void {
    this.rentNow.emit(this.car);
  }

  onLike(): void {
    this.liked = !this.liked;
    this.toggleLike.emit(this.car);
  }
}
