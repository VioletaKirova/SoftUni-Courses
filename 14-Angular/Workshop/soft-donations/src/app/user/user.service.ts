import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  currentUser: { email: string, password: string } = null;

  get isLogged() {
    return !!this.currentUser;
  }

  constructor() {
    const currentUser = localStorage.getItem('current-user');
    this.currentUser = currentUser ? JSON.parse(currentUser) :  null;
  }

  login(email: string, password: string) {
    localStorage.setItem('currentUser', JSON.stringify({ email, password }));
    this.currentUser = { email, password };
  }

  logout() {
    this.currentUser = null;
    localStorage.removeItem('current-user');
  }
}
