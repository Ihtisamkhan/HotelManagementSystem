import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RoomService } from '../../services/room';
import { RoomTypeService } from '../../services/room-type';

@Component({
  selector: 'app-rooms-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './rooms-management.html',
  styleUrl: './rooms-management.css'
})
export class RoomsManagement implements OnInit {

  rooms: any[] = [];

  roomTypes: any[] = [];

  room = {
    roomNumber: '',
    roomTypeId: '',
    floor: '',
    pricePerNight: 0,
    status: 0,
    roomsize: '',
    imageUrl: '',
    description: ''
  };

  selectedId = 0;

  isEdit = false;

  statuses = [
    { id: 0, name: 'Available' },
    { id: 1, name: 'Occupied' },
    { id: 2, name: 'Maintenance' }
  ];

  constructor(
    private roomService: RoomService,
    private roomTypeService: RoomTypeService
  ) { }

  ngOnInit(): void {

    this.loadRooms();

    this.loadRoomTypes();

  }

  loadRooms() {

    this.roomService.getAll().subscribe({

      next: (response) => {

        console.log("Rooms:", response);

        this.rooms = response;

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

  loadRoomTypes() {

    this.roomTypeService.getAll().subscribe({

      next: (response) => {

        console.log("Room Types:", response);

        this.roomTypes = response;

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

  saveRoom() {

    console.log("Room Object:", this.room);
    console.log("Room Type Id:", this.room.roomTypeId);

    if (this.isEdit) {

      this.roomService.update(this.selectedId, this.room).subscribe({

        next: () => {

          alert("Room Updated Successfully");

          this.cancelEdit();

          this.loadRooms();

        },

        error: (err) => {

          console.error(err);

        }

      });

    }
    else {

      this.roomService.create(this.room).subscribe({

        next: () => {

          alert("Room Created Successfully");

          this.cancelEdit();

          this.loadRooms();

        },

        error: (err) => {

          console.error("Create Error:", err);

          alert(err.error?.Message || err.error?.message || "Error creating room.");

        }

      });

    }

  }

  editRoom(room: any) {

    this.selectedId = room.roomId;

    this.room = {

      roomNumber: room.roomNumber,

      roomTypeId: room.roomTypeId,

      floor: room.floor,

      pricePerNight: room.pricePerNight,

      status: room.status,

      roomsize: room.roomsize,

      imageUrl: room.imageUrl,

      description: room.description

    };

    this.isEdit = true;

  }

  deleteRoom(id: number) {

    if (!confirm("Delete this room?"))
      return;

    this.roomService.delete(id).subscribe({

      next: () => {

        alert("Room Deleted Successfully");

        this.loadRooms();

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

  getStatusName(status: number): string {

    switch (status) {

      case 0:
        return 'Available';

      case 1:
        return 'Occupied';

      case 2:
        return 'Maintenance';

      default:
        return '';

    }

  }

  cancelEdit() {

    this.isEdit = false;

    this.selectedId = 0;

    this.room = {

      roomNumber: '',

      roomTypeId: '',

      floor: '',

      pricePerNight: 0,

      status: 0,

      roomsize: '',

      imageUrl: '',

      description: ''

    };

  }

}