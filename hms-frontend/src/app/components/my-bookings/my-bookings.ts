import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-my-bookings',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './my-bookings.html',
  styleUrl: './my-bookings.css'
})
export class MyBookings implements OnInit {

  bookings: any[] = [];

  constructor(
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings() {

    this.bookingService.getMyBookings().subscribe({

      next: (response) => {

        console.log(response);

        this.bookings = response;

        this.cdr.detectChanges();

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

  // Customer Check-In
  checkIn(bookingId: number) {

    this.bookingService.checkIn(bookingId).subscribe({

      next: () => {

        alert("Checked In Successfully.");

        this.loadBookings();

      },

      error: (err) => {

           alert(err.error.message);

      }

    });

  }

  // Customer Check-Out
  checkOut(bookingId: number) {

    this.bookingService.checkOut(bookingId).subscribe({

      next: () => {

        alert("Checked Out Successfully.");

        this.loadBookings();

      },

      error: (err) => {

           alert(err.error.message);

      }

    });

  }

  getStatus(status: number): string {

    switch (status) {

      case 0:
        return 'Pending';

      case 1:
        return 'Accepted';

      case 2:
        return 'Rejected';

      case 3:
        return 'Checked In';

      case 4:
        return 'Checked Out';

      default:
        return 'Unknown';

    }

  }

}