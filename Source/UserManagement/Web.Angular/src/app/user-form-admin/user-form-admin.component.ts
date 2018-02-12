import { Component, OnInit } from '@angular/core';
import { User } from '../domain/user';

@Component({
  selector: 'cbs-user-form-admin',
  templateUrl: './user-form-admin.component.html',
  styleUrls: ['./user-form-admin.component.scss']
})
export class UserFormAdminComponent implements OnInit {

  user = new User({});

  constructor() { }

  ngOnInit() {
  }

}
