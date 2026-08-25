import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StaffTaskService } from '../../services/staff-task';

@Component({
  selector: 'app-completed-tasks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './completed-tasks.html'
})
export class CompletedTasks implements OnInit {

  tasks: any[] = [];

  constructor(
    private taskService: StaffTaskService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks() {

    this.taskService.getCompletedTasks().subscribe({

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
