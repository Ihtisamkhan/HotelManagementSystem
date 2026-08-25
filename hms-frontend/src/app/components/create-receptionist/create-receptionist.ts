import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-create-receptionist',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './create-receptionist.html',
  styleUrl: './create-receptionist.css'
})
export class CreateReceptionist {

  receptionist = {

    fullName: '',

    username: '',

    email: '',

    phoneNumber: '',

    password: '',

    role: 'Receptionist'

  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  createReceptionist() {

    this.authService.createEmployee(this.receptionist).subscribe({

      next: () => {

        alert('Receptionist Created Successfully');

        this.router.navigate(['/manager-dashboard']);

      },

      error: (err) => {

        alert(err.error?.message || 'Failed to create receptionist');

      }

    });

  }

}
