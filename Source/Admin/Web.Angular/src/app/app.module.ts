
import { NgModule, ModuleWithProviders } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ProjectModule } from './project/project.module';
import { HealthRiskModule } from './healthRisk/healthRisk.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { ModalModule } from 'ngx-bootstrap';
import { AuthenticationService } from 'navigation/authentication.service';
import { IfLoggedInComponent } from 'navigation/if-logged-in.component';
import { NavTopBarComponent } from 'navigation/nav-top-bar.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'project',
        pathMatch: 'full'
    },
    {
        path:'healthrisk',
        redirectTo: 'healthrisk',
        pathMatch:'full',
    }
];

const rootRouting: ModuleWithProviders = RouterModule.forRoot(routes);

@NgModule({
    declarations: [
        AppComponent,
        IfLoggedInComponent,
        NavTopBarComponent
    ],
    imports: [
        BrowserModule,
        SharedModule.forRoot(),
        CoreModule,
        rootRouting,
        ProjectModule,
        HealthRiskModule,
        ModalModule.forRoot()

    ],
    providers: [
        AuthenticationService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
