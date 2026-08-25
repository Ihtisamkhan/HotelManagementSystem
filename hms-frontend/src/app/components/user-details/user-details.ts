import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-user-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-details.html',
  styleUrl: './user-details.css'
})
export class UserDetails implements OnInit {

  users: any[] = [];

  role: string = '';

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

    this.route.params.subscribe(params => {

      this.role = params['role'];

      this.authService.getUsersByRole(this.role).subscribe({

        next: (res: any) => {

          this.users = res;
          this.cdr.detectChanges();

        },

        error: (err) => {

          console.log(err);

        }

      });

    });

  }

}