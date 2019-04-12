import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import VisibilityIcon from '@material-ui/icons/Visibility';
import AddIcon from '@material-ui/icons/Add';
import {
    Link,  
  } from 'react-router-dom'

const CustomTableCell = withStyles(theme => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);

const styles = theme => ({
  root: {
    width: '100%',
    marginTop: theme.spacing.unit * 3,
    overflowX: 'auto',
  },
  table: {
    minWidth: 700,
  },
  row: {
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.background.default,
    },
  },
});

let id = 0;
function createData(name, calories, fat, carbs) {
  id += 1;
  return { id, name, calories, fat, carbs };
}

const rows = [
  createData('Frozen yoghurt', 4, 6.0, 24, 4.0),
  createData('Ice cream sandwich', 3, 9.0, 37, 4.3),
  createData('Eclair', 4, 16.0, 24, 6.0),
  createData('Cupcake', 6, 3.7, 67, 4.3),
  createData('Gingerbread', 7, 16.0, 49, 3.9),
];

function CustomizedTable(props) {
  const { classes } = props;

  return (
    <div>

    <Paper className={classes.root}>
   
    <Link to="/alerts/AddRule"><Button variant="outlined" color="inherit" className={classes.button}>
          <AddIcon className={classes.icon} />
      </Button></Link>
      <Table className={classes.table}>
        <TableHead>
          <TableRow>
            <CustomTableCell>Alert rule name</CustomTableCell>
            <CustomTableCell align="right">Health risk number</CustomTableCell>
            <CustomTableCell align="right">Alert threshold</CustomTableCell>
            <CustomTableCell align="right">Timeframe</CustomTableCell>
            <CustomTableCell align="right">Operations</CustomTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map(row => (
            <TableRow className={classes.row} key={row.id}>
              <CustomTableCell component="th" scope="row">
                {row.name}
              </CustomTableCell>
              <CustomTableCell align="right">{row.calories}</CustomTableCell>
              <CustomTableCell align="right">{row.fat}</CustomTableCell>
              <CustomTableCell align="right">{row.carbs}</CustomTableCell>
              <CustomTableCell align="right"> <VisibilityIcon className={classes.icon} />
            </CustomTableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
    </div>

  );
}

CustomizedTable.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(CustomizedTable);
