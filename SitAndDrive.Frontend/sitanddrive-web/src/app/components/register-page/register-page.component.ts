import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { AuthService } from '../../services/auth.service';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatStepperModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
  ],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss',
})
export class RegisterPageComponent {
  basicForm: FormGroup;
  securityForm: FormGroup;
  loading = false;
  errorMessage = '';
  successMessage = '';
  hidePassword = true;
  hideConfirm = true;

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {
    this.basicForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });

    this.securityForm = this.fb.group(
      {
        password: ['', [Validators.required, Validators.minLength(8)]],
        confirmPassword: ['', Validators.required],
      },
      { validators: this.passwordMatchValidator }
    );
  }

  private passwordMatchValidator(group: AbstractControl): ValidationErrors | null {
    const password = group.get('password')?.value;
    const confirm = group.get('confirmPassword')?.value;
    if (password && confirm && password !== confirm) {
      return { passwordMismatch: true };
    }
    return null;
  }

  // Password strength
  get passwordValue(): string {
    return this.securityForm.get('password')?.value || '';
  }

  get strengthScore(): number {
    const pw = this.passwordValue;
    if (!pw) return 0;
    let score = 0;
    if (pw.length >= 8) score++;
    if (/[a-z]/.test(pw)) score++;
    if (/[A-Z]/.test(pw)) score++;
    if (/[0-9]/.test(pw)) score++;
    if (/[^a-zA-Z0-9]/.test(pw)) score++;
    return score;
  }

  get strengthPercent(): number {
    return (this.strengthScore / 5) * 100;
  }

  get strengthLabel(): string {
    const s = this.strengthScore;
    if (s <= 2) return 'Slaba';
    if (s <= 3) return 'Srednja';
    return 'Jaka';
  }

  get strengthColor(): string {
    const s = this.strengthScore;
    if (s <= 2) return 'warn';
    if (s <= 3) return 'accent';
    return 'primary';
  }

  get strengthColorHex(): string {
    const s = this.strengthScore;
    if (s <= 2) return '#d32f2f';
    if (s <= 3) return '#ff9800';
    return '#4caf50';
  }

  get hasLength(): boolean { return this.passwordValue.length >= 8; }
  get hasLower(): boolean { return /[a-z]/.test(this.passwordValue); }
  get hasUpper(): boolean { return /[A-Z]/.test(this.passwordValue); }
  get hasDigit(): boolean { return /[0-9]/.test(this.passwordValue); }
  get hasSpecial(): boolean { return /[^a-zA-Z0-9]/.test(this.passwordValue); }

  onSubmit(): void {
    this.loading = true;
    this.errorMessage = '';

    const request = {
      firstName: this.basicForm.value.firstName,
      lastName: this.basicForm.value.lastName,
      email: this.basicForm.value.email,
      password: this.securityForm.value.password,
    };

    this.auth.register(request).pipe(
      finalize(() => {
        this.loading = false;
      })
    ).subscribe({
      next: () => {
        this.successMessage = 'Racun kreiran, prijavi se.';
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 1500);
      },
      error: () => {
        this.errorMessage = 'Greska pri kreiranju racuna. Pokusajte ponovo.';
      }
    });
  }
}
