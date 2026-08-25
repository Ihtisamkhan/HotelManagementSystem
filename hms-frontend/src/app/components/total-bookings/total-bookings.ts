import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-total-bookings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './total-bookings.html',
  styleUrl: './total-bookings.css'
})
export class TotalBookings implements OnInit {

  bookings:any[]=[];

  constructor(
    private bookingService:BookingService,
    private cdr: ChangeDetectorRef
  ){}

  ngOnInit(): void {

    this.loadBookings();

  }

  loadBookings(){

    this.bookingService.getAllBookings().subscribe({

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