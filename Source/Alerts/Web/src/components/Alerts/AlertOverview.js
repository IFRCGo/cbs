import React from 'react';
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

const styles = theme => ({
  root: {
    margin: 'auto',
    marginTop: theme.spacing.unit * 3,
    overflowX: 'auto',
  }
});

let id = 0;
function createData(name, calories, fat, carbs, Opened, status) {
  id += 1;
  return { id, name, calories, fat, carbs, Opened, status };
}

const rows = [
  createData('1', 'Acute Watery Diarrhea', 6, 'Dakar', '17-03-2019- 12:15', 'Open'),
  createData('2', 'Cholera', 9, 'Thies', '18-05-2019- 12:15', 'Open'),
  createData('3', 'Measles', 16, 'Dakar', '18-05-2019- 12:15', 'Open'),
  createData('4', 'Acute Watery Diarrhea', 3, 'Dakar', '18-05-2019- 12:15', 'Open'),
  createData('4', 'Typhoid fever', 16, 'Matam', '18-05-2019- 12:15', 'Open'),
];

function CustomizedTable(props) {
  const { classes } = props;

  return (
    <div>
      <div>
        <Button size="small" className={classes.margin}>
          Opened
        </Button>

        <Button size="small" className={classes.margin}>
          Escalated
        </Button>

        <Button size="small" className={classes.margin}>
          Closed
        </Button>

      </div>
      <Table className={classes.table} >
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
    </div>

  );
}

CustomizedTable.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(CustomizedTable);
