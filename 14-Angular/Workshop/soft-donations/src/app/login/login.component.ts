import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  emailRegex = /^[a-zA-Z0-9.-_]{6,}@gmail\.(com|bg)$/g;

  constructor(
    private userService: UserService,
    private router: Router) { }

  ngOnInit() {
  }

  handleLogin({ email, password }: { email: string, password: string }) {
    this.userService.login(email, password);
    this.router.navigate(['']);
  }
}
