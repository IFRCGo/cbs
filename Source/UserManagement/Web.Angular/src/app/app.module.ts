import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';

import { DataCollectorService } from './services/data-collector.service';
import { StaffUserService } from './services/staff-user.service';

import { AppComponent } from './app.component';
import { UserListComponent } from './user-list/user-list.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { SelectUserRoleComponent } from './user-form/select-user-role/select-user-role.component';
import { UserFormAdminComponent } from './user-form/user-form-admin/user-form-admin.component';
import { UserFormSystemConfiguratorComponent } from './user-form/user-form-system-configurator/user-form-system-configurator.component';
import { UserFormDataCoordinatorComponent } from './user-form/user-form-data-coordinator/user-form-data-coordinator.component';
import { UserFormDataOwnerComponent } from './user-form/user-form-data-owner/user-form-data-owner.component';
import { UserFormDataVerifierComponent } from './user-form/user-form-data-verifier/user-form-data-verifier.component';
import { UserFormDataCollectorComponent } from './user-form/user-form-data-collector/user-form-data-collector.component';
import { UserFormDataConsumerComponent } from './user-form/user-form-data-consumer/user-form-data-consumer.component';
import { DataCollectorDetailComponent } from './user-detail/datacollector-detail.component';
import { NavTopBarComponent } from 'navigation/nav-top-bar.component';

import { USER_FORM_ROUTES } from './user-form';
import { USER_DETAIL_ROUTES } from './user-detail';
import { ModalModule } from 'ngx-bootstrap';

const appRoutes: Routes = [
  ...USER_FORM_ROUTES,
  ...USER_DETAIL_ROUTES,
  { path: '', component: UserListComponent },
  { path: '**', component: UserListComponent }
];

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
    UserFormDataConsumerComponent,
    DataCollectorDetailComponent,
    NavTopBarComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    CommonModule,
    HttpClientModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ModalModule.forRoot()
  ],
  providers: [StaffUserService, DataCollectorService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
