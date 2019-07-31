import React, { Component } from "react";
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
                <h1 style={{textAlign: "center", fontFamily: "Lato"}}>CountryOverview</h1>
                <OverviewTop />
                <div className="analytics--container" style={body}>
                    <Map />
                    <Grid container spacing={0}>
                        <Grid item xs={12} sm={6} md={4}>
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