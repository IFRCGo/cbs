import { Component, OnInit } from '@angular/core';
import { DataCollectorService } from '../services/data-collector.service';
import { DataCollector } from '../domain/data-collector';

@Component({
  selector: 'cbs-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: Array<DataCollector>;

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  constructor(private staffUserService: DataCollectorService) {
  }

  ngOnInit() {
    this.staffUserService.getAllDataCollectors().subscribe(
      data => {
        this.users = data.json();
      },
      error => {
        this.error = true;
        console.error(error)
      }
    )
  }
}
