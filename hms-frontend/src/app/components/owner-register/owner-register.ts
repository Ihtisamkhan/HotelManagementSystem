import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-owner-register',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './owner-register.html',
  styleUrl: './owner-register.css'
})
export class OwnerRegister {

  owner = {

    fullName: '',

    username: '',

    email: '',

    phoneNumber: '',

    password: '',

    confirmPassword: ''

  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  register() {

    this.authService.registerOwner(this.owner).subscribe({

      next: () => {

        alert('Owner Registered Successfully');

        this.router.navigate(['/login']);

      },

      error: (err) => {

        alert(err.error?.message || 'Registration Failed');

      }

    });

  }

}
