
import { NgModule, ModuleWithProviders } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from './shared/shared.module';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ProjectModule } from './Projects/projects.module';
import { HealthRiskModule } from './HealthRisks/healthRisks.module';

import { CoreModule } from './core/core.module';
import { ModalModule } from 'ngx-bootstrap';
import { NavbarHostComponent } from './navigation/navbar-host.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

import { environment } from '../environments/environment';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'projects',
        pathMatch: 'full'
    },
    {
        path: 'healthrisks',
        redirectTo: "healthrisks",
        pathMatch: "full"
    },

];

// Note: This base URL is set due to navigation being a dependency pulled into this
NavbarHostComponent.apiBaseUrl = environment.api;

const rootRouting: ModuleWithProviders = RouterModule.forRoot(routes);

@NgModule({
    declarations: [
        AppComponent,
        NavbarHostComponent
    ],
    imports: [
        BrowserModule,
        SharedModule.forRoot(),
        CoreModule,
        rootRouting,
        ProjectModule,
        HealthRiskModule,
        BrowserAnimationsModule,
        ModalModule.forRoot(),
        ToastrModule.forRoot()
    ],
    providers: [
        CommandCoordinator,
        QueryCoordinator
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
