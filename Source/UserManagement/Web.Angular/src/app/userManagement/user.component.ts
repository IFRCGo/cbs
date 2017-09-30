import { UserService } from './user.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from './user';

@Component({
  selector: 'cbs-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  userForm: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.userForm = this.formBuilder.group({
      fullName: [ '', [ Validators.required ] ]
    });
  }

  async addUser(user) {
    const newUser: User = {
      name: user.fullName
    };

    this.userService.saveUser(newUser);
    console.log('Clicked button');
  }
}
