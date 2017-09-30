import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'cbs-volunteer-form',
  templateUrl: 'volunteerUser.component.html',
  styles: [ 'volunteerUser.component.scss' ]
})
export class VolunteerFormComponent implements OnInit {
  userForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.userForm = this.formBuilder.group({
      firstName: [ '', [ Validators.required ] ],
      lastName: [ '', [ Validators.required ] ],
      age: ['', [ Validators.required ] ],
      sex: ['', [ Validators.required ] ],
      nationalSociety: ['', [ Validators.required ] ],
      preferredLanguage: ['', [ Validators.required ] ],
      gpsLocation: ['', [ Validators.required ] ],
      mobilePhoneNumber: ['', [ Validators.required ] ]
    });
  }

  addForm(form, isValidForm) {
    if (isValidForm) {
      console.log(form)
    }
  }
}
