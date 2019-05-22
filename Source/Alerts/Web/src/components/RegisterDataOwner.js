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
import { RegisterDataOwner } from '../../Features/DataOwners/RegisterDataOwner';


const CustomTableCell = withStyles(theme => ({
    head: {
        backgroundColor: '#FAFAFA',
        color: '#000000',
    },
    body: {
        fontSize: 14,
    },
}))(TableCell);

const registerDataOwner = new RegisterDataOwner();


class RegisterDataOwnerComponent extends Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getDataOwners();
    }

    onChangeName(event) {
        //console.log(event.target.value);
        // this.setState({
        //     name: event.target.value
        // });
        registerDataOwner.name = event.target.value;
    }

    onChangeMail(event) {
        //console.log(event.target.value);
        // this.setState({
        //     email: event.target.value
        // });
        registerDataOwner.email = event.target.value;
    }

    registerDataOwner() {
        event.preventDefault();
        // this.setState({
        //     dataOwner: [...this.state.dataOwner, ...[{ name: this.state.name, email: this.state.email }]],
        //     name: '',
        //     email: '',
        // });
        this.props.registerDataOwner(registerDataOwner);
    }

    renderDataOwners() {
        const { dataOwners = []} = this.props;
        return dataOwners.map((item, index) => {
            return (
                <TableRow key={index}>
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
                <form onSubmit={this.registerDataOwner.bind(this)} >
                    <TextField
                        id="outlined-uncontrolled"
                        label="name"
                        value={this.props.name}
                        margin="normal"
                        variant="outlined"
                        onChange={this.onChangeName.bind(this)}

                    />

                    <TextField
                        id="outlined-uncontrolled"
                        label="email"
                        value={this.props.email}
                        margin="normal"
                        variant="outlined"
                        type="email"
                        onChange={this.onChangeMail.bind(this)}
                    />

                    <div>
                        <Button align="right" type="submit" variant="contained" color="primary">
                            Send
                        </Button>
                    </div>

                </form>


                <div >
                    <Table>
                        <TableHead>
                            <TableRow>
                                <CustomTableCell >Name</CustomTableCell>
                                <CustomTableCell >Email</CustomTableCell>
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

export default connect(
    state => ({
        dataOwners: state.root.dataowner
    }),
    dispatch => ({
        getDataOwners: () => dispatch({ type: 'REQUEST_DATAOWNER'}),
        registerDataOwner: dataowner => dispatch({ type: 'REQUEST_REGISTER_DATAOWNER', dataowner: dataowner})
    })
)(RegisterDataOwnerComponent);
