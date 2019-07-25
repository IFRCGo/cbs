import React, { Component } from "react";

import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

import { CaseReportTotalsQuery } from "../../Features/Overview/LastWeekTotals/CaseReportTotalsQuery";
import { QueryCoordinator } from "@dolittle/queries";

import './last-week-totals.scss';

export default class LastWeekTotals extends Component {
    constructor(props) {
        super(props);

        this.state = {
            femalesUnder5: "-",
            malesUnder5: "-",
            femalesOver5: "-",
            malesOver5: "-",
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
                    femalesUnder5: parseInt(json.femalesUnder5),
                    malesUnder5: parseInt(json.malesUnder5),
                    femalesOver5: parseInt(json.femalesOver5),
                    malesOver5: parseInt(json.malesOver5),
                    isLoading: false,
                    isError: false
                });
            }
        }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            })
        })
    }

    componentDidMount() {
        this.fetchLastWeekTotals();
    }

    render () {
        var totalUnder5 = this.state.femalesUnder5 + this.state.malesUnder5;
        var totalOver5 = this.state.femalesOver5 + this.state.malesOver5;
        var totalFemale = this.state.femalesUnder5 + this.state.femalesOver5;
        var totalMale = this.state.malesUnder5 + this.state.malesOver5;

        return (
            <div className="tableContainer">
                <h2 className="headline">Reports per sex and age (last 7 days)</h2>
                <Table className="table">
                    <TableHead className="tableHead">
                        <TableRow>
                            <TableCell className="headerText">Age</TableCell>
                            <TableCell className="headerText center"> <i className="fa fa-venus"> </i> Female</TableCell>
                            <TableCell className="headerText center"> <i className="fa fa-mars"></i> Male</TableCell>
                            <TableCell className="headerText">Total</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        <TableRow>
                            <TableCell className="cell">Under 5</TableCell>
                            <TableCell className="cell center">{this.state.femalesUnder5}</TableCell>
                            <TableCell className="cell center">{this.state.malesUnder5}</TableCell>
                            <TableCell className="cell center">{isNaN(totalUnder5) ? "-" : totalUnder5}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell className="cell">5 and above</TableCell>
                            <TableCell className="cell center">{this.state.femalesOver5}</TableCell>
                            <TableCell className="cell center">{this.state.malesOver5}</TableCell>
                            <TableCell className="cell center">{isNaN(totalOver5) ? "-" : totalOver5}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell className="cell">Total</TableCell>
                            <TableCell className="cell center">{isNaN(totalFemale) ? "-" : totalFemale}</TableCell>
                            <TableCell className="cell center">{isNaN(totalMale) ? "-" : totalMale}</TableCell>
                            <TableCell className="cell center">{isNaN(totalFemale + totalMale) ? "-" : totalFemale + totalMale}</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </div>
        );
    }
}