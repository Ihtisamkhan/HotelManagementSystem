import { Component } from '@angular/core';
import { AuthService } from '../../services/auth';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-create-staff',
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './create-staff.html',
  styleUrl: './create-staff.css',
})
export class CreateStaff {

   staff = {

    fullName: '',

    username: '',

    email: '',

    phoneNumber: '',

    password: '',

    role: 'Staff'

  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  createStaff() {

    this.authService.createEmployee(this.staff).subscribe({

      next: () => {

        alert('Staff Created Successfully');

        this.router.navigate(['/manager-dashboard']);

      },

      error: (err) => {

        alert(err.error?.message || 'Failed to create staff');

      }

    });

  }
}
