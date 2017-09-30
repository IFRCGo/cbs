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
  }

  buildForm() {
    this.staffUserForm = this.formBuilder.group({
      fullName: [ '', [ Validators.required ] ]
    });
  }

  async addStaffUser(staffUser) {
    const newStaffUser: StaffUser = {
      name: staffUser.fullName
    };

    this.staffUserService.saveUser(newStaffUser);
    console.log('Clicked button');
  }
}
