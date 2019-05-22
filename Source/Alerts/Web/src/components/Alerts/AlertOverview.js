import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Button from '@material-ui/core/Button';

const CustomTableCell = withStyles(theme => ({
  head: {
    backgroundColor: '#FAFAFA',
    color: '#000000',
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);

class AlertOverview extends Component {
  componentWillMount() {
    this.props.getAlertOverview();
  }

  render() {
    const { alerts = []} = this.props;

    return (
    <div>
      <div>
        <Button size="small">
          Opened
        </Button>

        <Button size="small">
          Escalated
        </Button>

        <Button size="small">
          Closed
        </Button>

      </div>
      <Table >
        <TableHead>
          <TableRow >
            <CustomTableCell>Alert number</CustomTableCell>
            <CustomTableCell align="right">Health risk</CustomTableCell>
            <CustomTableCell align="right">No. of reports</CustomTableCell>
            <CustomTableCell align="right">Last report from</CustomTableCell>
            <CustomTableCell align="right">Opened at</CustomTableCell>
            <CustomTableCell align="right">Status</CustomTableCell>

          </TableRow>
        </TableHead>
        <TableBody>
          {alerts.map(row => (
            <TableRow key={row.id}>
              <CustomTableCell scope="row">{row.alertNumber}</CustomTableCell>
              <CustomTableCell align="right">{row.healthRiskName}</CustomTableCell>
              <CustomTableCell align="right">{row.numberOfReports}</CustomTableCell>
              <CustomTableCell align="right">{row.carbs}</CustomTableCell>
              <CustomTableCell align="right">{new Date(row.openedAt).toString()}</CustomTableCell>
              <CustomTableCell align="right">{row.status}</CustomTableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
    );
  }
}

export default connect(
  state => ({
    alerts: state.root.overview
  }),
  dispatch => ({
    getAlertOverview: () => dispatch({ type: 'REQUEST_ALERT_OVERVIEW'})
  })
)(AlertOverview);
