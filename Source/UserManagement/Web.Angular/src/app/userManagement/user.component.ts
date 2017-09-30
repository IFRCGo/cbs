import { UserService } from './user.service';
import { Component, OnInit } from '@angular/core';
import { User } from './user';

@Component({
  selector: 'cbs-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit() {}

  async addUser() {
    const newUser: User = {
      name: 'Steven Hicks'
    };

    this.userService.saveUser(newUser);
    console.log('Clicked button');
  }
}
