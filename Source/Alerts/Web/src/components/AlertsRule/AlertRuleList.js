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
import AddIcon from '@material-ui/icons/Add';
import { Link } from 'react-router-dom';

const CustomTableCell = withStyles(theme => ({
  head: {
    backgroundColor: '#FAFAFA',
    color: '#000000',
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);


class AlertRules extends Component {
  constructor(props) { 
    super(props);
    this.state = {
      rules: []
    }
  }

  componentWillMount() {
    this.props.dispatch({ type: 'REQUEST_RULES' });
  }

  render() {
    const { rules = []} = this.props;
    return (
    <div>
     <div>
        <h1>Alert rule overview</h1>
         <p>Here are the alert rules you have registered</p>
     </div>
    <Link to="/alerts/AddRule" align="right">
        <Button  variant="outlined" >
          <AddIcon />
        </Button>
    </Link>
    
      <Table>
        <TableHead>
          <TableRow >
            <CustomTableCell>Alert rule name</CustomTableCell>
            <CustomTableCell align="right">Health risk number</CustomTableCell>
            <CustomTableCell align="right">Alert threshold</CustomTableCell>
            <CustomTableCell align="right">Timeframe</CustomTableCell>
            <CustomTableCell align="right"></CustomTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rules.map(rule => (
            <TableRow key={rule.id}>
              <CustomTableCell component="th" scope="row">
                {rule.alertRuleName}
              </CustomTableCell>
              <CustomTableCell align="right">{rule.healthRiskId}</CustomTableCell>
              <CustomTableCell align="right">{rule.numberOfCasesThreshold}</CustomTableCell>
              <CustomTableCell align="right">{rule.thresholdTimeframeInHours}</CustomTableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
    );
  }
}

const mapState = (state) => {
  return {
    rules: state.root.rules
  };
}

export default connect(mapState)(AlertRules);
