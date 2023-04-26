import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'DogMarketClient';
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.sendAuthStateChangeNotification(true);
  }

  
}
