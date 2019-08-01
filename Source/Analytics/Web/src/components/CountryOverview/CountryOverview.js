import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import OverviewTop from '../OverviewTop/OverviewTop.js';
import Map from "../Map.js";
import CBSNavigation from '../../../node_modules/navigation/lib/index.js';
import HealthRiskSelector from "../healthRisk/HealthRiskSelector";
import LastWeekTotals from "../lastWeekTotals/LastWeekTotals";

const appInsights = new ApplicationInsights({
    config: {
        instrumentationKey: process.env.REACT_APP_APP_INSIGHTS_INSTRUMENTATION_KEY,
        maxBatchInterval: 0,
        disableFetchTracking: false
    }
});
appInsights.loadAppInsights();

class CountryOverview extends Component {
    componentDidMount() {
        appInsights.trackPageView({ name: 'Country Overview' });
    }

    render() {
        return (
            <>
                <CBSNavigation activeMenuItem="analytics" />
                <Grid container justify="center">
                    <Grid container item xs={10} spacing={0}>
                        <Grid item xs={12}>
                            <h1 className="jumbotron">Country Overview</h1>
                        </Grid>
                    
                        <Grid item xs={12}>
                            <OverviewTop />
                        </Grid>

                        <Grid item xs={12}>
                            <Map />
                        </Grid>

                        <Grid item container xs={12}>
                            <Grid item xs={4}>
                                <LastWeekTotals />
                            </Grid>
                        </Grid>

                        <Grid item xs={12}>
                            <HealthRiskSelector />
                        </Grid>
                    </Grid>
                </Grid>
            </>
        );
    }
}

export default CountryOverview;