import { Component } from '@angular/core';
import { CommonModule  } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  loginData = {
    username: '',
    password: ''
  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  
  login() {

  this.authService.login(this.loginData).subscribe({

    next: (response) => {

      this.authService.saveUser(response);

      const role = response.role?.trim();

      switch (role) {

        case 'Owner':
          this.router.navigate(['/owner-dashboard']);
          break;

        case 'Manager':
          this.router.navigate(['/manager-dashboard']);
          break;

        case 'Receptionist':
          this.router.navigate(['/receptionist-dashboard']);
          break;

        case 'Staff':
          this.router.navigate(['/staff-dashboard']);
          break;

        case 'Customer':
          this.router.navigate(['/']);
          break;

        default:
          alert('Invalid Role');
          this.authService.logout();
      }

    },

    error: (err) => {

      alert(err.error?.message || 'Login Failed');

    }

  });

}

}