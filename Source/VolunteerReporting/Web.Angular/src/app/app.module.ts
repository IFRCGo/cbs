import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { CaseReportModule } from './case-report/case-report.module';
import { AuthenticationService } from 'navigation/authentication.service';
import { IfLoggedInComponent } from 'navigation/if-logged-in.component';
import { NavTopBarComponent } from 'navigation/nav-top-bar.component';
import { HttpClientModule } from '@angular/common/http';

import * as fromServices from './services';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'case-report',
        pathMatch: 'full'
    }, 
    {
      path: 'reporting',
      redirectTo: 'case-report',
      pathMatch: 'full'
    },
];

@NgModule({
    declarations: [
        AppComponent,
        IfLoggedInComponent,
        NavTopBarComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpClientModule,
        HttpModule,
        NoopAnimationsModule,
        RouterModule.forRoot(routes),
        CaseReportModule
    ],
    providers: [
        AuthenticationService,
        fromServices.QueryCoordinator,
        fromServices.LogService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
