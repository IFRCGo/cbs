import React, { Component } from "react";
import { CaseReportsPerHealthRiskPerDayQuery } from "../../Features/CaseReports/CaseReportsPerHealthRiskPerDayQuery";
import { QueryCoordinator } from "@dolittle/queries";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';


export default class ReportsPerHealthRiskPerDay extends Component {
    constructor(props) {
        super(props);

        this.state = {
            reportsPerHealthRisk: [],
            healthRisks: [''],
            selectedHealthRisk: '',
            isLoading: true,
            isError: false
        };
    }

    fetchReportsPerHealthRiskLastWeek() {
        this.queryCoordinator = new QueryCoordinator();
        const reportsPerHealthRisk = new CaseReportsPerHealthRiskPerDayQuery();
        reportsPerHealthRisk.numberOfDays = 7;

        this.queryCoordinator.execute(reportsPerHealthRisk).then(queryResult => {
            if (queryResult.success && queryResult.items.length > 0) {
                const json = queryResult.items;
                var healthRisks = this.getAllHealthRisksFromReports(json);
                this.setState({
                    reportsPerHealthRisk: json,
                    healthRisks: healthRisks,
                    selectedHealthRisk: healthRisks[0],
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

    getAllHealthRisksFromReports(reports) {
        const healthRisks = [];
        reports.forEach(report => {
            var risks = Object.keys(report.reportsPerHealthRisk);
            risks.forEach(risk => {
                if (healthRisks.indexOf(risk) < 0) {
                    healthRisks.push(risk);
                }
            })
        });
        return healthRisks;
    }

    componentDidMount() {
        this.fetchReportsPerHealthRiskLastWeek();
    }

    saveSelectedValue(event) {
        this.setState({
            selectedHealthRisk: event.target.value
        });
    }

    renderReports() {
        if (this.state.reportsPerHealthRisk.length > 0) {
            this.state.reportsPerHealthRisk.map(report => {
                const reports = report.reportsPerHealthRisk[this.state.selectedHealthRisk];
                const keys = Object.keys(reports);
                return keys.map(key => {
                    return (
                        <TableRow key={key}>
                            <TableCell>{key}</TableCell>
                            <TableCell>{reports[key]}</TableCell>
                        </TableRow>
                    );
                });
            });
        }
    }

    renderOptions() {
        return this.state.healthRisks.map(healthRisk => <MenuItem key={healthRisk} value={healthRisk}>{healthRisk}</MenuItem>);
    }

    renderDays() {
        return this.state.reportsPerHealthRisk.map(report => <TableCell key={report.id}>{report.id}</TableCell>);
    }

    render() {
        return (
            <div>
                <h3>Reports for </h3>
                <Select
                    value={this.state.selectedHealthRisk}
                    onChange={this.saveSelectedValue.bind(this)}
                >
                    {this.renderOptions()}
                </Select>

                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Region</TableCell>
                            {this.renderDays()}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {this.renderReports()}
                    </TableBody>
                </Table>
            </div>
        );
    }
}
