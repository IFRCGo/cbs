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
        this.url = `${BASE_URL}/api/CaseReport/TotalsPerHealthRisk/`;

        this.setState({ isLoading: true });

        getJson(this.url)
            .then(json => 
                this.setState({
                    healthRisks: Object.values(json.caseReportsPerHelthRisk),
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
                    <TableRow key={healthRisk.healthRiskName.value}>
                      <TableCell component="th" scope="row">
                        {healthRisk.healthRiskName.value}
                      </TableCell>
                      <TableCell align="right" style={healthRisk.days0to6.value === 0 ? {color: "#B5B5B5"} : {}}>
                        {healthRisk.days0to6.value}
                      </TableCell>
                      <TableCell align="right" style={healthRisk.days7to13.value === 0 ? {color: "#B5B5B5"} : {}}>
                        {healthRisk.days7to13.value}
                      </TableCell>
                      <TableCell align="right" style={healthRisk.days14to20.value === 0 ? {color: "#B5B5B5"} : {}}>
                        {healthRisk.days14to20.value}
                      </TableCell>
                      <TableCell align="right" style={healthRisk.days21to27.value === 0 ? {color: "#B5B5B5"} : {}}>
                        {healthRisk.days21to27.value}
                      </TableCell>
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