import { Component, OnInit } from '@angular/core';
import { DataConsumer } from '../../domain/data-consumer';
import { StaffUserService } from '../../services/staff-user.service';

export const DATA_CONSUMER_PATH = 'data-consumer';

@Component({
  selector: 'cbs-user-form-data-consumer',
  templateUrl: './user-form-data-consumer.component.html',
  styleUrls: ['./user-form-data-consumer.component.scss']
})
export class UserFormDataConsumerComponent implements OnInit {
  user: DataConsumer;

  public errorMsg = 'Something went wrong, try again later';
  public successMsg = 'User added';
  public success = false;
  public error = false;

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];

  constructor(private staffUserService: StaffUserService) {
    this.user = new DataConsumer({});
  }

  ngOnInit() {
  }

  submit() {
    this.staffUserService.saveUser(this.user).subscribe(
      data => {
        this.success = true;
        console.log(data);
      },
      error => {
        this.error = true;
        console.error(error)
      })
  }
}
