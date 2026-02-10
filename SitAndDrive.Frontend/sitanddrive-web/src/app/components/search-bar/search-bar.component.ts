import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
  ],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.scss'
})
export class SearchBarComponent {
  pickUpLocation = '';
  pickUpDate = '';
  pickUpTime = '';
  dropOffLocation = '';
  dropOffDate = '';
  dropOffTime = '';

  locations = ['Sarajevo', 'Mostar', 'Tuzla', 'Zenica', 'Banja Luka', 'Bihac'];
  times = ['08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00'];

  onSearch(): void {
    console.log('Search:', {
      pickUp: { location: this.pickUpLocation, date: this.pickUpDate, time: this.pickUpTime },
      dropOff: { location: this.dropOffLocation, date: this.dropOffDate, time: this.dropOffTime }
    });
  }
}
