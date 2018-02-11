import { Component, OnInit } from '@angular/core';
import { DataCoordinator } from '../domain/data-coordinator';

@Component({
  selector: 'cbs-user-form-data-coordinator',
  templateUrl: './user-form-data-coordinator.component.html',
  styleUrls: ['./user-form-data-coordinator.component.scss']
})
export class UserFormDataCoordinatorComponent implements OnInit {
  user = new DataCoordinator({});

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];
  constructor() { }

  ngOnInit() {
  }

  submit() { console.log(this.user) }
}
