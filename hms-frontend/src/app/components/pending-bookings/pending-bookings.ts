import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-pending-bookings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pending-bookings.html',
  styleUrl: './pending-bookings.css'
})
export class PendingBookings implements OnInit {

  bookings:any[]=[];

  constructor(private bookingService:BookingService,
     private cdr: ChangeDetectorRef
  ){}

  

  ngOnInit(): void {

  console.log("PendingBookings Component Loaded");

  this.loadBookings();

}

 loadBookings() {

  this.bookingService.getPendingBookings().subscribe({

    next: (response) => {

      console.log("Pending Response:", response);

      this.bookings = response;

      this.cdr.detectChanges();

      console.log("Bookings:", this.bookings);

    },

    error: (err) => {

      console.error("Pending Error:", err);

    }

  });

}

  accept(id:number){

    if(!confirm("Accept this booking?"))
      return;

    this.bookingService.acceptBooking(id).subscribe({

      next:()=>{

        alert("Booking Accepted");

        this.loadBookings();

      }

    });

  }

  reject(id:number){

    if(!confirm("Reject this booking?"))
      return;

    this.bookingService.rejectBooking(id).subscribe({

      next:()=>{

        alert("Booking Rejected");

        this.loadBookings();

      }

    });

  }

}
