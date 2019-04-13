import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { getJson } from "../../utils/request";

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
        this.url = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRisksLast4Weeks';
        //this.url = `${BASE_URL}KPI/${formatDate(from)}/${formatDate(to)}/`;

        this.setState({ isLoading: true });

        getJson(this.url)
            .then(json =>
                this.setState({
                    healthRisks: json.healthRisks,
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
                          {healthRisk.timeSeries.map(time => (
                              <TableCell key={time.name} align="right">{time.numberOfCaseReports}</TableCell>
                          ))}
                        </TableRow>
                      ))}
                    </TableBody>
                  </Table>
                </Paper>
        );
    }
}

export default CaseReportByHealthRiskTable;
