import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../DataCollector';
import { QueryCoordinator } from '@dolittle/queries';
import { AllDataCollectors } from '../AllDataCollectors';

@Component({
  templateUrl: './datacollector-list.component.html',
  styleUrls: ['./datacollector-list.component.scss']
})
export class DataCollectorListComponent implements OnInit {
  users: ReadonlyArray<DataCollector>;

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  selectedUser: DataCollector;

  constructor(
    private queryCoordinator: QueryCoordinator
  ) { }

  ngOnInit() {
    this.queryCoordinator.execute(new AllDataCollectors())
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
