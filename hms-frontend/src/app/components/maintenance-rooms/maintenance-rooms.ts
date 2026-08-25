import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { RoomService } from '../../services/room';

@Component({
  selector: 'app-maintenance-rooms',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './maintenance-rooms.html'
})
export class MaintenanceRooms implements OnInit {

  rooms: any[] = [];

  constructor(private roomService: RoomService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

    this.loadRooms();

  }

  loadRooms() {

    this.roomService.getRoomsByStatus(3).subscribe({

      next: (res: any) => {

        this.rooms = res;
        this.cdr.detectChanges();

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

}
