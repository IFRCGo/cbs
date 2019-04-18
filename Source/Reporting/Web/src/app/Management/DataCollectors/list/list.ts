import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../DataCollector';
import { QueryCoordinator } from '@dolittle/queries';
import { AllDataCollectors } from '../AllDataCollectors';
import { AppInsightsService } from '../../../services/app-insights-service';

@Component({
  templateUrl: './list.html',
  styleUrls: ['./list.scss']
})
export class List implements OnInit {
  users: ReadonlyArray<DataCollector>;

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  selectedUser: DataCollector;

  constructor(
    private queryCoordinator: QueryCoordinator,
    private appInsightsService: AppInsightsService
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

      this.appInsightsService.trackPageView('Data Collector List');
  }

  onSelect(dataCollector: DataCollector): void {
    this.selectedUser = dataCollector;
  }
}
