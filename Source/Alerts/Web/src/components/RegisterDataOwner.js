import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { connect } from 'react-redux';
import MenuAlert from './Alerts/menuAlert';


const CustomTableCell = withStyles(theme => ({
    head: {
      backgroundColor: theme.palette.common.black,
      color: theme.palette.common.white,
    },
    body: {
      fontSize: 14,
    },
  }))(TableCell);

  
class RegisterDataOwner extends Component {
    constructor() {
        super();

        this.state = {
            name: "",
            email: "",
            dataOwner: []
        };
    }

    onChangeName(event) {
        //console.log(event.target.value);
        this.setState({
            name: event.target.value
        });
    }

    onChangeMail(event) {
        //console.log(event.target.value);
        this.setState({
            email: event.target.value
        });
    }

    addDataOwner(event){
        event.preventDefault();
        this.setState({
            dataOwner: [...this.state.dataOwner, ...[{name:this.state.name, email:this.state.email}]],
            name: '',
            email: '',  
        });
    }


    // 
    renderDataOwners() {
        
        return this.state.dataOwner.map((item,index) => {
            return (
                <TableRow  key={index}>
                <CustomTableCell >{item.name}</CustomTableCell>
                <CustomTableCell >{item.email}</CustomTableCell>
                </TableRow> 
            );
        });
    }

  
    render() {
        const { classes } = this.props;

        return (

        <div>
            <MenuAlert/>
            <form onSubmit={this.addDataOwner} >
        <TextField
          id="outlined-uncontrolled"
          label="name"
          value={this.state.name} 
          margin="normal"
          variant="outlined"
          onChange={this.onChangeName.bind(this)}
          
        />

        <TextField
            id="outlined-uncontrolled"
            label="email"
            value={this.state.email} 
            margin="normal"
            variant="outlined"
            type="email"
            onChange={this.onChangeMail.bind(this)}
            />

    <Button onClick={this.addDataOwner.bind(this)}  variant="contained" color="primary">
        Send
    </Button>

        </form>

        
        <div className="list-group">
        <Table>
                <TableHead>
                <TableRow>
                    <CustomTableCell align="right">Name</CustomTableCell>
                    <CustomTableCell align="right">Email</CustomTableCell>
                </TableRow>
                </TableHead>
                <TableBody>
                    {this.renderDataOwners()}
                </TableBody>
                </Table>
        </div>
        </div>
            
        

        );
    }
}

export default connect()
    (RegisterDataOwner);
