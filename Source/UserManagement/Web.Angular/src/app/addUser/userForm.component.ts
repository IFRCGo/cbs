import { StaffUserService } from '../staffUserManagement/staffUser.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { StaffUser } from '../domain/staffUser';

const EMAIL_REGEX = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

@Component({
    selector: 'cbs-userForm',
    templateUrl: './userForm.component.html'
  })
export class UserFormComponent {
  userForm: FormGroup;

  selectedSex: string;
  sexOptions = [
    { value: '0', viewValue: 'Male' },
    { value: '1', viewValue: 'Female' },
    { value: '2', viewValue: 'Other' }
  ];

  selectedNationalSociety: string;
  nationalSocieties = [
    { value: 'placeholder', viewValue: 'Placeholder Society (PHS)'}
  ];

  selectedLanguage: string;
  languageOptions = [
    { value: '0', viewValue: 'English' },
    { value: '1', viewValue: 'French' }
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
    this.userForm = this.formBuilder.group({
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

  async addUser(staffUser) {
    const newStaffUser: StaffUser = {
        firstName: staffUser.firstName,
        lastName: staffUser.lastName,
        sex: staffUser.sex,
        age: staffUser.age,
        nationalSociety: "92c7c5be-f774-4d7c-8b65-ee14032c2d25",
        preferredLanguage: staffUser.preferredLanguage,
        mobilePhoneNumber: staffUser.mobilePhoneNumber,
        email: staffUser.email
    };

    this.staffUserService.saveUser(newStaffUser);
  }
}