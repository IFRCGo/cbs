import { Component, OnInit } from '@angular/core';
import { StaffUserService } from '../staffUserManagement/staffUser.service';
import { StaffUser } from '../domain/staffUser';

@Component({
    selector: 'cbs-userList',
    templateUrl: './userList.component.html'
})
export class UserListComponent implements OnInit {
    users: Array<StaffUser>;

    constructor(
        private staffUserService: StaffUserService
    ) { }

    ngOnInit() {
        this.staffUserService.getAllUsers()
            .then(users => this.users = users)
            .catch((error) => console.error(error));
    }
}
