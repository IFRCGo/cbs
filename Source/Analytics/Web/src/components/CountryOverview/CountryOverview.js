import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import CaseReportByHealthRiskTable from "../healthRisk/CaseReportByHealthRiskTable";
import HealthRiskPerDistrictTable from "../healthRisk/HealthRiskPerDistrictTable";
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
        appInsights.trackPageView({ name: 'National society overview' });
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

                    <Grid container spacing={8}>
                        <Grid item xs={6} key="CaseReportByHealthRiskTable" style={{ height: 'auto' }}>
                            <CaseReportByHealthRiskTable />
                        </Grid>
                    </Grid>

                    <HealthRiskPerDistrictTable />
                    <CaseReportByHealthRiskTable />

                    <h2 className="header-text">Geopraphic overview of reports</h2>
                    <Map />
                    <HealthRiskSelector />
                </div>
            </>
        );
    }
}

export default CountryOverview;