import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';

import TotalCard from "./TotalCard";

import { CaseReportTotalsQuery } from "../Features/Overview/LastWeekTotals/CaseReportTotalsQuery";
import { QueryCoordinator } from "@dolittle/queries";


export default class LastWeekTotals extends Component {
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
                let json = queryResult.items[0];
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
    }

    render () {
        return (
            <>
                <Grid item xs={3} key="TotalSex" style={{ height: 'auto' }}>
                    <Typography component="h2" variant="headline">
                        No. of cases by gender
                    </Typography>
                    <TotalCard className={"fa fa-female"} subTitle={"Female"} total={this.state.totalFemale}  />
                    <TotalCard className={"fa fa-male"} subTitle={"Male"} total={this.state.totalMale}  />
                </Grid>
                <Grid item xs={3} key="TotalAge" style={{ height: 'auto' }}>
                    <Typography component="h2" variant="headline">
                        No. of cases by age
                    </Typography>
                    <TotalCard className={"fa fa-child"} subTitle={"Under 5"} total={this.state.totalUnder5}  />
                    <TotalCard className={"fa fa-user"} subTitle={"Over 5"} total={this.state.totalOver5}  />
                </Grid>
            </>
        );
    }
}

