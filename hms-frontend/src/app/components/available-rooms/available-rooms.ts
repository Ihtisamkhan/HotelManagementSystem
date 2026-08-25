import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { RoomService } from '../../services/room';

@Component({
  selector: 'app-available-rooms',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './available-rooms.html'
})
export class AvailableRooms implements OnInit {

  rooms:any[]=[];

  constructor(
    private roomService:RoomService,
    private cdRef: ChangeDetectorRef
  ){}

  ngOnInit(): void {

    this.loadRooms();

  }

  loadRooms(){

    this.roomService.getRoomsByStatus(0).subscribe({

      next:(res)=>{

        this.rooms=res;
        this.cdRef.detectChanges();

      },

      error:(err)=>{

        console.log(err);

      }

    });

  }

}
