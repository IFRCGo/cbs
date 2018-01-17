// import { Component, OnInit, AfterViewInit } from '@angular/core';
// import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
// import { DataCollectorService } from './dataCollector.service';

// @Component({
//   selector: 'cbs-data-collector-form',
//   templateUrl: 'dataCollector.component.html',
//   styleUrls: [ 'dataCollector.component.scss' ]
// })
// export class DataCollectorFormComponent implements OnInit {
//   dataCollectorForm: FormGroup;
//   selectedSex: string;
//   latitude: number;
//   longitude: number;
//   languages = [
//     { value: '0', viewValue: 'English'},
//     { value: '1', viewValue: 'French'}
//   ];
//   sexOptions = [
//     {value: 'male', viewValue: 'Male'},
//     {value: 'female', viewValue: 'Female'},
//     {value: 'other', viewValue: 'Other'}
//   ];

//   constructor(private formBuilder: FormBuilder,
//               private userService: DataCollectorService
//   ) {}

//   ngOnInit() {
//     this.buildForm();
//   }


//   public getPosition() {
//       if (navigator.geolocation) {
//         navigator.geolocation.getCurrentPosition(location => {
//             this.longitude = location.coords.longitude;
//             this.latitude = location.coords.latitude;
//         });
//       };
//   }

//   buildForm() {
//     this.dataCollectorForm = this.formBuilder.group({
//       firstName: [ '', [ Validators.required ] ],
//       lastName: [ '', [ Validators.required ] ],
//       age: ['', [ Validators.required ] ],
//       sex: ['', [ Validators.required ] ],
//       nationalSociety: ['', [ Validators.required ] ],
//       language: ['', [ Validators.required ] ],
//       mobilePhoneNumber: ['', [ Validators.required ] ],
//       longitude: ['', [ Validators.required ] ],
//       latitude: ['', [ Validators.required ] ]
//     });
//   }

//   adddataCollector(form, isValidForm) {
//     if (isValidForm) {
//       console.log(form)
//     }
//     this.addUser(form)
//   }

//   async addUser(form) {
//     this.userService.saveDataCollector(form);
//     console.log('Clicked button');
//   }
// }
