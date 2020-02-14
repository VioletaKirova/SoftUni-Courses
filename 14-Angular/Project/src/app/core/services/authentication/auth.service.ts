import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuth = false;

  isAuthChanged = new Subject<boolean>();

  constructor(
    private afAuth: AngularFireAuth,
    private router: Router,
    private snackbar: MatSnackBar
  ) { }

  get isAuthenticated() {
    return this.isAuth;
  }

  initializeAuthState() {
    this.afAuth.authState.subscribe((userState) => {
      if (userState) {
        this.isAuth = true;
        this.isAuthChanged.next(true);
      } else {
        this.isAuth = false;
        this.isAuthChanged.next(false);
      }
    });
  }

  registerUser(email: string, password: string) {
    this.afAuth.auth.createUserWithEmailAndPassword(email, password)
      .then(() => {
        this.router.navigate([ '/login' ]);
      })
      .catch((error) => {
        this.snackbar.open(error.message, 'Undo', {
          duration: 3000
        });
      });
  }

  loginUser(email: string, password: string) {
    this.afAuth.auth.signInWithEmailAndPassword(email, password)
      .then((userData) => {
        this.router.navigate([ '/' ]);
        localStorage.setItem('email', userData.user.email);
      })
      .catch((error) => {
        this.snackbar.open(error.message, 'Undo', {
          duration: 3000
        });
      });
  }

  logout() {
    this.afAuth.auth.signOut();
    localStorage.clear();
    this.router.navigate([ '/' ]);
  }
}
