import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataCollector } from '../domain/data-collector';
import { DataCollectorService } from '../services/data-collector.service';
import { Location } from '@angular/common';
import { Sex } from '../domain/sex';
import { Language } from '../domain/language.model';
@Component({
  selector: 'cbs-user-detail',
  templateUrl: './datacollector-detail.component.html',
  styleUrls: ['./datacollector-detail.component.scss']
})
export class DataCollectorDetailComponent implements OnInit {

  @Input() dataCollector: DataCollector;

  constructor(
    private route: ActivatedRoute,
    private dataCollectorService: DataCollectorService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getDataCollector();
  }

  getDataCollector(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.dataCollectorService.getDataCollector(id)
      .subscribe(dataCollector => this.dataCollector = dataCollector[0]);
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
