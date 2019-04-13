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
import VisibilityIcon from '@material-ui/icons/More';
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
    width: '70%',
    margin:'auto',
    marginTop: theme.spacing.unit * 3,
    overflowX: 'auto',
  },
  table: {
    maxWidth: 850,
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
  createData('AWD #1', 'Acute Watery Diarrhea', 6.0, 'Within 6 days'),
  createData('CH #2', 'Cholera', 9.0, 'Within 6 days'),
  createData('YF #3', 'Measles', 16.0, 'Within 12 days'),
  createData('ML #4', 'Acute Watery Diarrhea', 3.7, 'Within 2 days'),
  createData('CH #2', 'Typhoid fever', 16.0, 'Within 1 days'),
];

function CustomizedTable(props) {
  const { classes } = props;

  return (
    <div>
     <div style={{
        textAlign:"center",}}>
        <h1>Alert rule overview</h1>
         <p>Here are the alert rules you have registered</p>
     </div>
    <Paper className={classes.root}>
   
    <Link to="/alerts/AddRule" align="right" style={{ textDecoration:'none',color:'#1070ca' }}>
        <Button  variant="outlined"  className={classes.button} style={{ color:'#1070ca' }} >
          <AddIcon  className={classes.icon} />
        </Button>
    </Link>
    
      <Table className={classes.table}>
        <TableHead>
          <TableRow >
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}}>Alert rule name</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}}align="right">Health risk number</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}} align="right">Alert threshold</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}}  align="right">Timeframe</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}} align="right"></CustomTableCell>
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
