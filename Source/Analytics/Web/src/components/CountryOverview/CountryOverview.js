import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import CountryKeyFigures from '../CountryKeyFigures/CountryKeyFigures.js';
import Map from "../Map.js";
import CBSNavigation from 'navigation';
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
    constructor(props) {
        super(props);

        this.state = {
            username: 'Unknown'
        };
    }

    componentDidMount() {
        appInsights.trackPageView({ name: 'Country Overview' });
        fetch(`${process.env.API_BASE_URL}/identity`).then(async response => this.setState({
            username: await response.text()
        }));
    }

    render() {
        return (
            <>
                <Grid container justify="center">

                    <Grid item xs={12}>
                        <CBSNavigation activeMenuItem="analytics" username={this.state.username} baseUrl={process.env.API_BASE_URL} />
                    </Grid>

                    <Grid container item xs={11} sm={10} spacing={0}>
                        <Grid item xs={12}>
                            <h1 className="jumbotron">Country Overview</h1>
                        </Grid>

                        <Grid item xs={12}>
                            <CountryKeyFigures />
                        </Grid>

                        <Grid item xs={12}>
                            <Map />
                        </Grid>

                        <Grid item container xs={12}>
                            <Grid item md={6} xs={12}>
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