import { Component, OnInit } from '@angular/core';
import { SystemConfigurator } from '../domain/system-configurator';

@Component({
  selector: 'cbs-user-form-system-configurator',
  templateUrl: './user-form-system-configurator.component.html',
  styleUrls: ['./user-form-system-configurator.component.scss']
})
export class UserFormSystemConfiguratorComponent implements OnInit {

  user = new SystemConfigurator({});

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];
  constructor() { }

  ngOnInit() {
  }

  submit() { console.log(this.user) }
}
