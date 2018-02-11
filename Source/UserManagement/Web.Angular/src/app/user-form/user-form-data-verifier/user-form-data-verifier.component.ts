import { Component, OnInit } from '@angular/core';
import { DataVerifier } from '../../domain/data-verifier';
import { StaffUserService } from '../../services/staff-user.service';

export const DATA_VERIFIER_PATH = 'data-verifier';

@Component({
  selector: 'cbs-user-form-data-verifier',
  templateUrl: './user-form-data-verifier.component.html',
  styleUrls: ['./user-form-data-verifier.component.scss']
})
export class UserFormDataVerifierComponent implements OnInit {

  user = new DataVerifier({});

  languageOptions = ['English', 'French'];

  constructor(private staffUserService: StaffUserService) {
  }

  ngOnInit() {
  }

  submit() {
    this.staffUserService.saveUser(this.user);
  }
}
