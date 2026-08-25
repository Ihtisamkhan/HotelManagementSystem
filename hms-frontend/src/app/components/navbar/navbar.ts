import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class Navbar implements OnInit {

  loggedIn = false;

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.authService.loggedIn$.subscribe(x => {

      this.loggedIn = x;

    });

  }

  getRole(): string {

    return localStorage.getItem('role') || '';

  }

  logout() {

    this.authService.logout();

    this.router.navigate(['/login']);

  }

}