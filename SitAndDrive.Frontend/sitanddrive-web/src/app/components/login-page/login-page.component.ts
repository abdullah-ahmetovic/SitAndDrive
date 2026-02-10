import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpErrorResponse } from '@angular/common/http';
import { timeout, finalize, catchError } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent {
  form: FormGroup;
  loading = false;
  errorMessage = '';
  hidePassword = true;

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.auth.login(this.form.value).pipe(
      timeout(5000),
      catchError((err: unknown) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
            this.errorMessage = 'Pogresno korisnicko ime ili lozinka.';
          } else if (err.status === 0) {
            this.errorMessage = 'Ne mogu do API-ja (CORS / cert / offline).';
          } else if (err.status >= 500) {
            this.errorMessage = 'Greska na serveru.';
          } else {
            this.errorMessage = `Greska: ${err.status} ${err.statusText}`;
          }
        } else {
          // timeout error from rxjs
          this.errorMessage = 'Server ne odgovara. Provjeri da API radi i pokusaj ponovo.';
        }
        return EMPTY;
      }),
      finalize(() => {
        this.loading = false;
      })
    ).subscribe({
      next: () => {
        this.router.navigate(['/cars']);
      }
    });
  }
}
