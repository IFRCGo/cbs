import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';
import { getJson } from "../../utils/request";
import { BASE_URL } from "../NationalSocietyOverview";
import { formatDate } from "../../utils/dateUtils";
import { QueryCoordinator } from "@dolittle/queries";

import { GetCaseReportsPerRegionLast7Days } from "../../Features/CaseReports/GetCaseReportsPerRegionLast7Days";


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
        let healthRisksPerRegion = new GetCaseReportsPerRegionLast7Days();

        this.queryCoordinator.execute(healthRisksPerRegion).then(queryResult => {
            if(queryResult.success){
                console.log(queryResult.items[0].healthRisks[0].healthRiskName);
                this.setState({
                    healthRisksPerRegion: queryResult.items[0].healthRisks,
                    isLoading: true,
                    isError: false
                })
                
            }
            else{
                this.setState({ isLoading: false, isError: true })
            }
        });
    }

    componentDidMount() {
        this.fetchData();
        console.log(this.state.healthRisksPerRegion);
    }

    createRows(healthRisks) {
        const numHealthRisks = healthRisks.length;
        let rows = [];

        /*
        this.state.allRegionNames.map(regionName => {    
            let row = new Array(1+numHealthRisks).fill(0);
            row[0] = regionName;

            for (let i=0; i<numHealthRisks; i++){
                let num = healthRisks[i].regions.find(region => region.name === regionName);              
                row[i+1] = num ? num.numberOfCaseReports : 0;
            }

            rows.push(row); 
        })
        */

        healthRisks.map(risk => {
            let row = new Array(1+numHealthRisks).fill(0); // 1 is the region name column
            row[0] = risk.healthRiskName;

            for (let i=0; i<numHealthRisks; i++){
                let num = healthRisks[i].regions.find(region => region.id === "Oslo");              
                row[i+1] = num ? num.numCases : 0;
            }

            console.log(row);
            rows.push(row);
        });
        return rows
    }

    render() { 
        /* return ( <div>{this.state.healthRisksPerRegion.map(risk => risk.healthRiskName)}</div>); */
        return (
            <div style={{marginBottom: 20}}>
                <Typography variant="h5">No. of cases per health risk and district for last 7 days</Typography>
                <Paper>
                    <Table>
                    <TableHead>
                        <TableRow>
                        <TableCell>HealthRiskName -></TableCell>
                        {this.state.healthRisksPerRegion.map(healthRisk => (<TableCell key={healthRisk.healthRiskName} align="right">{healthRisk.healthRiskName}</TableCell>))}
                        </TableRow>
                    </TableHead> 
                    <TableBody>
                        {this.createRows(this.state.healthRisksPerRegion).map(row => (
                            <TableRow key={row.name}>
                                <TableCell align="left">{row.shift()}</TableCell> {/* Special treatment of region name column */}
                                {row.map(numCases => (
                                    <TableCell align="right" style={numCases === 0 ? {color: "#B5B5B5"} : {}}>{ numCases}</TableCell>
                                ))}     
                            </TableRow>
                        ))}
                    </TableBody>
                    </Table>
                </Paper>
            </div>
        );
        
    }
}

export default HealthRiskPerDistrictTable;