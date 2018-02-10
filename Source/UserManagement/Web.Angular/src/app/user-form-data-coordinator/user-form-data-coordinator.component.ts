import { Component, OnInit } from '@angular/core';
import { User } from '../domain/user';

@Component({
  selector: 'cbs-user-form-data-coordinator',
  templateUrl: './user-form-data-coordinator.component.html',
  styleUrls: ['./user-form-data-coordinator.component.scss']
})
export class UserFormDataCoordinatorComponent implements OnInit {
  user = new User({});

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];
  constructor() { }

  ngOnInit() {
  }

  submit() { console.log(this.user) }
}
