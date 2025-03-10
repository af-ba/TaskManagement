import { GoogleLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { UserRegistrationService } from './service/user-registration-service';
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
    this.getAccessToken();
    if (this.accessToken == '') {
      this.router.navigate(['/login']);
    }
    this.authService.authState.subscribe((user) => {
      if (user) {
        this.router.navigate(['/task-list']);
        this.userRegistrationService.registerUser().pipe().subscribe(); 
      }
    });

  }

  getAccessToken(): void {
    this.authService.getAccessToken(GoogleLoginProvider.PROVIDER_ID).then(accessToken => {
      this.accessToken = accessToken;
    });
  }


 
}
