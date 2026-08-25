import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

import { DashboardService } from '../../services/dashboard';

@Component({
  selector: 'app-owner-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './owner-dashboard.html',
  styleUrl: './owner-dashboard.css'
})
export class OwnerDashboard implements OnInit {

  dashboard: any = {};

  constructor(private dashboardService: DashboardService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {

    this.loadDashboard();

  }

 loadDashboard() {

  console.log("Loading Dashboard");

  this.dashboardService.getOwnerDashboard().subscribe({

    next: (response) => {

      console.log("Dashboard Response:", response);

      this.dashboard = response;

        this.cdr.detectChanges();

    },

    error: (err) => {

      console.error(err);

    }

  });

}

}
