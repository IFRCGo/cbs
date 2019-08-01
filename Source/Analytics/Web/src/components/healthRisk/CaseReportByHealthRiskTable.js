import React, { Component } from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import '../lastWeekTotals/last-week-totals.scss';
import { QueryCoordinator } from "@dolittle/queries";
import { CaseReportsLast4WeeksPerHealthRiskQuery } from "../../Features/Overview/Last4WeeksPerHealthRisk/CaseReportsLast4WeeksPerHealthRiskQuery";

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
      this.queryCoordinator = new QueryCoordinator();
      let lastWeeksPerHealthRisk = new CaseReportsLast4WeeksPerHealthRiskQuery();

      this.queryCoordinator.execute(lastWeeksPerHealthRisk).then(queryResult => {
          if(queryResult.success && queryResult.items.length > 0){
              this.setState({
                  healthRisks: queryResult.items[0].caseReportsPerHealthRisk,
                  isLoading: false,
                  isError: false
              });
          }
          else{
              this.setState({ isLoading: false, isError: true })
          }
      });
    }

    componentDidMount() {
        this.fetchData();
    }

    render() {
        return (
          <div className="tableContainer">
            <h2 className="headline">Reports for the last 4 weeks</h2>
              <Table className="table">
                <TableHead className="tableHead">
                  <TableRow>
                    <TableCell></TableCell>
                    <TableCell className="headerText">Reports last week (today - day 6)</TableCell>
                    <TableCell className="headerText">Reports 1 week ago (day 7-13)</TableCell>
                    <TableCell className="headerText">Reports 2 weeks ago (day 14-20)</TableCell>
                    <TableCell className="headerText">Reports 3 weeks ago (day 21-27)</TableCell>
                    <TableCell className="headerText">Total no. of reports (last 28 days)</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {Object.keys(this.state.healthRisks).map(key => {
                  var total = this.state.healthRisks[key].days0to6
                              + this.state.healthRisks[key].days7to13
                              + this.state.healthRisks[key].days14to20
                              + this.state.healthRisks[key].days21to27;
                  return (
                    <TableRow key={this.state.healthRisks[key].healthRiskName}>
                      <TableCell className="cell">
                        {this.state.healthRisks[key].healthRiskName}
                      </TableCell>
                      <TableCell 
                        className={this.state.healthRisks[key].days0to6 === 0 ? 'cell--empty' : 'cell'}>
                        {this.state.healthRisks[key].days0to6}
                      </TableCell>
                      <TableCell 
                        className={this.state.healthRisks[key].days7to13 === 0 ? 'cell--empty' : 'cell'}>
                        {this.state.healthRisks[key].days7to13}
                      </TableCell>
                      <TableCell 
                        className={this.state.healthRisks[key].days14to20 === 0 ? 'cell--empty' : 'cell'}>
                        {this.state.healthRisks[key].days14to20}
                      </TableCell>
                      <TableCell 
                        className={this.state.healthRisks[key].days21to27 === 0 ? 'cell--empty' : 'cell'}>
                        {this.state.healthRisks[key].days21to27}
                      </TableCell>
                      <TableCell 
                        className={total === 0 ? 'cell--empty' : 'cell'}>
                        {total}
                      </TableCell>
                    </TableRow>
                  )})}
                </TableBody>
              </Table>
          </div>
        );
    }
}

export default CaseReportByHealthRiskTable;