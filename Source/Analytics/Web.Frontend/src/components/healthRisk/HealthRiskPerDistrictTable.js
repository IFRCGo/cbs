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
                console.log(json);

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

    generateHealthRiskTableData(healthRisks){
        healthRisks.map(healthRisk => {
                        
            let sorted_regions = healthRisk.regions.sort((a,b) => (a.name > b.name) ? 1 : -1);

            if (sorted_regions.length !== this.state.allRegionNames.length){
                let sorted_regions_all = [];

                this.state.allRegionNames.map(regionName => {
                    let existed = false;
                    sorted_regions.map(caseRegion => {
                        if (regionName == caseRegion.name){
                            sorted_regions_all.push(caseRegion);
                            existed = true;
                        } 
                    })
                    if (!existed){
                        sorted_regions_all.push({name: regionName, numberOfCaseReports: 0});
                    } 
                })
                healthRisk.regions = sorted_regions_all;
            }
            
            
        })
        return healthRisks;
    }

    createRows() {
        console.log(this.state.healthRisks)
        const numHealthRisks = this.state.healthRisks.length
        const rows = []
        this.state.allRegionNames.map(regionName => {
            
            let row = new Array(1+numHealthRisks).fill(0);
            row[0] = regionName;
            

            for (let i=0; i<this.state.healthRisks.length; i++){

                let num = this.state.healthRisks[i].regions.find(region => region.name === regionName);
                //console.log("NUM: " + (num ? num.numberOfCaseReports : 0));
                console.log("Occurences of " + this.state.healthRisks[i].name + " in " + regionName + "\: " + (num ? num.numberOfCaseReports : 0));
                
                row[i+1] = num ? num.numberOfCaseReports : 0;
            }
            
            rows.push(row)
            
            
        })
            
        

        console.log("ROWS: " + rows)
        
        {/* 
            for each region: create a row 
                for each health risk: find numCaseReports for the region
                    if num: append num to row
                    else: append 0
            return region row
        */} 

        {/* healthRiskName: "Measels", regions: [ {name: "Dakar", numberOfCaseReports: 15. }, ... ] */}

        return rows
    }

    render() {
        return (
                <div style={{marginBottom: 20, maxWidth: "60%"}}>
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
                        {this.createRows().map(row => (
                            <TableRow key={row.name}>
                                {row.map(x => (
                                    <TableCell align="right">{x}</TableCell>
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

{/* healthRiskName: "Measels", regions: [ {name: "Dakar", numberOfCaseReports: 15. }, ... ] 


{this.state.healthRisks.map(healthRisk => (
    healthRisk.regions.map(region => (
        <TableCell key={healthRisk.name} align="right">{region.numberOfCaseReports}</TableCell>
    ))
))}
}
*/}