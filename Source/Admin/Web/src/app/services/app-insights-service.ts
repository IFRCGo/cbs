import { environment } from '../../environments/environment';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import { Injectable } from '@angular/core';


@Injectable()
export class AppInsightsService {
  constructor() { }

  trackPageView(page: string) {
    const appInsights = new ApplicationInsights({
      config: {
        instrumentationKey: environment.appInsightsInstrumentationKey,
        maxBatchInterval: 0
      }
    });
    appInsights.loadAppInsights();
    appInsights.trackPageView({name: page});
    appInsights.flush();
  }
}