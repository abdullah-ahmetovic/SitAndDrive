import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CarService } from '../../services/car.service';
import { LookupService } from '../../services/lookup.service';
import {
  CarListItem,
  CarFilter,
  LookupItem,
  CarModelLookup,
  CarTransmission
} from '../../models/car.model';

@Component({
  selector: 'app-car-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatCardModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './car-list.component.html',
  styleUrl: './car-list.component.scss'
})
export class CarListComponent implements OnInit {
  displayedColumns = ['id', 'licensePlate', 'manufacturer', 'model', 'year', 'transmission', 'pricePerDay', 'branch', 'actions'];
  cars: CarListItem[] = [];
  totalItems = 0;
  page = 1;
  pageSize = 10;
  loading = false;

  branches: LookupItem[] = [];
  manufacturers: LookupItem[] = [];
  carModels: CarModelLookup[] = [];

  filter: CarFilter = {};

  constructor(
    private carService: CarService,
    private lookupService: LookupService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadLookups();
    this.loadCars();
  }

  loadLookups(): void {
    this.lookupService.getBranches().subscribe(data => this.branches = data);
    this.lookupService.getManufacturers().subscribe(data => this.manufacturers = data);
    this.lookupService.getCarModels().subscribe(data => this.carModels = data);
  }

  loadCars(): void {
    this.loading = true;
    this.carService.getCars(this.page, this.pageSize, this.filter).subscribe({
      next: (result) => {
        this.cars = result.items;
        this.totalItems = result.totalItems;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  onPageChange(event: PageEvent): void {
    this.page = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadCars();
  }

  onManufacturerFilterChange(): void {
    this.filter.carModelId = null;
    if (this.filter.manufacturerId) {
      this.lookupService.getCarModels(this.filter.manufacturerId).subscribe(data => this.carModels = data);
    } else {
      this.lookupService.getCarModels().subscribe(data => this.carModels = data);
    }
    this.applyFilter();
  }

  applyFilter(): void {
    this.page = 1;
    this.loadCars();
  }

  resetFilter(): void {
    this.filter = {};
    this.page = 1;
    this.lookupService.getCarModels().subscribe(data => this.carModels = data);
    this.loadCars();
  }

  addCar(): void {
    this.router.navigate(['/cars/new']);
  }

  editCar(id: number): void {
    this.router.navigate(['/cars/edit', id]);
  }

  deleteCar(car: CarListItem): void {
    if (confirm(`Da li ste sigurni da zelite obrisati auto ${car.licensePlate}?`)) {
      this.carService.deleteCar(car.id).subscribe({
        next: () => this.loadCars(),
        error: (err) => alert('Greska pri brisanju: ' + (err.error?.message || err.message))
      });
    }
  }

  getTransmissionLabel(t: CarTransmission): string {
    return t === CarTransmission.Automatic ? 'Automatik' : 'Manual';
  }
}
