import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../../domain/data-collector';
import { DataCollectorService } from '../../services/data-collector.service';

export const DATA_COLLECTOR_PATH = 'data-collector';

@Component({
  selector: 'cbs-user-form-data-collector',
  templateUrl: './user-form-data-collector.component.html',
  styleUrls: ['./user-form-data-collector.component.scss']
})
export class UserFormDataCollectorComponent {
  user: DataCollector = new DataCollector({});
  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];

  constructor(private dataColletorService: DataCollectorService) {
  }

  submit() {
    this.dataColletorService.saveDataCollector(this.user)
      .then(response => {
        console.log(response);
      })
      .catch(response => {
        console.log(response);
      });
  }
}
