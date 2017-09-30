import { StaffUserService } from './staffUserManagement/staffUser.service';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { StaffUserComponent } from './staffUserManagement/staffUser.component';
import { VolunteerFormComponent } from './volunteerUserManagement/volunteerUser.component';
import { InputFieldComponent } from './input-field/input-field.component';

@NgModule({
  declarations: [
    AppComponent,
    StaffUserComponent,
    VolunteerFormComponent,
    InputFieldComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [StaffUserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
