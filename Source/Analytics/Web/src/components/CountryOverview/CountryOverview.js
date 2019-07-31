import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import OverviewTop from '../OverviewTop/OverviewTop.js';
import Map from "../Map.js";
import CBSNavigation from '../Navigation/CBSNavigation';
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
        let body = {
            margin: 10,
        }
        return (
            <>
                <CBSNavigation activeMenuItem="analytics" />

                <div className="analytics--container" style={body}>
                    <h1 className="headerText center">Country overview</h1>
                    <OverviewTop />
                    <h2 className="headerText">Geopraphic overview of reports</h2>
                    <Map />
                    <Grid container spacing={0}>
                        <Grid item xs={12} sm={6} md={6}>
                            <LastWeekTotals />
                        </Grid>
                    </Grid>
                    <HealthRiskSelector />
                </div>
            </>
        );
    }
}

export default CountryOverview;