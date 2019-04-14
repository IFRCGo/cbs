import { environment } from './environments/environment';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';


const appInsights = new ApplicationInsights({
  config: {
    instrumentationKey: environment.appInsightsInstrumentationKey
  }
});
appInsights.loadAppInsights();

export default appInsights;