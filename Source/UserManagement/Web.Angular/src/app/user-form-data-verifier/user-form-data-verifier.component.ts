import { Component, OnInit } from '@angular/core';
import { User } from '../domain/user';

@Component({
  selector: 'cbs-user-form-data-verifier',
  templateUrl: './user-form-data-verifier.component.html',
  styleUrls: ['./user-form-data-verifier.component.scss']
})
export class UserFormDataVerifierComponent implements OnInit {

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