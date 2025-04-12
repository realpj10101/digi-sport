import {inject, Injectable, PLATFORM_ID} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../models/user.model';
import {map, Observable} from 'rxjs';
import {LoggedInUser} from '../models/logged-in-user.model';
import {Login} from '../models/login.model';
import  { isPlatformBrowser} from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  http = inject(HttpClient);
  platformId = inject(PLATFORM_ID);

  register(userInput: User): Observable<LoggedInUser> {
    return this.http.post<LoggedInUser>('http://localhost:5000/api/user/register', userInput);
  }

  login(userInput: Login): Observable<LoggedInUser> {
    return this.http.post<LoggedInUser>('http://localhost:5000/api/user/login', userInput);
  }
}
