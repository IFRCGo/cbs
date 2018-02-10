import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';

import { StaffUserService } from './staffUserManagement/staffUser.service';
import { DataCollectorService } from './dataCollectorManagement/dataCollector.service';

import { AppComponent } from './app.component';
import { StaffUserComponent } from './staffUserManagement/staffUser.component';
import { UserListComponent } from './userListComponent/userList.component';
import { DeleteUserComponent } from './deleteUser/deleteUser.component';
import { SelectUserRoleComponent } from './select-user-role/select-user-role.component';
import { UserFormComponent } from './user-form/user-form.component';
import { UserFormAdminComponent } from './user-form-admin/user-form-admin.component';
import { UserFormSystemConfiguratorComponent } from './user-form-system-configurator/user-form-system-configurator.component';
import { UserFormDataCoordinatorComponent } from './user-form-data-coordinator/user-form-data-coordinator.component';
import { UserFormDataOwnerComponent } from './user-form-data-owner/user-form-data-owner.component';
import { UserFormDataVerifierComponent } from './user-form-data-verifier/user-form-data-verifier.component';
import { UserFormDataCollectorComponent } from './user-form-data-collector/user-form-data-collector.component';
import { UserFormDataConsumerComponent } from './user-form-data-consumer/user-form-data-consumer.component';

const appRoutes: Routes = [
  {path: '', component: UserListComponent},
  {path: 'add-user', component: SelectUserRoleComponent},
  {path: 'add-user/:userRole', component: UserFormComponent},
  {path: 'edit-user/:id', component: UserFormComponent },
  {path: '**', component: UserListComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    StaffUserComponent,
    UserListComponent,
    DeleteUserComponent,
    SelectUserRoleComponent,
    UserFormComponent,
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
