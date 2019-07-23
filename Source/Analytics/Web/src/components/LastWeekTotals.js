import React, { Component } from "react";

import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';


import TotalCard from "./TotalCard";

import { CaseReportTotalsQuery } from "../Features/Overview/LastWeekTotals/CaseReportTotalsQuery";
import { QueryCoordinator } from "@dolittle/queries";



export default class LastWeekTotals extends Component {
    constructor(props) {
        super(props);

        this.state = {
            totalFemale: "5",
            totalMale: "6",
            totalUnder5: "7",
            totalOver5: "8",
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

    /*
    Table
    TableBody
    TableCell
    TableHead
    TableRow
    Typography
    Paper
    */
    render () {
        var femalesUnder5 = parseInt(this.state.totalFemale) + parseInt(this.state.totalMale) - parseInt(this.state.totalOver5); //wrong logic!
        var malesUnder5 = parseInt(this.state.totalFemale) + parseInt(this.state.totalMale) - parseInt(this.state.totalOver5);

        return (
            <Paper>
                <Table>
                    <TableHead>Reports per sex and age (last 7 days)</TableHead>
                    <TableRow>
                        <TableCell>Age</TableCell>
                        <TableCell>Female</TableCell>
                        <TableCell>Male</TableCell>
                        <TableCell>Total</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Under 5</TableCell>
                        <TableCell>{femalesUnder5}</TableCell>
                        <TableCell>{malesUnder5}</TableCell>
                        <TableCell>{this.state.totalUnder5}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>5 and above</TableCell>
                        <TableCell>{femalesUnder5}</TableCell>
                        <TableCell>{malesUnder5}</TableCell>
                        <TableCell>{this.state.totalUnder5}</TableCell>
                    </TableRow>
                    <TableRow>
                        <TableCell>Total</TableCell>
                        <TableCell>{this.state.totalFemale}</TableCell>
                        <TableCell>{this.state.totalMale}</TableCell>
                        <TableCell>{parseInt(this.state.totalFemale)+parseInt(this.state.totalMale)}</TableCell>
                    </TableRow>
                </Table>
            </Paper>
        );
    }
}
/*
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

            */