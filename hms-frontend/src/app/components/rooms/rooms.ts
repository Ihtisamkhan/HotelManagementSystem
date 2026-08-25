import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

import { RoomService } from '../../services/room';

@Component({
  selector: 'app-rooms',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './rooms.html',
  styleUrl: './rooms.css'
})
export class Rooms implements OnInit {

  rooms: any[] = [];

  constructor(private roomService: RoomService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.loadRooms();
  }

 loadRooms() {

  this.roomService.getAll().subscribe({

    next: (response) => {

      console.log("API Response:", response);
      console.log("Length:", response.length);

      this.rooms = response;
      this.cdr.detectChanges();

      console.log("Rooms Variable:", this.rooms);

    },

    error: (err) => {

      console.error(err);

    }

  });

}

  getStatus(status: number): string {

    switch (status) {

      case 0:
        return 'Available';

      case 1:
        return 'Occupied';

      case 2:
        return 'Maintenance';

      default:
        return 'Unknown';

    }

  }

  getRoomImage(roomTypeName: string): string {

  switch (roomTypeName.trim().toLowerCase()) {

    case 'deluxe':
      return 'assets/images/rooms/deluxe.jpg';

    case 'standard':
      return 'assets/images/rooms/standard.jpg';

    case 'suite':
      return 'assets/images/rooms/suite.jpg';

    case 'family':
      return 'assets/images/rooms/family.jpg';

    default:
      return 'assets/images/rooms/default-room.jpg';
  }

}
}