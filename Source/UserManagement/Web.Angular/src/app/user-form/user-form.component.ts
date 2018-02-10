import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

const EMAIL_REGEX = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

@Component({
  selector: 'cbs-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  userForm: FormGroup;

  selectedUserRole;

  userTypes = [
    {value: 'admin'},
    {value: 'systemCoordinator'},
    {value: 'dataCoordinator'},
    {value: 'dataOwner'},
    {value: 'dataVerifier'},
    {value: 'dataCollector'}
  ];

  selectedSex: string;
  sexOptions = [
    {value: '0', viewValue: 'Male'},
    {value: '1', viewValue: 'Female'},
    {value: '2', viewValue: 'Other'}
  ];

  selectedNationalSociety: string;

  nationalSocieties = [
    {value: 'placeholder', viewValue: 'Placeholder Society (PHS)'}
  ];

  selectedLanguage: string;
  languageOptions = [
    {value: '0', viewValue: 'English'},
    {value: '1', viewValue: 'French'}
  ];

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.pattern(EMAIL_REGEX)]);

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute) {
  }


  ngOnInit() {
    this.buildForm();

    this.route.params.subscribe(params =>
      this.selectedUserRole = params['userRole']
    )
  }


  buildForm() {
    this.userForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      mobilePhoneNumber: ['', [Validators.required]],
      email: this.emailFormControl,
      sex: ['', [Validators.required]],
      age: ['', [Validators.required, Validators.min(10), Validators.max(100)]],
      nationalSociety: ['', [Validators.required]],
      preferredLanguage: ['', [Validators.required]]
    });
  }

}
