import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';


import { DataCollectorService } from './dataCollectorManagement/dataCollector.service';
import { StaffUserService } from './services/staff-user.service';

import { AppComponent } from './app.component';
import { UserListComponent } from './user-list/user-list.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { SelectUserRoleComponent } from './select-user-role/select-user-role.component';
import { UserFormAdminComponent } from './user-form/user-form-admin/user-form-admin.component';
import { UserFormSystemConfiguratorComponent } from './user-form/user-form-system-configurator/user-form-system-configurator.component';
import { UserFormDataCoordinatorComponent } from './user-form/user-form-data-coordinator/user-form-data-coordinator.component';
import { UserFormDataOwnerComponent } from './user-form/user-form-data-owner/user-form-data-owner.component';
import { UserFormDataVerifierComponent } from './user-form/user-form-data-verifier/user-form-data-verifier.component';
import { UserFormDataCollectorComponent } from './user-form/user-form-data-collector/user-form-data-collector.component';
import { UserFormDataConsumerComponent } from './user-form/user-form-data-consumer/user-form-data-consumer.component';

import { USER_FORM_ROUTES } from './user-form';

const appRoutes: Routes = [
  ...USER_FORM_ROUTES,
  { path: 'add-user', component: SelectUserRoleComponent },
  { path: '', component: UserListComponent },
  { path: '**', component: UserListComponent }
];

console.log(appRoutes);

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    DeleteUserComponent,
    SelectUserRoleComponent,
    UserFormAdminComponent,
    UserFormSystemConfiguratorComponent,
    UserFormDataCoordinatorComponent,
    UserFormDataOwnerComponent,
    UserFormDataVerifierComponent,
    UserFormDataCollectorComponent,
    UserFormDataConsumerComponent

  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      {enableTracing: true} // <-- debugging purposes only
    ),
    BrowserModule,
    CommonModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [StaffUserService, DataCollectorService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
