import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatInputModule, MatDatepickerModule, MatRadioModule, MatSelectModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { StaffUserService } from './staffUserManagement/staffUser.service';
import { DataCollectorService } from './dataCollectorManagement/dataCollector.service';

import { AppComponent } from './app.component';
import { StaffUserComponent } from './staffUserManagement/staffUser.component';
import { DataCollectorFormComponent } from './dataCollectorManagement/dataCollector.component';
import { HomeComponent } from './homeComponent/home.component';

import { MatIconModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    StaffUserComponent,
    DataCollectorFormComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatTabsModule,
    MatSelectModule,
    NgbModule.forRoot()
  ],
  providers: [StaffUserService, DataCollectorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
