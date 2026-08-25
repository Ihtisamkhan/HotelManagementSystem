import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StaffTaskService } from '../../services/staff-task';

@Component({
  selector: 'app-my-tasks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './my-tasks.html'
})
export class MyTasks implements OnInit {

  tasks:any[]=[];

  constructor(
    private taskService:StaffTaskService,
    private cdr:ChangeDetectorRef
  ){}

  ngOnInit(): void {

    this.loadTasks();

  }

  loadTasks(){

    this.taskService.getMyTasks().subscribe({

      next:(res)=>{

        this.tasks=res;

        this.cdr.detectChanges();

      },

      error:(err)=>{

        console.log(err);

      }

    });

  }

  completeTask(id:number){

    if(!confirm("Mark this task as completed?"))
      return;

    this.taskService.completeTask(id).subscribe({

      next:()=>{

        alert("Task Completed");

        this.loadTasks();

      },

      error:(err)=>{

        console.log(err);

      }

    });

  }

}
