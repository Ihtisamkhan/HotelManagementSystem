import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';


import { StaffTaskService } from '../../services/staff-task';
import { RoomService } from '../../services/room';

@Component({
  selector: 'app-assign-task',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './assign-task.html'
})
export class AssignTask implements OnInit {

  task:any={};

  staffs:any[]=[];

  rooms:any[]=[];

  constructor(
    private taskService:StaffTaskService,
    private roomService:RoomService,
    private cdr: ChangeDetectorRef
  ){}

  ngOnInit(): void {

    this.loadStaff();

    this.loadRooms();

  }

  loadStaff(){

    this.taskService.getStaff().subscribe(res=>{

      this.staffs=res;

      this.cdr.detectChanges();

    });

  }

  loadRooms(){

    this.roomService.getRooms().subscribe(res=>{

      this.rooms=res;

    });

  }

assignTask() {

  console.log("Assign button clicked");

  this.taskService.createTask(this.task).subscribe({

    next: (res) => {

      console.log("NEXT EXECUTED");
      console.log(res);

      alert("Task Assigned Successfully");

      this.task = {};

    },

    error: (err) => {

  console.log("ERROR");
  console.log(err);

  alert(JSON.stringify(err));

},

    complete: () => {

      console.log("REQUEST COMPLETED");

    }

  });

}

}
