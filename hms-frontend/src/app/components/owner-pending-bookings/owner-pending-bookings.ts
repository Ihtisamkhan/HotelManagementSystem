import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-owner-pending-bookings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './owner-pending-bookings.html',
  styleUrl: './owner-pending-bookings.css'
})
export class OwnerPendingBookings implements OnInit {

  bookings:any[]=[];

  constructor(private bookingService:BookingService,
      private cdr: ChangeDetectorRef
  ){}

  ngOnInit(): void {

    this.loadBookings();

  }

  loadBookings(){

    this.bookingService.getBookingsByStatus(0).subscribe({

      next:(res:any)=>{

        this.bookings=res;

        this.cdr.detectChanges();

      },

      error:(err)=>{

        console.log(err);

      }

    });

  }

}