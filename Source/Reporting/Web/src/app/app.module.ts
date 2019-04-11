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
import { NavTopBarComponent } from 'navigation/nav-top-bar.component';

import { ModalModule } from 'ngx-bootstrap';
import { NgxSmartModalModule } from 'ngx-smart-modal';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

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
NavTopBarComponent.apiBaseUrl = environment.api;

@NgModule({
  declarations: [
    AppComponent,
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
    {
      provide: CommandCoordinator,
      useClass: environment.commandCoordinatorType
    },
    {
      provide: QueryCoordinator,
      useClass: environment.queryCoordinatorType
    },
    DataCollectorExportService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}