import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {
  private apiUrl = 'https://localhost:7228/UserRegistration';

  constructor(private http: HttpClient) { }

  registerUser(): Observable<string> {
    return this.http.post<string>(this.apiUrl, null);
  }




}
