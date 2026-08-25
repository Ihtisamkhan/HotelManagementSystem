import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-create-manager',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './create-manager.html',
  styleUrl: './create-manager.css'
})
export class CreateManager {

  manager = {

    fullName: '',

    username: '',

    email: '',

    phoneNumber: '',

    password: '',

    role: 'Manager'

  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  createManager() {
    this.authService.createEmployee(this.manager).subscribe({

  next: () => {

    alert('Manager Created Successfully');

    this.router.navigate(['/owner-dashboard']);

  },

  error: (err) => {

    alert(err.error?.message || 'Failed to create manager');

  }

});
  }

}
