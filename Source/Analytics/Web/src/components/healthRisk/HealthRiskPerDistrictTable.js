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

class HealthRiskPerDistrictTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            allRegionNames: [],
            healthRisks: [],
            isLoading: true,
            isError: false
        };
    }

    fetchData() {
        //this.url = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/CaseReportByDistrict';
        let oneWeekBack = new Date();
        oneWeekBack.setDate(oneWeekBack.getDate()-6);
        this.url = `${BASE_URL}CaseReport/TotalsPerRegion/${formatDate(oneWeekBack)}/${formatDate(new Date())}/`;

        getJson(this.url)
            .then(json => {
                let region_names = [];

                for (let i = 0; i < json.healthRisks.length; i++) {
                    for (let region of json.healthRisks[i].regions){
                        if (!(region_names.includes(region.name))){
                            region_names.push(region.name)
                        }
                    }
                }
                region_names.sort(); //This is useful later as it helps us detect when some health risk has 0 occurences in a region

                this.setState({
                    healthRisks: json.healthRisks,
                    allRegionNames: region_names,
                    isLoading: false,
                    isError: false
                })
            })
            .catch(_ =>
                this.setState({
                    isLoading: false,
                    isError: true
                })
            );         
    }

    componentDidMount() {
        this.fetchData();
    }

    createRows(healthRisks) {
        const numHealthRisks = healthRisks.length;
        let rows = [];

        this.state.allRegionNames.map(regionName => {    
            let row = new Array(1+numHealthRisks).fill(0);
            row[0] = regionName;

            for (let i=0; i<numHealthRisks; i++){
                let num = healthRisks[i].regions.find(region => region.name === regionName);              
                row[i+1] = num ? num.numberOfCaseReports : 0;
            }

            rows.push(row); 
        })
        return rows
    }

    render() {
        return (
            <div style={{marginBottom: 20}}>
                <Typography variant="h5">No. of cases per health risk and district for last 7 days</Typography>
                <Paper>
                    <Table>
                    <TableHead>
                        <TableRow>
                        <TableCell></TableCell>
                        {this.state.healthRisks.map(healthRisk => (<TableCell key={healthRisk.name} align="right">{healthRisk.name}</TableCell>))}
                        </TableRow>
                    </TableHead> 
                    <TableBody>
                        {this.createRows(this.state.healthRisks).map(row => (
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