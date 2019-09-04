import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../DataCollector';
import { QueryCoordinator } from '@dolittle/queries';
import { AllListedDataCollectors } from '../../../Reporting/DataCollectors/AllListedDataCollectors';
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
    private appInsightsService: AppInsightsService
  ) { }

  ngOnInit() {
    const queryCoordinator = new QueryCoordinator();
    queryCoordinator.execute(new AllListedDataCollectors())
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

  formatDate(rawDate) {
    var date = new Date(rawDate);
    var month = date.getMonth() + 1; // getMonth() is zero-based
    var day = date.getDate();
  
    return [date.getFullYear() + '-',
            (month>9 ? '' : '0') + month + '-',
            (day>9 ? '' : '0') + day
           ].join('');
  }
}
