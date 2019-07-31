import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { QueryCoordinator } from "@dolittle/queries";
import { CaseReportsPerRegionLast7DaysQuery } from "../../Features/CaseReports/CaseReportsPerRegionLast7DaysQuery";

class ReportsPerHealthRiskPerRegionLast4Weeks extends Component {
    constructor(props) {
        super(props);

        this.state = {
            regionsForHealthRisk: [],
            isLoading: true,
            isError: false
        };
    }

    fetchData() {
        this.queryCoordinator = new QueryCoordinator();
        let regionsForHealthRisk = new CaseReportsPerRegionLast7DaysQuery();

        this.queryCoordinator.execute(regionsForHealthRisk).then(queryResult => {
            if (queryResult.success) {
                this.setState({
                    regionsForHealthRisk: queryResult.items.length > 0 ? queryResult.items[0].healthRisks : [],
                    isLoading: false,
                    isError: false
                });
            }
            else {
                this.setState({ isLoading: false, isError: true });
            }
        }).catch(_ => {
            this.setState({ isLoading: false, isError: true });
        });
    }

    componentDidMount() {
        this.fetchData();
    }

    createRows(regions) {
        let rows = [];
        regions.map(region => {
            let row = Object.keys(region).map(key => (region[key] ? region[key] : 0));
            let totalReports = region.days0to6 + region.days7to13 + region.days14to20 + region.days21to27;
            row.push(totalReports);

            rows.push(row);
        });
        return rows
    }

    renderRows() {
        const currentHealthRisk = this.state.regionsForHealthRisk.find(r => r.healthRiskName == this.props.healthRisk);
        if (currentHealthRisk != null) {
            const rows = this.createRows(currentHealthRisk.regions);
            return rows.map(row => {
                const rowName = row.shift();
                return (
                    <TableRow key={rowName}>
                        <TableCell
                            className="cell"
                            align="left">{rowName}
                        </TableCell>{/* Special treatment of region name column */}
                        {row.map((numCases, i) => (
                            <TableCell key={i}
                                className={numCases === 0 ? 'cell--empty' : 'cell'}
                                align="right">
                                {numCases === 0 ? '-' : numCases}
                            </TableCell>
                        ))}</TableRow>
                );
            });
        }
    }

    render() {
        if (this.state.isLoading) {
            return <div>Loading...</div>;
        }

        return (
            <Table className="table">
                <TableHead className="tableHead" key="table">
                    <TableRow>
                        <TableCell className="headerText">Region</TableCell>
                        <TableCell className="headerText" align="right">Last week</TableCell>
                        <TableCell className="headerText" align="right">2 weeks ago</TableCell>
                        <TableCell className="headerText" align="right">3 weeks ago</TableCell>
                        <TableCell className="headerText" align="right">4 weeks ago</TableCell>
                        <TableCell className="headerText" align="right">Total</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {this.renderRows()}
                </TableBody>
            </Table>
        );
    }
}

export default ReportsPerHealthRiskPerRegionLast4Weeks;