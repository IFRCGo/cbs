import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';

import { QueryCoordinator } from "@dolittle/queries";
import { CaseReportsPerRegionLast7DaysQuery } from "../../Features/CaseReports/CaseReportsPerRegionLast7DaysQuery";

import '../lastWeekTotals/last-week-totals.scss';

class HealthRiskPerRegionLast4WeeksTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            regionsForHealthRisk: [],
            selectedHealthRisk: '',
            isLoading: true,
            isError: false
        };
    }

    fetchData() { 
        this.queryCoordinator = new QueryCoordinator();
        let regionsForHealthRisk = new CaseReportsPerRegionLast7DaysQuery();

        this.queryCoordinator.execute(regionsForHealthRisk).then(queryResult => {
            if(queryResult.success){
                this.setState({
                    regionsForHealthRisk: queryResult.items[0].healthRisks,
                    selectedHealthRisk: queryResult.items[0].healthRisks[0].healthRiskName,
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

    saveSelectedValue(event) {
        this.setState({
            selectedHealthRisk: event.target.value
        });
    }

    renderOptions() {
        return this.state.regionsForHealthRisk.map(healthRisk => <MenuItem key={healthRisk.healthRiskName} value={healthRisk.healthRiskName}>{healthRisk.healthRiskName}</MenuItem>);
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
        let currentHealthRisk = this.state.regionsForHealthRisk.find(r => r.healthRiskName == this.state.selectedHealthRisk);

        return (
            <div className="tableContainer">
                <h2 className="headline">Report for the last 4 weeks</h2>
                <Select className="headline-select"
                         value={this.state.selectedHealthRisk}
                         onChange={this.saveSelectedValue.bind(this)}
                     >
                         {this.renderOptions()}
                </Select>
                
                
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
                            this.createRows(currentHealthRisk.regions).map(row => {
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