import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProfileService } from '../../services/profile';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './profile.html',
  styleUrl: './profile.css'
})
export class Profile implements OnInit {

  profile: any = {

    fullName: '',
    email: '',
    phoneNumber: '',
    username: ''

  };

  constructor(
    private profileService: ProfileService
  ) { }

  ngOnInit(): void {

    this.loadProfile();

  }

  loadProfile() {

    this.profileService.getProfile().subscribe({

      next: (response) => {

        this.profile = response;

      },

      error: (err) => {

        console.log(err);

      }

    });

  }

  updateProfile() {

    this.profileService.updateProfile(this.profile).subscribe({

      next: () => {

        alert('Profile Updated Successfully');

      },

      error: (err) => {

        alert(err.error?.message || 'Update Failed');

      }

    });

  }

}
