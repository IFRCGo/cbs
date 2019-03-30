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

import { ModalModule } from 'ngx-bootstrap';
import { NgxSmartModalModule } from 'ngx-smart-modal';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

import { DataCollectorExportService } from './Management/DataCollectors/DataCollectorExportService';
import { DataCollectorsModule } from './Management/DataCollectors/DataCollectors.module';
import { CaseReportModule } from './Reporting/reporting.module';

import { SharedModule} from './shared/shared.module';


const routes: Routes = [
    {
      path: '',
      redirectTo: 'case-reports',
      pathMatch: 'full'
    }
];

@NgModule({
  declarations: [
    AppComponent,
    IfLoggedInComponent,
    NavTopBarComponent
  ],
  imports: [
    BrowserModule,
    SharedModule.forRoot(),
    AgmCoreModule.forRoot({
        apiKey: 'AIzaSyCB2IPddbweufj2myYTB4NhlLmpr58kU04'
    }),

    CommonModule,
    HttpClientModule,
    HttpModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxSmartModalModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    RouterModule.forRoot(routes),
    DataCollectorsModule,
    CaseReportModule
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