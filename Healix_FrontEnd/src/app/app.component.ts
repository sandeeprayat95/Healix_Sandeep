import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './services/user.service';
import { User } from './models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private router: Router,private userService: UserService) {}
  user!: User;
  navigateToUsers() {
    this.router.navigate(['/users']);
  }

  navigateToAddUser() {
      this.router.navigate(['/add-user']);
  }
}
