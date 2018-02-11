import { Component, OnInit } from '@angular/core';
import { DataCoordinator } from '../../domain/data-coordinator';
import { Router } from '@angular/router';
import { StaffUserService } from '../../services/staff-user.service';

export const DATA_COORDINATOR_PATH = 'data-coordinator';

@Component({
  selector: 'cbs-user-form-data-coordinator',
  templateUrl: './user-form-data-coordinator.component.html',
  styleUrls: ['./user-form-data-coordinator.component.scss']
})
export class UserFormDataCoordinatorComponent implements OnInit {
  user: DataCoordinator;

  public errorMsg = 'Something went wrong, try again later';
  public successMsg = 'User added';
  public success = false;
  public error = false;

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];

  constructor(private staffUserService: StaffUserService, private router: Router) {
    this.user = new DataCoordinator({});
  }
  ngOnInit() {
  }


  submit() {
    this.staffUserService.saveUser(this.user).subscribe(
      data => {
        this.success = true;
        console.log(data);
        setTimeout(() => this.router.navigateByUrl(''), 3000)
      },
      error => {
        this.error = true;
        console.error(error)
      })
  }
}
