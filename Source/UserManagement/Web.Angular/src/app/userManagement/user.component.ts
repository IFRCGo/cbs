import { UserService } from './user.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'cbs-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit() {}

  async addItem() {
    console.log('Clicked item');
  }
}
