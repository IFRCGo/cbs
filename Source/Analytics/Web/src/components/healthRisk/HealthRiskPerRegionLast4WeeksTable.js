import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

import { QueryCoordinator } from "@dolittle/queries";
import { CaseReportsPerRegionLast7DaysQuery } from "../../Features/CaseReports/CaseReportsPerRegionLast7DaysQuery";

import '../lastWeekTotals/last-week-totals.scss';

class HealthRiskPerRegionLast4WeeksTable extends Component {
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
        let healthRisksPerRegion = new CaseReportsPerRegionLast7DaysQuery();

        this.queryCoordinator.execute(healthRisksPerRegion).then(queryResult => {
            if(queryResult.success){
                this.setState({
                    regionsForHealthRisk: queryResult.items[0].healthRisks[0],
                    isLoading: false,
                    isError: false
                })
            }
            else {
                this.setState({ isLoading: false, isError: true })
            }
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

    render() {
        if (this.state.isLoading) {
            return <div>Loading...</div>;
        }
        return (
            <div className="tableContainer">
                <h2 className="headline">No. of reports for AWD last 28 days</h2>
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
                        {
                            this.createRows(this.state.regionsForHealthRisk.regions).map(row => {
                            let rowName = row.shift();
                            return (
                                <TableRow key={rowName}>
                                    <TableCell 
                                        className="cell" 
                                        key={rowName} 
                                        align="left">{rowName}
                                    </TableCell> {/* Special treatment of region name column */}

                                    {row.map(numCases => (
                                        <TableCell 
                                            className="cell" 
                                            align="right" 
                                            style={numCases === 0 ? {color: "#B5B5B5"} : {}}>
                                            {numCases}
                                        </TableCell>
                                    ))}     
                                </TableRow>
                                )
                            })
                        }
                    </TableBody>
                </Table>
            </div>
        );
    }
}

export default HealthRiskPerRegionLast4WeeksTable;