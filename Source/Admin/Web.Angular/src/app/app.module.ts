import { CartService } from './cart/cart.service';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CartComponent } from './cart/cart.component';
import { ProjectModule } from './project/project.module';
import { CoreModule } from './core/core.module';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'project',
        pathMatch: 'full'
    }
];

@NgModule({
    declarations: [
        AppComponent,
        CartComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        CoreModule,
        RouterModule.forRoot(routes),
        ProjectModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
