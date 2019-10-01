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
import { NavbarHostComponent } from './navigation/navbar-host.component';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

import { ModalModule } from 'ngx-bootstrap';

import { DataCollectorExportService } from './Management/DataCollectors/DataCollectorExportService';
import { DataCollectorsModule } from './Management/DataCollectors/DataCollectors.module';
import { CaseReportModule } from './Reporting/reporting.module';

import { SharedModule} from './shared/shared.module';

import { environment } from '../environments/environment';

const routes: Routes = [
    {
      path: '',
      redirectTo: 'case-reports',
      pathMatch: 'full'
    }
];

// Note: This base URL is set due to navigation being a dependency pulled into this
NavbarHostComponent.apiBaseUrl = environment.api;

@NgModule({
  declarations: [
    AppComponent,
    NavbarHostComponent,
  ],
  imports: [
    BrowserModule,
    SharedModule.forRoot(),
    AgmCoreModule.forRoot({
        apiKey: 'AIzaSyCB2IPddbweufj2myYTB4NhlLmpr58kU04'
    }),

    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ModalModule.forRoot(),
    RouterModule.forRoot(routes),
    DataCollectorsModule,
    CaseReportModule
  ],
  providers: [
    CommandCoordinator,
    QueryCoordinator,
    DataCollectorExportService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}