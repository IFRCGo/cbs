import { Component, OnInit } from '@angular/core';
import { DataCollectorService } from '../services/data-collector.service';
import { DataCollector } from '../domain/data-collector';

@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: DataCollector[];

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  selectedUser: DataCollector;

  constructor(private staffUserService: DataCollectorService) {
  }

  ngOnInit() {
    this.staffUserService.getAllDataCollectors().subscribe(users => this.users = users)
  }

  onSelect(dataCollector: DataCollector): void {
    this.selectedUser = dataCollector;
  }
}
