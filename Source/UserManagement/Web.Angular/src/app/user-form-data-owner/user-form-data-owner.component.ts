import { Component, OnInit } from '@angular/core';
import { User } from '../domain/user';

@Component({
  selector: 'cbs-user-form-data-owner',
  templateUrl: './user-form-data-owner.component.html',
  styleUrls: ['./user-form-data-owner.component.scss']
})
export class UserFormDataOwnerComponent implements OnInit {

  user = new User({});

  languageOptions = ['English', 'French'];

  constructor() {
  }

  ngOnInit() {
  }

  submit() {
    console.log(this.user)
  }
}