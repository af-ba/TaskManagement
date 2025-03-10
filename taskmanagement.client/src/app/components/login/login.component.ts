import { Component, OnInit } from '@angular/core';
import { SocialAuthService, GoogleLoginProvider } from '@abacritt/angularx-social-login';
import { UserRegistrationService } from '../../service/user-registration-service'
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  constructor(private authService: SocialAuthService, private userRegistrationService: UserRegistrationService, private router: Router) { }
  ngOnInit() {
    //this.authService.authState.subscribe((user) => {
    //  if (user) {
    //    this.userRegistrationService.registerUser().pipe().subscribe(x => {
    //    });
    //  }
    //});
  }

  getAccessToken(): void {
    this.authService.getAccessToken(GoogleLoginProvider.PROVIDER_ID).then(accessToken => {
    });
  }

  signIn() {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  refreshToken(): void {
    this.authService.refreshAuthToken(GoogleLoginProvider.PROVIDER_ID);
  }

}
