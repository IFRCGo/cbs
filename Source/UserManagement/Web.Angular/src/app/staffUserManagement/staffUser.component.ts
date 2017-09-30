import { StaffUserService } from './staffUser.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { StaffUser } from './staffUser';

@Component({
  selector: 'cbs-user',
  templateUrl: './staffUser.component.html',
  styleUrls: ['./staffUser.component.scss']
})
export class StaffUserComponent implements OnInit {
  staffUserForm: FormGroup;

  constructor(
    private staffUserService: StaffUserService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.buildForm();
    this.staffUserService.getAllUsers();
  }

  buildForm() {
    this.staffUserForm = this.formBuilder.group({
        firstName: [ '', [ Validators.required ] ],
        lastName: [ '', [ Validators.required ] ],
        sex: ['', [ Validators.required ] ],
        birthDate: ['', [ Validators.required ] ],
        nationalSociety: ['', [ Validators.required ] ],
        preferredLanguage: ['', [ Validators.required ] ],
        mobilePhoneNumber: ['', [ Validators.required ] ]
      });
  }

  async addStaffUser(staffUser) {
    const newStaffUser: StaffUser = {
      name: `${staffUser.firstName} ${staffUser.lastName}`
    };

    this.staffUserService.saveUser(newStaffUser);
    console.log('Clicked button');
  }
}
