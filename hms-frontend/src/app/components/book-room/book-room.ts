import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { RoomService } from '../../services/room';
import { BookingService } from '../../services/booking';

@Component({
  selector: 'app-book-room',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './book-room.html',
  styleUrl: './book-room.css'
})
export class BookRoom implements OnInit {

  room: any;

  booking = {

    roomId: 0,

    checkInDate: '',

    checkOutDate: ''

  };

  constructor(

    private route: ActivatedRoute,

    private router: Router,

    private roomService: RoomService,

    private bookingService: BookingService

  ) { }

  ngOnInit(): void {

    const roomId = Number(this.route.snapshot.paramMap.get('id'));

    this.booking.roomId = roomId;

    this.roomService.getById(roomId).subscribe({

      next: (response) => {

        this.room = response;

      }

    });

  }

  bookRoom() {

    this.bookingService.createBooking(this.booking).subscribe({

      next: () => {

        alert("Room booked successfully.");

        this.router.navigate(['/my-bookings']);

      },

      error: (err) => {

        console.log(err);

           alert(err.error.message);

      }

    });

  }

}