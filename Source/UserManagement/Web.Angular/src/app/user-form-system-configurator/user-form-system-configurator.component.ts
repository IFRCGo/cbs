import { Component, OnInit } from '@angular/core';
import { User } from '../domain/user';

@Component({
  selector: 'cbs-user-form-system-configurator',
  templateUrl: './user-form-system-configurator.component.html',
  styleUrls: ['./user-form-system-configurator.component.scss']
})
export class UserFormSystemConfiguratorComponent implements OnInit {

  user = new User({});

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];
  constructor() { }

  ngOnInit() {
  }

  submit() { console.log(this.user) }
}
