import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-booking-overview',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './booking-overview.html',
  styleUrl: './booking-overview.css'
})
export class BookingOverview implements OnInit {

  bookings: any[] = [];

  constructor(
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings() {

    this.bookingService.getAllBookings().subscribe({

      next: (response: any) => {

        this.bookings = response;

        this.cdr.detectChanges();

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

  getStatus(status: number): string {

    switch (status) {

      case 0: return 'Pending';
      case 1: return 'Accepted';
      case 2: return 'Rejected';
      case 3: return 'Checked In';
      case 4: return 'Checked Out';
      default: return 'Unknown';

    }

  }

}