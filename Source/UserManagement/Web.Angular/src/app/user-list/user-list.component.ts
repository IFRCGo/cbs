import { Component, OnInit } from '@angular/core';
import { DataCollectorService } from '../services/data-collector.service';
import { DataCollector } from '../domain/data-collector';
import { QueryCoordinator } from '../services/QueryCoordinator';
import { AllDataCollectors } from '../domain/data-collector/queries/AllDataCollectors';
import { QueryResult } from '../services/QueryResult';

@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: DataCollector[];

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  selectedUser: DataCollector;

  constructor(private queryCoordinator: QueryCoordinator) {
  }

  ngOnInit() {
    this.queryCoordinator.handle(new AllDataCollectors())
      .then(response => {
          if (response.success) {
            this.users = response.items as DataCollector[];
          } else {
            console.error(response);
          }
      })
      .catch(response => {
        console.error(response);
      });
  }

  onSelect(dataCollector: DataCollector): void {
    this.selectedUser = dataCollector;
  }
}
