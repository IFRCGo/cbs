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
import MenuAlert from '../AlertsRule/menuAlert';
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
    width: '90%',
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
function createData(name, calories, fat, carbs,Opened,status) {
  id += 1;
  return { id, name, calories, fat, carbs,Opened ,status};
}

const rows = [
  createData('1', 'Acute Watery Diarrhea', 6, 'Dakar','17-03-2019- 12:15','Open'),
  createData('2', 'Cholera', 9, 'Thies','18-05-2019- 12:15','Open'),
  createData('3', 'Measles', 16, 'Dakar','18-05-2019- 12:15','Open'),
  createData('4', 'Acute Watery Diarrhea', 3, 'Dakar','18-05-2019- 12:15','Open'),
  createData('4', 'Typhoid fever', 16, 'Matam','18-05-2019- 12:15','Open'),
];

function CustomizedTable(props) {
  const { classes } = props;

  return (
    <div>
         <MenuAlert/>
    
    <Paper className={classes.root}>
    <div>
      <Button variant="contained" size="small" color="default" className={classes.margin}>
          Opened
        </Button>

        <Button variant="contained" size="small" color="primary" className={classes.margin}>
          Escalated
        </Button>

        <Button variant="contained" size="small" color="secondary" className={classes.margin}>
          Closed
        </Button>
     
      </div>
      <Table className={classes.table} >
        <TableHead>
          <TableRow >
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}}>Alert number</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}}align="right">Health risk</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}} align="right">No. of reports</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}}  align="right">Last report from</CustomTableCell>
            <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}} align="right">Opened at</CustomTableCell>
           <CustomTableCell style={{
               backgroundColor:'#fafafa',color:'#000'}} align="right">Status</CustomTableCell>
          
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
              <CustomTableCell align="right">{row.Opened}</CustomTableCell>
              <CustomTableCell align="right">{row.status}</CustomTableCell>
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
