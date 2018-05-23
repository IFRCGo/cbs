import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataCollector } from '../domain/data-collector';
import { Location } from '@angular/common';
import { Sex } from '../domain/sex';
import { Language } from '../domain/language.model';
import { QueryCoordinator } from '../services/QueryCoordinator';
import { DataCollectorById } from '../domain/data-collector/queries/DataCollectorById';

@Component({
  selector: 'cbs-user-detail',
  templateUrl: './datacollector-detail.component.html',
  styleUrls: ['./datacollector-detail.component.scss']
})
export class DataCollectorDetailComponent implements OnInit {

  dataCollector: DataCollector;

  constructor(
    private queryCoordinator: QueryCoordinator,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getDataCollector();
  }

  getDataCollector(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.queryCoordinator.handle(new DataCollectorById(id))
      .then(response => {
        if (response.success) {
          if (response.items.length > 0) {
            this.dataCollector = response.items[0] as DataCollector
          } else {
            // Datacollector was not found
            console.error(response)
          }
        } else {
          console.error(response);
        }
      })
      .catch(response => {
        console.error(response);
      })
  }

  getSexString(sex: number): string {
    return Sex[sex];
  }
  getLanguageString(lan: number): string {
    return Language[lan];
  }
  goBack(): void {
    this.location.back();
  }
}
