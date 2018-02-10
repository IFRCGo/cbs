import { Component, OnInit } from '@angular/core';
import { UserType } from '../domain/userType.enum';

@Component({
  selector: 'cbs-select-user-role',
  templateUrl: './select-user-role.component.html',
  styleUrls: ['./select-user-role.component.scss']
})
export class SelectUserRoleComponent implements OnInit {

  selectedUserType;

  constructor() {
  }

  ngOnInit() {
  }

  selectUserType(usertype) {
    this.selectedUserType = usertype;
  }
}
