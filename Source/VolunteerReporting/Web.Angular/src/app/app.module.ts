import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CaseReportModule } from './case-report/case-report.module';
import { CoreModule } from './core/core.module';
import { NavTopBarComponent } from 'navigation/nav-top-bar.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'case-report',
        pathMatch: 'full'
    }
];

@NgModule({
    declarations: [
        AppComponent,
        NavTopBarComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        CoreModule,
        RouterModule.forRoot(routes),
        CaseReportModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
