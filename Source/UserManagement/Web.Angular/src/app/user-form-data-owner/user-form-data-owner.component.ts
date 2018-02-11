import { Component, OnInit } from '@angular/core';
import { DataOwner } from '../domain/data-owner';

@Component({
  selector: 'cbs-user-form-data-owner',
  templateUrl: './user-form-data-owner.component.html',
  styleUrls: ['./user-form-data-owner.component.scss']
})
export class UserFormDataOwnerComponent implements OnInit {

  user = new DataOwner({});

  languageOptions = ['English', 'French'];

  constructor() {
  }

  ngOnInit() {
  }

  submit() {
    console.log(this.user)
  }
}