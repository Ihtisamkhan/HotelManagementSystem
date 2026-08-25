import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { RoomTypeService } from '../../services/room-type';

@Component({
  selector: 'app-room-types',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './room-types.html',
  styleUrl: './room-types.css'
})
export class RoomTypes implements OnInit {

  roomTypes: any[] = [];

  roomType = {
    name: '',
    description: ''
  };

  selectedId = 0;

  isEdit = false;

  constructor(private roomTypeService: RoomTypeService) { }

  ngOnInit(): void {

    this.loadRoomTypes();

  }

  loadRoomTypes() {

    this.roomTypeService.getAll().subscribe({

      next: (response) => {

        this.roomTypes = response;

      }

    });

  }

  saveRoomType() {

    if (this.isEdit) {

      this.roomTypeService.update(this.selectedId, this.roomType).subscribe({

        next: () => {

          alert("Room Type Updated Successfully");

          this.cancelEdit();

          this.loadRoomTypes();

        }

      });

    }

    else {

      this.roomTypeService.create(this.roomType).subscribe({

        next: () => {

          alert("Room Type Added Successfully");

          this.roomType = {

            name: '',

            description: ''

          };

          this.loadRoomTypes();

        }

      });

    }

  }

  editRoomType(roomType: any) {

    this.selectedId = roomType.roomTypeId;

    this.roomType = {

      name: roomType.name,

      description: roomType.description

    };

    this.isEdit = true;

  }

  deleteRoomType(id: number) {

    if (!confirm("Delete this Room Type?"))
      return;

    this.roomTypeService.delete(id).subscribe({

      next: () => {

        alert("Deleted Successfully");

        this.loadRoomTypes();

      }

    });

  }

  cancelEdit() {

    this.isEdit = false;

    this.selectedId = 0;

    this.roomType = {

      name: '',

      description: ''

    };

  }

}