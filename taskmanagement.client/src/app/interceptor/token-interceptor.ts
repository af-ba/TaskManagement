import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, switchMap } from 'rxjs';
import { SocialAuthService } from '@abacritt/angularx-social-login';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private authService: SocialAuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return this.authService.authState.pipe(switchMap
      (x => {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${x.idToken}`
          }
        });

        return next.handle(request);
      }
      ))
  }
}
