import { StaffUserService } from './staffUserManagement/staffUser.service';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { MdButtonModule, MatInputModule, MatDatepickerModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { StaffUserComponent } from './staffUserManagement/staffUser.component';
import { VolunteerFormComponent } from './volunteerUserManagement/volunteerUser.component';

@NgModule({
  declarations: [
    AppComponent,
    StaffUserComponent,
    VolunteerFormComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    MdButtonModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatDatepickerModule
  ],
  providers: [StaffUserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
