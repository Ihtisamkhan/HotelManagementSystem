import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { RoomService } from '../../services/room';

@Component({
  selector: 'app-owner-room-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './owner-room-details.html'
})
export class OwnerRoomDetails implements OnInit {

  rooms:any[]=[];

  constructor(
    private roomService:RoomService,
    private cdr:ChangeDetectorRef
  ){}

  ngOnInit(): void {

    this.loadRooms();

  }

  loadRooms(){

    this.roomService.getRooms().subscribe({

      next:(res)=>{

        this.rooms=res;

        this.cdr.detectChanges();

      },

      error:(err)=>{

        console.log(err);

      }

    });

  }

}