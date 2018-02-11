import { Component, OnInit } from '@angular/core';
import { DataVerifier } from '../../domain/data-verifier';
import { StaffUserService } from '../../services/staff-user.service';
import { Router } from '@angular/router';

export const DATA_VERIFIER_PATH = 'data-verifier';

@Component({
  selector: 'cbs-user-form-data-verifier',
  templateUrl: './user-form-data-verifier.component.html',
  styleUrls: ['./user-form-data-verifier.component.scss']
})
export class UserFormDataVerifierComponent implements OnInit {

  user = new DataVerifier({});
  public errorMsg = 'Something went wrong, try again later';
  public successMsg = 'User added';
  public success = false;
  public error = false;

  languageOptions = ['English', 'French'];

  constructor(private staffUserService: StaffUserService, private router: Router) {
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
