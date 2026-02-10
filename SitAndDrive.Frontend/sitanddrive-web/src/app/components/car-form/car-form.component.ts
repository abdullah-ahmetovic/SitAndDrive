import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CarService } from '../../services/car.service';
import { LookupService } from '../../services/lookup.service';
import {
  CarTransmission,
  EntityStatus,
  LookupItem,
  CarModelLookup,
  CreateCarRequest,
  UpdateCarRequest
} from '../../models/car.model';

@Component({
  selector: 'app-car-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './car-form.component.html',
  styleUrl: './car-form.component.scss'
})
export class CarFormComponent implements OnInit {
  form!: FormGroup;
  isEdit = false;
  carId?: number;
  loading = false;
  saving = false;

  branches: LookupItem[] = [];
  manufacturers: LookupItem[] = [];
  carModels: CarModelLookup[] = [];

  transmissions = [
    { value: CarTransmission.Manual, label: 'Manual' },
    { value: CarTransmission.Automatic, label: 'Automatik' }
  ];

  statuses = [
    { value: EntityStatus.Active, label: 'Aktivan' },
    { value: EntityStatus.Inactive, label: 'Neaktivan' }
  ];

  constructor(
    private fb: FormBuilder,
    private carService: CarService,
    private lookupService: LookupService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.loadLookups();

    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.isEdit = true;
      this.carId = +idParam;
      this.loadCar(this.carId);
    }
  }

  initForm(): void {
    this.form = this.fb.group({
      manufacturerId: [null, Validators.required],
      branchId: [null, Validators.required],
      carModelId: [null, Validators.required],
      licensePlate: ['', [Validators.required, Validators.maxLength(20)]],
      vin: ['', [Validators.required, Validators.maxLength(40)]],
      color: ['', [Validators.required, Validators.maxLength(50)]],
      transmission: [CarTransmission.Manual, Validators.required],
      year: [new Date().getFullYear(), [Validators.required, Validators.min(1900), Validators.max(2100)]],
      powerKw: [0, [Validators.required, Validators.min(0)]],
      fuelConsumption: [0, [Validators.required, Validators.min(0)]],
      dailyPrice: [0, [Validators.required, Validators.min(0)]],
      status: [EntityStatus.Active, Validators.required]
    });
  }

  loadLookups(): void {
    this.lookupService.getBranches().subscribe(data => this.branches = data);
    this.lookupService.getManufacturers().subscribe(data => this.manufacturers = data);
    this.lookupService.getCarModels().subscribe(data => this.carModels = data);
  }

  loadCar(id: number): void {
    this.loading = true;
    this.carService.getCarById(id).subscribe({
      next: (car) => {
        this.form.patchValue({
          manufacturerId: car.manufacturerId,
          branchId: car.branchId,
          carModelId: car.carModelId,
          licensePlate: car.licensePlate,
          vin: car.vin,
          color: car.color,
          transmission: car.transmission,
          year: car.year,
          powerKw: car.powerKw,
          fuelConsumption: car.fuelConsumption,
          dailyPrice: car.pricePerDay,
          status: car.status
        });
        // Load car models for selected manufacturer
        if (car.manufacturerId) {
          this.lookupService.getCarModels(car.manufacturerId).subscribe(data => this.carModels = data);
        }
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        alert('Greska pri ucitavanju automobila.');
        this.router.navigate(['/cars']);
      }
    });
  }

  onManufacturerChange(): void {
    const mId = this.form.get('manufacturerId')?.value;
    this.form.get('carModelId')?.setValue(null);
    if (mId) {
      this.lookupService.getCarModels(mId).subscribe(data => this.carModels = data);
    } else {
      this.lookupService.getCarModels().subscribe(data => this.carModels = data);
    }
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.saving = true;
    const formVal = this.form.value;

    if (this.isEdit && this.carId) {
      const request: UpdateCarRequest = {
        manufacturerId: formVal.manufacturerId,
        branchId: formVal.branchId,
        carModelId: formVal.carModelId,
        licensePlate: formVal.licensePlate,
        vin: formVal.vin,
        color: formVal.color,
        transmission: formVal.transmission,
        year: formVal.year,
        powerKw: formVal.powerKw,
        fuelConsumption: formVal.fuelConsumption,
        dailyPrice: formVal.dailyPrice,
        status: formVal.status
      };
      this.carService.updateCar(this.carId, request).subscribe({
        next: () => {
          this.saving = false;
          this.router.navigate(['/cars']);
        },
        error: (err) => {
          this.saving = false;
          alert('Greska: ' + (err.error?.message || err.message));
        }
      });
    } else {
      const request: CreateCarRequest = {
        firmId: 1, // default firm
        manufacturerId: formVal.manufacturerId,
        branchId: formVal.branchId,
        carModelId: formVal.carModelId,
        licensePlate: formVal.licensePlate,
        vin: formVal.vin,
        color: formVal.color,
        transmission: formVal.transmission,
        year: formVal.year,
        powerKw: formVal.powerKw,
        fuelConsumption: formVal.fuelConsumption,
        dailyPrice: formVal.dailyPrice,
        status: formVal.status
      };
      this.carService.createCar(request).subscribe({
        next: () => {
          this.saving = false;
          this.router.navigate(['/cars']);
        },
        error: (err) => {
          this.saving = false;
          alert('Greska: ' + (err.error?.message || err.message));
        }
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/cars']);
  }
}
