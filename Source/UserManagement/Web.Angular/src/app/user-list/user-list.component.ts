import { Component, OnInit } from '@angular/core';
import { StaffUserService } from '../services/staff-user.service';
import { StaffUser } from '../domain/staffUser';

@Component({
  selector: 'cbs-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: Array<StaffUser>;

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  constructor(private staffUserService: StaffUserService) {
  }

  ngOnInit() {
    this.staffUserService.getAllUsers().subscribe(
      data => {
        this.users = data.json();
      },
      error => {
        this.error = true;
        console.error(error)
      }
    )
    // .then(users => this.users = users)
    // .catch((error) => console.error(error));
  }
}
