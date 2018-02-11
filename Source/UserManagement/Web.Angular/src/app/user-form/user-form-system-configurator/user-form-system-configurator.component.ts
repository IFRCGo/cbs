import { Component, OnInit } from '@angular/core';
import { SystemConfigurator } from '../../domain/system-configurator';
import { StaffUserService } from '../../services/staff-user.service';
import { Router } from '@angular/router';

export const SYSTEM_CONFIGURATOR_PATH = 'system-configurator';

@Component({
  selector: 'cbs-user-form-system-configurator',
  templateUrl: './user-form-system-configurator.component.html',
  styleUrls: ['./user-form-system-configurator.component.scss']
})
export class UserFormSystemConfiguratorComponent implements OnInit {

  user = new SystemConfigurator({});
  public errorMsg = 'Something went wrong, try again later';
  public successMsg = 'User added';
  public success = false;
  public error = false;

  languageOptions = ['English', 'French'];
  nationalSocieties = ['Norway', 'Sweden'];
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
