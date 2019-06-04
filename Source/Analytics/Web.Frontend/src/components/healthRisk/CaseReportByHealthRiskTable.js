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

class CaseReportByHealthRiskTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            healthRisks: [],
            isLoading: true,
            isError: false
        };
    }

    fetchData() {
        this.url = `${BASE_URL}CaseReport/TotalsPerHealthRisk/4/`;

        this.setState({ isLoading: true });

        getJson(this.url)
            .then(json =>
                this.setState({
                    healthRisks: json,
                    isLoading: false,
                    isError: false
                })
            )
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
                <Typography variant="h5">No. of case reports per health risk per time period.</Typography>
                <Paper>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell></TableCell>
                        <TableCell align="right">0-6 days</TableCell>
                        <TableCell align="right">7-13 days</TableCell>
                        <TableCell align="right">14-21 days</TableCell>
                        <TableCell align="right">22-27 days</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {this.state.healthRisks.map(healthRisk => (
                        <TableRow key={healthRisk.name}>
                          <TableCell component="th" scope="row">
                            {healthRisk.name}
                          </TableCell>
                          {healthRisk.reportsPerWeek.map(reports => (
                              <TableCell key={reports.week} align="right">
                                {reports.numberOfReports === 0 && <div style={{color: "#B5B5B5"}}>{reports.numberOfReports}</div> || reports.numberOfReports}
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

export default CaseReportByHealthRiskTable;