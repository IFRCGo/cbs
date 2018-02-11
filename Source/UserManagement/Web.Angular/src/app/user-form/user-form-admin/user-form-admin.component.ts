import { Component, OnInit } from '@angular/core';
import { Admin } from '../../domain/admin';

export const ADMIN_PATH = 'admin';

@Component({
  selector: 'cbs-user-form-admin',
  templateUrl: './user-form-admin.component.html',
  styleUrls: ['./user-form-admin.component.scss']
})
export class UserFormAdminComponent implements OnInit {

  user: Admin;

  constructor() {
    this.user = new Admin({});
   }

  ngOnInit() {
  }

  onSubmit() {

  }
}
