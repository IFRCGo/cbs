import { Component, OnInit } from '@angular/core';
import { User } from '../../domain/user';

export const DATA_CONSUMER_PATH = 'data-consumer';

@Component({
  selector: 'cbs-user-form-data-consumer',
  templateUrl: './user-form-data-consumer.component.html',
  styleUrls: ['./user-form-data-consumer.component.scss']
})
export class UserFormDataConsumerComponent implements OnInit {
  user = new User({});

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];
  constructor() { }

  ngOnInit() {
  }

  submit() { console.log(this.user) }
}
