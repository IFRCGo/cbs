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

class HealthRiskPerDistrictTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            healthRisksPerRegion: [],
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
                    healthRisksPerRegion: queryResult.items[0].healthRisks,
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

    createRows(healthRisks) {
        const numHealthRisks = healthRisks.length;
        let rows = [];

        let allRegions = [];
        healthRisks.map(risk => {
            risk.regions.map(region => {
                if (!allRegions.includes(region.name)){
                    allRegions.push(region.name);
                }
            })
        });
        allRegions.map(regionName => {
            let row = new Array(1+numHealthRisks).fill(0);
            row[0] = regionName;
            for (let i=0; i<numHealthRisks; i++){
                let num = healthRisks[i].regions.find(region => region.name === regionName);
                row[i+1] = num ? num.numCases : 0;
            }
            rows.push(row);
        });
        return rows
    }

    render() {
        return (
            <div className="tableContainer">
                <h2 className="headline">No. of cases per health risk and district for last 7 days</h2>
                <Table className="table">
                    <TableHead className="tableHead" key="table">
                        <TableRow>
                            <TableCell className="headerText">Region</TableCell>
                            {this.state.healthRisksPerRegion.map(healthRisk => 
                                (<TableCell className="headerText" key={healthRisk.healthRiskName} align="right">{healthRisk.healthRiskName}</TableCell>))
                            }
                        </TableRow>
                    </TableHead> 
                    <TableBody>
                        {
                            this.createRows(this.state.healthRisksPerRegion).map(row => {
                            let rowName = row.shift();
                            return (
                                <TableRow key={rowName}>
                                    <TableCell 
                                        className="cell" 
                                        key="rowName" 
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

export default HealthRiskPerDistrictTable;