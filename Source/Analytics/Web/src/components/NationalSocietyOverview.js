import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import CaseReportByHealthRiskTable from "./healthRisk/CaseReportByHealthRiskTable";
import HealthRiskPerRegionLastWeekTable from "./healthRisk/HealthRiskPerRegionLastWeekTable";
import LastWeekTotals from './lastWeekTotals/LastWeekTotals.js';
import Map from "./Map.js";
import CBSNavigation from './Navigation/CBSNavigation';

const appInsights = new ApplicationInsights({
    config: {
        instrumentationKey: process.env.REACT_APP_APP_INSIGHTS_INSTRUMENTATION_KEY,
        maxBatchInterval: 0,
        disableFetchTracking: false
    }
});
appInsights.loadAppInsights();

class NationalSocietyOverview extends Component {
    componentDidMount() {
        appInsights.trackPageView({ name: 'National society overview' });
    }

    render() {
        let body = {
            margin: 10,
        }
        return (
            <>
                <CBSNavigation />

                <div className="analytics--container" style={body}>
                    <Typography component="h2" variant="headline" gutterBottom> Overview </Typography>

                    <Grid container spacing={8}>
                        <Grid item md={12} lg={6} key="CaseReportByHealthRiskTable">
                            <CaseReportByHealthRiskTable />
                        </Grid>
                        <Grid item md={12} lg={6} key="LastWeekTotals">
                            <LastWeekTotals />
                        </Grid>

                        <Grid item xs={12} key="HealthRiskPerRegionLastWeekTable">
                            <HealthRiskPerRegionLastWeekTable />
                        </Grid>
                    </Grid>

                    {/*<Map />*/}
                </div>
            </>
        );
    }
}

export default NationalSocietyOverview;