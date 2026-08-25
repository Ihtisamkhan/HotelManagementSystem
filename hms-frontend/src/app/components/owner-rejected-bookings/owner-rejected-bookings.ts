import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-owner-rejected-bookings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './owner-rejected-bookings.html',
  styleUrl: './owner-rejected-bookings.css'
})
export class OwnerRejectedBookings implements OnInit {

  bookings: any[] = [];

  constructor(
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

    this.loadBookings();

  }

  loadBookings() {

    this.bookingService.getRejectedBookings().subscribe({

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
