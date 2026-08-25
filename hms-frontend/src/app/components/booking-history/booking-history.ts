import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-booking-history',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './booking-history.html'
})
export class BookingHistory implements OnInit {

  bookings: any[] = [];

  constructor(
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {

    this.loadBookings();

  }

  loadBookings() {

    this.bookingService.getBookingHistory().subscribe({

      next: (res: any) => {

        this.bookings = res;

        this.cdr.detectChanges();

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

  checkIn(id: number) {

    if (!confirm("Check In this customer?"))
      return;

    this.bookingService.checkInBooking(id).subscribe({

      next: () => {

        alert("Customer Checked In");

        this.loadBookings();

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

  checkOut(id:number){

  if(!confirm("Check Out this customer?"))
      return;

  this.bookingService.checkOutBooking(id).subscribe({

    next:()=>{

      alert("Customer Checked Out");

      this.loadBookings();

    },

    error:(err)=>{

      console.log(err);

    }

  });

}

}