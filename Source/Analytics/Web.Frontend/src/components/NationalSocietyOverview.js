import React, { Component } from "react";
import GridList from '@material-ui/core/GridList';
import Typography from '@material-ui/core/Typography';
import GridListTile from '@material-ui/core/GridListTile';
import ListSubheader from '@material-ui/core/ListSubheader';
import {ApplicationInsights} from '@microsoft/applicationinsights-web';
import CaseReportByHealthRiskTable from "./healthRisk/CaseReportByHealthRiskTable";
import TotalCard from "./TotalCard";
import { getJson } from "../utils/request";
import { formatDate } from "../utils/dateUtils";
import HealthRiskPerDistrictBarCharts from "./healthRisk/HealthRiskPerDistrictBarCharts";
import Map from "./Map.js";

const appInsights = new ApplicationInsights({
    config: {
        instrumentationKey: process.env.REACT_APP_APP_INSIGHTS_INSTRUMENTATION_KEY,
        maxBatchInterval: 0,
        disableFetchTracking: false
    }
});
appInsights.loadAppInsights();
export const BASE_URL = process.env.API_BASE_URL;

class NationalSocietyOverview extends Component {
    constructor(props) {
        super(props);

        this.state = {
            totalFemale: "-",
            totalMale: "-",
            totalUnder5: "-",
            totalOver5: "-",
            isLoading: true,
            isError: false
        };
    }
    
    fetchData() {

        let oneWeekBack = new Date();
        oneWeekBack.setDate(oneWeekBack.getDate()-6);
        this.url = `${BASE_URL}CaseReport/Totals/${formatDate(oneWeekBack)}/${formatDate(new Date())}/`;

        this.setState({ isLoading: true });

        getJson(this.url)
            .then(json =>
                this.setState({
                    totalFemale: json.female,
                    totalMale: json.male,
                    totalUnder5: json.under5,
                    totalOver5: json.over5,
                    isLoading: false,
                    isError: false
                })
            )
            .catch(_ =>
                this.setState({
                    isLoading: false,
                    isError: true
                })
            );
    }

    componentDidMount() {
        this.fetchData();
        appInsights.trackPageView({ name: 'National society overview'});
    }


    render() {
        return (
            <div className="analytics--container">
            <Typography component="h2" variant="headline" gutterBottom>
          Overview
        </Typography>
            <GridList cols={4}>
        <GridListTile key="CaseReportByHealthRiskTable" cols={2} style={{ height: 'auto' }}>
        <ListSubheader component="div">No. of case reports per health risk per time period.</ListSubheader>
        <CaseReportByHealthRiskTable />
        </GridListTile>
        <GridListTile cols={1} key="TotalSex" style={{ height: 'auto' }}>
        <TotalCard className={"fa fa-female"} subTitle={"Female"} total={this.state.totalFemale}  />
        <TotalCard className={"fa fa-male"} subTitle={"Male"} total={this.state.totalMale}  />
        </GridListTile>
        <GridListTile cols={1} key="TotalAge" style={{ height: 'auto' }}>
        <TotalCard subTitle={"Under 5"} total={this.state.totalUnder5}  />
        <TotalCard subTitle={"Over 5"} total={this.state.totalOver5}  />
        </GridListTile>

     
        </GridList>
        <HealthRiskPerDistrictBarCharts />
        <Map />
            </div>
        );
    }
}

export default NationalSocietyOverview;
