import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-owner-accepted-bookings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './owner-accepted-bookings.html',
  styleUrl: './owner-accepted-bookings.css'
})
export class OwnerAcceptedBookings implements OnInit {

  bookings: any[] = [];

  constructor(
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

    this.loadBookings();

  }

  loadBookings() {

    this.bookingService.getAcceptedBookings().subscribe({

      next: (res: any) => {

        this.bookings = res;

        this.cdr.detectChanges();

      },

      error: (err) => {

        alert(err.error.message);
      }

    });

  }

}