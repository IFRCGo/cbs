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
                this.setState({
                    healthRisks: json.healthRisks,
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

    render() {
        return (
                <div style={{marginBottom: 20}}>
                <Typography variant="h5">No. of cases per health risk and district for last 7 days</Typography>
                <Paper>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell></TableCell>
                        <TableCell align="right">Thies</TableCell>
                        <TableCell align="right">Saly</TableCell>
                        <TableCell align="right">Dakar</TableCell>
                        <TableCell align="right">St. Louis</TableCell>
                        <TableCell align="right">Touba</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                    {this.state.healthRisks.map(healthRisk => (
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

export default HealthRiskPerDistrictTable;


{/* <TableRow key={healthRisk.name}>
                          <TableCell component="th" scope="row">
                            {healthRisk.name}
                          </TableCell>
                            {healthRisk.reportsPerWeek.map(reports => (
                              <TableCell key={reports.week} align="right">
                                {reports.numberOfReports === 0 && <div style={{color: "#B5B5B5"}}>{reports.numberOfReports}</div> || reports.numberOfReports}
                              </TableCell>
                          ))}

                            {this.state.healthRisks.map((healthRisk) => (
                                <GridListTile key={'Grid'+healthRisk.name} cols={2} style={{ height: 'auto' }}>
                                    <HighchartsReact key={healthRisk.name} highcharts={Highcharts} options={healthRisk.options} />
                                </GridListTile>
                            ))}

                        </TableRow>*/}