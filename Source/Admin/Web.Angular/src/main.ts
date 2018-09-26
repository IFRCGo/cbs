import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import { QueryCoordinator } from '@dolittle/queries';
import { CommandCoordinator } from '@dolittle/commands';

if (environment.production) {
  enableProdMode();
}

QueryCoordinator.apiBaseUrl = environment.api;
CommandCoordinator.apiBaseUrl = environment.api;

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.log(err));


