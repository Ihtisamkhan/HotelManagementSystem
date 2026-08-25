import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

import { StaffTaskService } from '../../services/staff-task';

@Component({
  selector: 'app-task-status',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task-status.html',
  styleUrl: './task-status.css'
})
export class TaskStatus implements OnInit {

  tasks: any[] = [];

  constructor(private taskService: StaffTaskService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTaskStatus().subscribe({
      next: (res) => {
        this.tasks = res;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

}
