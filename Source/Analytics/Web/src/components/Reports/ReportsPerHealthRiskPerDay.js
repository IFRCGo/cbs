import React, { Component } from "react";
import { CaseReportsPerHealthRiskPerDayQuery } from "../../Features/CaseReports/CaseReportsPerHealthRiskPerDayQuery";
import { AllRegions } from '../../Features/DataCollectors/AllRegions';
import { QueryCoordinator } from "@dolittle/queries";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import './ReportsPerHealthRiskPerDay.scss';


export default class ReportsPerHealthRiskPerDay extends Component {
    constructor(props) {
        super(props);

        this.state = {
            reportsPerHealthRisk: [],
            regions: [],
            healthRisks: [''],
            selectedHealthRisk: '',
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
        this.queryCoordinator = new QueryCoordinator();
        this.fetchAllRegions();
        this.fetchReportsPerHealthRiskLastWeek();
    }

    saveSelectedValue(event) {
        this.setState({
            selectedHealthRisk: event.target.value
        });
    }

    renderReports(region) {
        if (this.state.reportsPerHealthRisk.length > 0) {
            return this.state.reportsPerHealthRisk.map((report, i) => {
                const reports = report.reportsPerHealthRisk[this.state.selectedHealthRisk];
                const reportsInRegion = reports[region];
                if (reportsInRegion != null)
                    return <TableCell className="cell" key={i}>{reportsInRegion}</TableCell>;
                else
                    return <TableCell className="cell" key={i}>-</TableCell>;
            });
        }
    }

    renderRegions() {
        return this.state.regions.map(region => {
            return (
                <TableRow key={region.name}>
                    <TableCell className="headerText" className="cell">{region.name}</TableCell>
                    {this.renderReports(region.name)}
                </TableRow>)
        });
    }

    renderOptions() {
        return this.state.healthRisks.map(healthRisk => <MenuItem key={healthRisk} value={healthRisk}>{healthRisk}</MenuItem>);
    }

    renderDays() {
        return this.state.reportsPerHealthRisk.map(report => {
            const day = new Date(report.timestamp).toDateString();
            return <TableCell className="headerText" key={report.id}>{day}</TableCell>
        });
    }

    render() {
        return (
            <div className="tableContainer">
                <h2 className="headline">Reports for
                <Select className="headline-select"
                        value={this.state.selectedHealthRisk}
                        onChange={this.saveSelectedValue.bind(this)}
                    >
                        {this.renderOptions()}
                    </Select>
                </h2>
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
            </div>
        );
    }
}
