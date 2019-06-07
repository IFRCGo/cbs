import React, { Component } from 'react';
import { connect } from 'react-redux';
import { SegmentedControl, Table } from 'evergreen-ui';

class AlertOverview extends Component {
  constructor(props) {
    super(props);
    this.state = {
      options: [
        { label: 'Opened', value: 'opened' },
        { label: 'Escalated', value: 'escalated' },
        { label: 'Closed', value: 'closed' }
      ],
      selected: 'opened'
    }
  }
  componentWillMount() {
    this.props.getAlertOverview();
    this.props.requestCloseAlert(1);
  }

  render() {
    const { alerts = []} = this.props;

    return (
    <div>
      <div>
        <SegmentedControl
          width={240}
          options={this.state.options}
          value={this.state.selected}
          onChange={value => this.setState({ selected: value})}
           />

      </div>
      <Table >
        <Table.Head>
            <Table.TextHeaderCell>Alert number</Table.TextHeaderCell>
            <Table.TextHeaderCell>Health risk</Table.TextHeaderCell>
            <Table.TextHeaderCell>No. of reports</Table.TextHeaderCell>
            <Table.TextHeaderCell>Last report from</Table.TextHeaderCell>
            <Table.TextHeaderCell>Opened at</Table.TextHeaderCell>
            <Table.TextHeaderCell>Status</Table.TextHeaderCell>

        </Table.Head>
        <Table.Body>
          {alerts.map(row => (
            <Table.Row key={row.id}>
              <Table.TextCell>{row.alertNumber}</Table.TextCell>
              <Table.TextCell>{row.healthRiskName}</Table.TextCell>
              <Table.TextCell>{row.numberOfReports}</Table.TextCell>
              <Table.TextCell>{row.carbs}</Table.TextCell>
              <Table.TextCell>{new Date(row.openedAt).toString()}</Table.TextCell>
              <Table.TextCell>{row.status}</Table.TextCell>
            </Table.Row>
          ))}
        </Table.Body>
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
    getAlertOverview: () => dispatch({ type: 'REQUEST_ALERT_OVERVIEW'}),
    requestCloseAlert: (alertNumber) => dispatch({ type: 'REQUEST_CLOSE_ALERT', payload: alertNumber })
  })
)(AlertOverview);
