import { GoogleLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { UserRegistrationService } from './service/user-registration-service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {



  isUserConnected: boolean = false;
  accessToken = '';
  constructor(private authService: SocialAuthService, private userRegistrationService: UserRegistrationService,
    private router: Router) { }

  ngOnInit() {
    this.authService.authState.subscribe((user) => {
      if (user) {
        this.isUserConnected = true;
        this.userRegistrationService.registerUser().pipe().subscribe(x => {
        });
      }
    });

  }


 
}
