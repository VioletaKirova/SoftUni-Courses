import { Component, OnInit, OnDestroy } from '@angular/core';

import { AuthService } from 'src/app/core/services/authentication/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnDestroy {

  isAuth = false;
  isAuthSub: Subscription;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isAuthSub = this.authService.isAuthChanged.subscribe((data) => {
      this.isAuth = data;
    });
  }

  ngOnDestroy() {
    this.isAuthSub.unsubscribe();
  }

  logout() {
    this.authService.logout();
  }
}
