import React, { Component } from "react";
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import OverviewTop from '../OverviewTop/OverviewTop.js';
import Map from "../Map.js";
import CBSNavigation from '../Navigation/CBSNavigation';
import HealthRiskSelector from "../healthRisk/HealthRiskSelector";

import './CountryOverview.scss';

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
                <h1 className="header-text title">Country overview</h1>
                <OverviewTop />
                <div className="analytics--container" style={body}>
                    <h2 className="header-text">Geopraphic overview of reports</h2>
                    <Map />
                    <HealthRiskSelector />
                </div>
            </>
        );
    }
}

export default CountryOverview;