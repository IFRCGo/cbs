import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';

import { StaffUserService } from './staffUserManagement/staffUser.service';
import { DataCollectorService } from './dataCollectorManagement/dataCollector.service';

import { AppComponent } from './app.component';
import { StaffUserComponent } from './staffUserManagement/staffUser.component';
import { DataCollectorFormComponent } from './dataCollectorManagement/dataCollector.component';
import { UserListComponent } from './userListComponent/userList.component';
import { AddUserComponent } from './addUser/addUser.component';
import { UserFormComponent } from './addUser/userForm.component';
import { DeleteUserComponent } from './deleteUser/deleteUser.component';

@NgModule({
  declarations: [
    AppComponent,
    StaffUserComponent,
    DataCollectorFormComponent,
    UserListComponent,
    AddUserComponent,
    UserFormComponent,
    DeleteUserComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ModalModule.forRoot()
  ],
  providers: [StaffUserService, DataCollectorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
