import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { DataCollectorService } from './dataCollector.service';

@Component({
  selector: 'cbs-dataCollector-form',
  templateUrl: 'dataCollector.component.html',
  styleUrls: [ 'dataCollector.component.scss' ]
})
export class DataCollectorFormComponent implements OnInit {
  dataCollectorForm: FormGroup;
  languages = [
    { value: '0', viewValue: 'English'},
    { value: '1', viewValue: 'French'}
  ];

  constructor(private formBuilder: FormBuilder,
              private userService: DataCollectorService
  ) {}

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.dataCollectorForm = this.formBuilder.group({
      firstName: [ '', [ Validators.required ] ],
      lastName: [ '', [ Validators.required ] ],
      age: ['', [ Validators.required ] ],
      sex: ['', [ Validators.required ] ],
      nationalSociety: ['', [ Validators.required ] ],
      language: ['', [ Validators.required ] ],
      gpsLocation: ['', [ Validators.required ] ],
      mobilePhoneNumber: ['', [ Validators.required ] ]
    });
  }

  adddataCollector(form, isValidForm) {
    if (isValidForm) {
      console.log(form)
    }
    this.addUser(form)
  }

  async addUser(form) {
    this.userService.saveDataCollector(form);
    console.log('Clicked button');
  }
}
