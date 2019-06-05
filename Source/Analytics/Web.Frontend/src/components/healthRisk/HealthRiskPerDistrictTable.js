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

    generateTableData(healthRisks){
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

    render() {
        return (
                <div style={{marginBottom: 20}}>
                <Typography variant="h5">No. of cases per health risk and district for last 7 days</Typography>
                <Paper>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell></TableCell>
                        {this.state.allRegionNames.map(name => (<TableCell key={name} align="right">{name}</TableCell>))}
                      </TableRow>
                    </TableHead>
                    <TableBody>
                    {this.generateTableData(this.state.healthRisks).map(healthRisk => (
                        <TableRow key={healthRisk.name}>
                            <TableCell component="th" scope="row">
                                {healthRisk.name}
                            </TableCell>

                        {healthRisk.regions.map(region => (
                            <TableCell key={region.name} align="right">
                            {region.numberOfCaseReports}
                            </TableCell> 
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

{/* TO DO: Insert 0 when a HealthRisk has no reports for a district */ }

export default HealthRiskPerDistrictTable;

{/*
{this.state.healthRisks.map(healthRisk => (
                        <TableRow key={healthRisk.name}>
                          <TableCell component="th" scope="row">
                            {healthRisk.name}
                          </TableCell>
                          
                        </TableRow>
                          ))} 




                          for (let i; i < this.state.allRegionNames.length; i++){
                            if (sorted_regions[i].name !== this.state.allRegionNames[i]){
                                sorted_regions[i-1].push({name: this.state.allRegionNames[i], numberOfCaseReports: 0});
                            }
                        }
                        */}



{/* 
{this.state.healthRisks.map(healthRisk => {
                        
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
                        }
                        
                    })}
*/}