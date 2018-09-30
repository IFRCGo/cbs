import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AgmCoreModule } from '@agm/core';

import { AppComponent } from './app.component';
import { AuthenticationService } from 'navigation/authentication.service';
import { IfLoggedInComponent } from 'navigation/if-logged-in.component';
import { NavTopBarComponent } from 'navigation/nav-top-bar.component';

import { USER_DETAIL_ROUTES } from './DataCollectors/datacollector-detail';
import { ModalModule } from 'ngx-bootstrap';
import { DataCollectorListComponent } from './DataCollectors/datacollector-list/datacollector-list.component';
import { DataCollectorRegisterComponent } from './DataCollectors/datacollector-register/datacollector-register.component';
import { DataCollectorDetailComponent } from './DataCollectors/datacollector-detail/datacollector-detail.component';
import { DataCollectorDeleteComponent } from './DataCollectors/datacollector-delete/datacollector-delete.component';
import { DataCollectorEditComponent } from './DataCollectors/datacollector-edit/datacollector-edit.component';
import { DataCollectorExportComponent } from './DataCollectors/datacollector-export/datacollector-export.component';
import { NgxSmartModalModule } from 'ngx-smart-modal';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

import { DataCollectorExportService } from './DataCollectors/DataCollectorExportService';


const appRoutes: Routes = [
  ...USER_DETAIL_ROUTES,
  { path: 'list', component: DataCollectorListComponent },
  { path: '', component: DataCollectorListComponent },
  { path: '**', component: DataCollectorListComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    IfLoggedInComponent,
    NavTopBarComponent,
    DataCollectorListComponent,
    DataCollectorRegisterComponent,
    DataCollectorDeleteComponent,
    DataCollectorEditComponent,
    DataCollectorDetailComponent,
    DataCollectorExportComponent
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
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    NgxSmartModalModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCB2IPddbweufj2myYTB4NhlLmpr58kU04'
    })
  ],
  providers: [
    AuthenticationService,
    CommandCoordinator,
    QueryCoordinator,
    DataCollectorExportService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
