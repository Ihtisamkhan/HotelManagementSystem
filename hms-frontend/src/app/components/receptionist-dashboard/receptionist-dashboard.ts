import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';

import { RoomService } from '../../services/room';

@Component({
  selector: 'app-receptionist-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule 
  ],
  templateUrl: './receptionist-dashboard.html',
  styleUrl: './receptionist-dashboard.css'
})
export class ReceptionistDashboard implements OnInit {

  // All rooms received from backend
  rooms: any[] = [];

  // Rooms after search/filter
  filteredRooms: any[] = [];

  // Search text
  searchText: string = '';

  // Selected status
  selectedStatus: string = 'All';

  constructor(private roomService: RoomService, private cdRef: ChangeDetectorRef ) {}

  ngOnInit(): void {
    this.loadRooms();
  }

  // Get rooms from backend
  loadRooms(): void {

    this.roomService.getAll().subscribe({

      next: (response) => {

        console.log('Rooms received:', response);

        this.rooms = response;
        this.filteredRooms = response;
        this.cdRef.detectChanges();

      },

      error: (error) => {

        console.error('Error loading rooms:', error);

      }

    });

  }

  // Search and filter rooms
  filterRooms(): void {

    const search = this.searchText.trim().toLowerCase();

    this.filteredRooms = this.rooms.filter(room => {

      // Search by room number, room type or floor
      const matchesSearch =
        room.roomNumber?.toLowerCase().includes(search) ||
        room.roomTypeName?.toLowerCase().includes(search) ||
        room.floor?.toLowerCase().includes(search);

      // Filter by status
      const matchesStatus =
        this.selectedStatus === 'All' ||
        this.getStatus(room.status) === this.selectedStatus;

      return matchesSearch && matchesStatus;

    });

  }

  // Convert backend enum number into readable status
  getStatus(status: number): string {

    switch (status) {

      case 0:
        return 'Available';

      case 1:
        return 'Occupied';

      case 2:
        return 'Cleaning';

      case 3:
        return 'Maintenance';

      default:
        return 'Unknown';

    }

  }

}