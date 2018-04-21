import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { DataCollector } from '../../domain/data-collector';
import { DataCollectorService } from '../../services/data-collector.service';

export const DATA_COLLECTOR_PATH = 'data-collector';

@Component({
  templateUrl: './user-form-data-collector.component.html',
  styleUrls: ['./user-form-data-collector.component.scss']
})
export class UserFormDataCollectorComponent {

  user: DataCollector = new DataCollector({});
  languageOptions = ['English', 'French'];
  sexOptions = [{desc: 'Male', id: '1'}, {desc: 'Female', id: '2'}];

  constructor(
    private router: Router,
    private dataCollectorService: DataCollectorService, 
  ) {}

  submit() {
    this.dataCollectorService.saveDataCollector(this.user)
      .then(response => {
        console.log(response); 
      })
      .catch(response => {
        console.log(response);
      });
      this.router.navigate(['list']);
  }
}
