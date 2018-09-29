import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../domain/data-collector';
import { QueryCoordinator2 } from '../services/QueryCoordinator';
import { AllDataCollectors } from '../domain/data-collector/queries/AllDataCollectors';
import { QueryResult } from '../services/QueryResult';

@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: ReadonlyArray<DataCollector>;

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  selectedUser: DataCollector;

  constructor(private queryCoordinator: QueryCoordinator2<DataCollector>) {
  }

  ngOnInit() {
    this.queryCoordinator.handle(new AllDataCollectors())
      .then(response => {
          if (response.success) {
            this.users = response.items;
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
