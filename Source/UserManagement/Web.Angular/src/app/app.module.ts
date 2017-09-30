import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { MdButtonModule, MatInputModule, MatDatepickerModule, MatRadioModule, MatSelectModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTabsModule} from '@angular/material';

import { StaffUserService } from './staffUserManagement/staffUser.service';
import { DataCollectorService } from './dataCollectorManagement/dataCollector.service';

import { AppComponent } from './app.component';
import { StaffUserComponent } from './staffUserManagement/staffUser.component';
import { DataCollectorFormComponent } from './dataCollectorManagement/dataCollector.component';
import { HomeComponent } from './homeComponent/home.component';
import {UiTestComponent} from './userManagement/formuielement/ui-component/ui-Test.component';

@NgModule({
  declarations: [
    AppComponent,
    StaffUserComponent,
    DataCollectorFormComponent,
    HomeComponent,
    UiTestComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    MdButtonModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatTabsModule,
    MatSelectModule
  ],
  providers: [StaffUserService, DataCollectorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
