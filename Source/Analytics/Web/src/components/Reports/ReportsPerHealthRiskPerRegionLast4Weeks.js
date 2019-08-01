import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { QueryCoordinator } from "@dolittle/queries";
import { CaseReportsPerRegionLast4WeeksQuery } from "../../Features/CaseReports/CaseReportsPerRegionLast4WeeksQuery";

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
        let regionsForHealthRisk = new CaseReportsPerRegionLast4WeeksQuery();

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

    renderTableCell(numCases, key) {
        return <TableCell key={key}
            className="cell"
            align="center">
            {numCases === 0 ? '-' : numCases}
        </TableCell>
    }

    renderRows() {
        const currentHealthRisk = this.state.regionsForHealthRisk.find(r => r.healthRiskName == this.props.selectedHealthRisk);

        if (currentHealthRisk != null) {
            return currentHealthRisk.regions.map(region => {
                const totalReports = Object.values(region).reduce(function (acc, val) {
                    if (!isNaN(val))
                        return acc + val;
                    return acc
                }, 0);

                return (
                    <TableRow key={region.name}>
                        <TableCell key={0}
                            className="cell"
                            align="left">{region.name}
                        </TableCell>
                        {this.renderTableCell(region.days0to6, 1)}
                        {this.renderTableCell(region.days7to13, 2)}
                        {this.renderTableCell(region.days14to20, 3)}
                        {this.renderTableCell(region.days21to27, 4)}
                        {this.renderTableCell(totalReports, 5)}
                    </TableRow>
                )
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
                        <TableCell className="headerText" align="center">Last week</TableCell>
                        <TableCell className="headerText" align="center">2 weeks ago</TableCell>
                        <TableCell className="headerText" align="center">3 weeks ago</TableCell>
                        <TableCell className="headerText" align="center">4 weeks ago</TableCell>
                        <TableCell className="headerText" align="center">Total</TableCell>
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