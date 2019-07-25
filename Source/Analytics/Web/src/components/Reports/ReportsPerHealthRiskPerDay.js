import React, { Component } from "react";
import { CaseReportsPerHealthRiskPerDayQuery } from "../../Features/CaseReports/CaseReportsPerHealthRiskPerDayQuery";
import { QueryCoordinator } from "@dolittle/queries";


export default class ReportsPerHealthRiskPerDay extends Component {
    constructor(props) {
        super(props);

        this.state = {
            reportsPerHealthRisk: {},
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
                const json = queryResult.items[0];
                var healthRisks = Object.keys(json.reportsPerHealthRisk);
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

    componentDidMount() {
        this.fetchReportsPerHealthRiskLastWeek();
    }

    saveSelectedValue(healthRisk) {
        this.setState({
            selectedHealthRisk: healthRisk
        });
    }

    renderReports() {
        if (this.state.reportsPerHealthRisk.reportsPerHealthRisk != null) {
            const reports = this.state.reportsPerHealthRisk.reportsPerHealthRisk[this.state.selectedHealthRisk];
            const keys = Object.keys(reports);
            return keys.map(key => {
                return (
                    <tr key={key}>
                        <td>{key}</td>
                        <td>{reports[key]}</td>
                    </tr>
                );
            });
        }
    }

    render() {
        return (
            <div>
                <h3>Reports for </h3>
                <select
                    value={this.state.selectedHealthRisk}
                    onChange={(e) => this.saveSelectedValue(e.target.value)}
                >
                    {this.state.healthRisks.map(x => {
                        return <option key={x} value={x}>{x}</option>
                    })}
                </select>

                <table>
                    <tbody>
                        <tr>
                            <th>Region</th>
                            <th>{this.state.reportsPerHealthRisk.id}</th>
                        </tr>
                        {this.renderReports()}
                    </tbody>
                </table>
            </div>
        );
    }
}
