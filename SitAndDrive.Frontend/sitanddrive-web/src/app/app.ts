import { Component, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  protected readonly title = signal('sitanddrive-web');

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    console.log('Angular started ✅');

    // Test 1: probaj povući listu auta
    //this.api.getCars().subscribe({
    //  next: (res) => console.log('Cars response ✅', res),
    //  error: (err) => console.error('Cars error ❌', err)
    //});
  }
}