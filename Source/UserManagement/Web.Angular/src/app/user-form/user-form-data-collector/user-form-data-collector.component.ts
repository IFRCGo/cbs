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
  nationalSocieties = [{desc: 'Norway', id: 'badbc228-84aa-4ec3-8946-473b813ab969'}, {desc: 'Sweden', id: '28a460de-3c9e-4fb9-b42d-6bb4d7029a9c'}];

  constructor(private dataColletorService: DataCollectorService) {
  }

  addPhoneNumber() {
    this.user.phoneNumbers.push('')
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
