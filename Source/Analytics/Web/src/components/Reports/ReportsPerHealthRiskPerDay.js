import React, { Component } from "react";
import { CaseReportsPerHealthRiskPerDayQuery } from "../../Features/CaseReports/CaseReportsPerHealthRiskPerDayQuery";
import { AllRegions } from '../../Features/DataCollectors/AllRegions';
import { QueryCoordinator } from "@dolittle/queries";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

export default class ReportsPerHealthRiskPerDay extends Component {
    constructor(props) {
        super(props);

        this.state = {
            reportsPerHealthRisk: [],
            regions: [],
            isLoading: true,
            isError: false
        };
    }

    fetchAllRegions() {
        const allRegionsQuery = new AllRegions();
        this.queryCoordinator.execute(allRegionsQuery).then(result => {
            if (result.success) {
                this.setState({
                    regions: result.items
                });
            }
        }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            });
        });
    }

    fetchReportsPerHealthRiskLastWeek() {
        const reportsPerHealthRisk = new CaseReportsPerHealthRiskPerDayQuery();
        reportsPerHealthRisk.numberOfDays = 7;

        this.queryCoordinator.execute(reportsPerHealthRisk).then(queryResult => {
            if (queryResult.success && queryResult.items.length > 0) {
                const json = queryResult.items;
                this.setState({
                    reportsPerHealthRisk: json,
                    isLoading: false,
                    isError: false
                });
            }
        }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            });
        }
        );
    }

    componentDidMount() {
        this.queryCoordinator = new QueryCoordinator();
        this.fetchAllRegions();
        this.fetchReportsPerHealthRiskLastWeek();
    }

    renderReports(region) {
        if (this.state.reportsPerHealthRisk.length > 0) {
            return this.state.reportsPerHealthRisk.map((report, i) => {
                const reports = report.reportsPerHealthRisk[this.props.selectedHealthRisk];
                if (reports != null) {
                    const reportsInRegion = reports[region];
                    if (reportsInRegion != null)
                        return <TableCell className="cell" align="center" key={i}>{reportsInRegion}</TableCell>;
                    else
                        return <TableCell className="cell" align="center" key={i}>-</TableCell>;
                } else {
                    return <TableCell className="cell" align="center" key={i}>-</TableCell>;
                }
            });
        }
    }

    renderRegions() {
        return this.state.regions.map(region => (
            <TableRow key={region.name}>
                <TableCell className="headerText" className="cell" align="center">{region.name}</TableCell>
                {this.renderReports(region.name)}
            </TableRow>)
        );
    }

    renderDays() {
        return this.state.reportsPerHealthRisk.map(report => {
            const day = new Date(report.timestamp).toDateString();
            return <TableCell className="headerText" align="center" key={report.id}>{day}</TableCell>
        });
    }

    render() {
        return (
            <Table className="table">
                <TableHead className="tableHead">
                    <TableRow>
                        <TableCell className="headerText">Region</TableCell>
                        {this.renderDays()}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {this.renderRegions()}
                </TableBody>
            </Table>
        );
    }
}
