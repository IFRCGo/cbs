import React, { Component } from "react";

import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';

import { CaseReportTotalsQuery } from "../../Features/Overview/LastWeekTotals/CaseReportTotalsQuery";
import { QueryCoordinator } from "@dolittle/queries";

import './last-week-totals.scss';

export default class LastWeekTotals extends Component {
    constructor(props) {
        super(props);

        this.state = {
            femalesUnder5: "5",
            malesUnder5: "7",
            femalesOver5: "12",
            malesOver5: "3",
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
                    femalesUnder5: json.femalesUnder5,
                    malesUnder5: json.malesUnder5,
                    femalesOver5: json.femalesOver5,
                    malesOver5: json.malesOver5,
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
        var totalUnder5 = parseInt(this.state.femalesUnder5) + parseInt(this.state.malesUnder5);
        var totalOver5 = parseInt(this.state.femalesOver5) + parseInt(this.state.malesOver5);
        var totalFemale = parseInt(this.state.femalesUnder5) + parseInt(this.state.femalesOver5);
        var totalMale = parseInt(this.state.malesUnder5) + parseInt(this.state.malesOver5);
        
        var tableStyle = {
            fontFamily: "Lato"
        }
        return (
            <div class="tableContainer">
                <h1 className="headline">Reports per sex and age (last 7 days)</h1>
                <Paper>
                    <Table style={tableStyle}>
                        <TableHead className="tableHead">
                            <TableRow>
                                <TableCell className="headerText">Age</TableCell>
                                <TableCell className="headerText">Female <i class="fa fa-venus"></i></TableCell>
                                <TableCell className="headerText">Male <i class="fa fa-mars"></i></TableCell>
                                <TableCell className="headerText">Total</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <TableRow>
                                <TableCell>Under 5</TableCell>
                                <TableCell>{this.state.femalesUnder5}</TableCell>
                                <TableCell>{this.state.malesUnder5}</TableCell>
                                <TableCell>{totalUnder5}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>5 and above</TableCell>
                                <TableCell>{this.state.femalesOver5}</TableCell>
                                <TableCell>{this.state.malesOver5}</TableCell>
                                <TableCell>{totalOver5}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Total</TableCell>
                                <TableCell>{totalFemale}</TableCell>
                                <TableCell>{totalMale}</TableCell>
                                <TableCell>{totalFemale + totalMale}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </Paper>
            </div>
        );
    }
}