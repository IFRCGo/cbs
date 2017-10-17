import { StaffUserService } from './staffUser.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { StaffUser } from '../domain/staffUser';

const EMAIL_REGEX = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

@Component({
  selector: 'cbs-user',
  templateUrl: './staffUser.component.html',
  styleUrls: ['./staffUser.component.scss']
})
export class StaffUserComponent implements OnInit {
  staffUserForm: FormGroup;

  selectedSex: string;
  sexOptions = [
    { value: 'male', viewValue: 'Male' },
    { value: 'female', viewValue: 'Female' }
  ];

  selectedNationalSociety: string;
  nationalSocieties = [
    { value: 'placeholder', viewValue: 'Placeholder Society (PHS)'}
  ];

  selectedLanguage: string;
  languageOptions = [
    { value: 'en', viewValue: 'English' },
    { value: 'fr', viewValue: 'French' }
  ];

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.pattern(EMAIL_REGEX)]);

  constructor(
    private staffUserService: StaffUserService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.buildForm();
    this.staffUserService.getNationalSocieties()
      .then(this.processNationalSocieties)
      .then(societies => {
        this.nationalSocieties = societies;
      });
  }

  processNationalSocieties = societies => societies.map(society => ({
    value: society.id,
    viewValue: society.displayName
  }));

  buildForm() {
    this.staffUserForm = this.formBuilder.group({
        firstName: [ '', [ Validators.required ] ],
        lastName: [ '', [ Validators.required ] ],
        sex: ['', [ Validators.required ] ],
        age: ['', [ Validators.required, Validators.min(10), Validators.max(100) ] ],
        nationalSociety: ['', [ Validators.required ] ],
        preferredLanguage: ['', [ Validators.required ] ],
        mobilePhoneNumber: ['', [ Validators.required ] ],
        email: this.emailFormControl
      });
  }

  async addStaffUser(staffUser) {
    const newStaffUser: StaffUser = {
        firstName: staffUser.firstName,
        lastName: staffUser.lastName,
        sex: staffUser.sex,
        age: staffUser.age,
        nationalSociety: staffUser.nationalSociety,
        preferredLanguage: staffUser.preferredLanguage,
        mobilePhoneNumber: staffUser.mobilePhoneNumber,
        email: staffUser.email
    };

    this.staffUserService.saveUser(newStaffUser);
  }
}
