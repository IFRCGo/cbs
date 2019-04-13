import { Component, OnInit } from '@angular/core';
import { DataCollector } from '../DataCollector';
import { QueryCoordinator } from '@dolittle/queries';
import { AllDataCollectors } from '../AllDataCollectors';

@Component({
  templateUrl: './send-sms.html',
  styleUrls: ['./send-sms.scss']
})
export class SendSms implements OnInit {
  users: ReadonlyArray<DataCollector>;

  public error: boolean;
  public errorMsg = 'Could not get users, try again later';

  selectedUser: DataCollector;
  itemList;
  selectedItems = [];
  settings = {};
  message = '';
  m
  recipients;

  constructor(
    private queryCoordinator: QueryCoordinator
  ) { }

  ngOnInit() {
    this.queryCoordinator.execute(new AllDataCollectors())
      .then(response => {
          if (response.success) {
            this.users = response.items;
            this.itemList = this.users;

            this.settings = {
                text: "Select Recipients",
                selectAllText: 'Select All',
                unSelectAllText: 'UnSelect All',
                enableSearchFilter: true,
                showCheckbox: true,
                searchBy: ['fullName'],
                badgeShowLimit: 5
            };
          } else {
            console.error(response);
          }
      })
      .catch(response => {
        console.error(response);
      });
  }

  onItemSelect(item: any) {
      console.log(item);
      console.log(this.selectedItems);
  }
  OnItemDeSelect(item: any) {
      console.log(item);
      console.log(this.selectedItems);
  }
  onSelectAll(items: any) {
      console.log(items);
  }
  onDeSelectAll(items: any) {
      console.log(items);
  }

  send() {
    console.log(this.message, this.selectedItems)
  }
}
