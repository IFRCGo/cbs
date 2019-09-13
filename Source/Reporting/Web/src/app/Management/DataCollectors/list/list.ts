import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../DataCollector';
import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';
import { AllDataCollectors } from '../AllDataCollectors';
import { AppInsightsService } from '../../../services/app-insights-service';
import { EndTraining } from '../Training/EndTraining';
import { BeginTraining } from '../Training/BeginTraining';

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
    this.fetchDataCollectors();

    this.appInsightsService.trackPageView('Data Collector List');
  }

  fetchDataCollectors() {
    const queryCoordinator = new QueryCoordinator();
    queryCoordinator.execute(new AllDataCollectors())
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

  toggleTraining(dataCollector: DataCollector) {
    const commandCoordinator = new CommandCoordinator();
    if (dataCollector.inTraining) {
      const endTrainingCommand = new EndTraining();
      endTrainingCommand.dataCollectorId = dataCollector.id;
      commandCoordinator.handle(endTrainingCommand).then(res => {
        console.log(res);
        if (res.success) {
          this.fetchDataCollectors();
        }
      }).catch(err => console.error(err));
    } else {
      const beginTrainingCommand = new BeginTraining();
      beginTrainingCommand.dataCollectorId = dataCollector.id;
      commandCoordinator.handle(beginTrainingCommand).then(res => {
        if (res.success) {
          this.fetchDataCollectors();
        }
      }).catch(err => console.error(err));
    }
  }

  formatDate(rawDate) {
    var date = new Date(rawDate);
    var month = date.getMonth() + 1; // getMonth() is zero-based
    var day = date.getDate();

    return [date.getFullYear() + '-',
    (month > 9 ? '' : '0') + month + '-',
    (day > 9 ? '' : '0') + day
    ].join('');
  }
}
