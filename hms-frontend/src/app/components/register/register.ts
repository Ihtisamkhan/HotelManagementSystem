import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {

  customer = {

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

    this.authService.registerCustomer(this.customer).subscribe({

      next: (res) => {

        alert('Customer Registered Successfully.');

        this.router.navigate(['/login']);

      },

      error: (err) => {

         alert(err.error.message);

      }

    });

  }

}
