import React, { Component } from "react";
import GridList from '@material-ui/core/GridList';
import Typography from '@material-ui/core/Typography';
import GridListTile from '@material-ui/core/GridListTile';
import ListSubheader from '@material-ui/core/ListSubheader';
import {ApplicationInsights} from '@microsoft/applicationinsights-web';
import CaseReportByHealthRiskTable from "./healthRisk/CaseReportByHealthRiskTable";
import HealthRiskPerDistrictTable from "./healthRisk/HealthRiskPerDistrictTable";
import TotalCard from "./TotalCard";
import Map from "./Map.js";
import CBSNavigation from './Navigation/CBSNavigation';
import { CaseReportTotalsQuery } from "../Features/Overview/LastWeekTotals/CaseReportTotalsQuery";
import { QueryCoordinator } from "@dolittle/queries";

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
    
    fetchLastWeekTotals() {
        this.queryCoordinator = new QueryCoordinator();
        let caseReportTotals = new CaseReportTotalsQuery();

        this.queryCoordinator.execute(caseReportTotals).then(queryResult => {
            if(queryResult.success){
                let json = queryResult.items[0]; //We get many items here – how to display "LastWeek"?
                this.setState({
                    totalFemale: json.female,
                    totalMale: json.male,
                    totalUnder5: json.under5,
                    totalOver5: json.over5,
                    isLoading: false,
                    isError: false
                });
            }
        }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            })
        }
        )
    }

    componentDidMount() {
        this.fetchLastWeekTotals();
        
        appInsights.trackPageView({ name: 'National society overview'});
    }


    render() {
        return (
            <div className="analytics--container">
                <CBSNavigation />
                <Typography component="h2" variant="headline" gutterBottom>
                    Overview
                </Typography>

                <GridList cols={4}>
                    <GridListTile key="CaseReportByHealthRiskTable" cols={2} style={{ height: 'auto' }}>
                        <CaseReportByHealthRiskTable />
                    </GridListTile>

                    <GridListTile cols={1} key="TotalSex" style={{ height: 'auto' }}>
                        <Typography component="h2" variant="headline">
                            No. of cases by gender
                        </Typography>
                        <TotalCard className={"fa fa-female"} subTitle={"Female"} total={this.state.totalFemale}  />
                        <TotalCard className={"fa fa-male"} subTitle={"Male"} total={this.state.totalMale}  />
                    </GridListTile>
                    <GridListTile cols={1} key="TotalAge" style={{ height: 'auto' }}>
                        <Typography component="h2" variant="headline">
                            No. of cases by age
                        </Typography>
                        <TotalCard className={"fa fa-child"} subTitle={"Under 5"} total={this.state.totalUnder5}  />
                        <TotalCard className={"fa fa-user"} subTitle={"Over 5"} total={this.state.totalOver5}  />
                    </GridListTile>

                </GridList>
                <HealthRiskPerDistrictTable />
                <Map />
            </div>
        );
    }
}

export default NationalSocietyOverview;