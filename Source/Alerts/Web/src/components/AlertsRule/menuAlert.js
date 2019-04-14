import React, { Component } from 'react';
import IconButton from '@material-ui/core/IconButton';
import { connect } from 'react-redux';
import { withStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import MenuIcon from '@material-ui/icons/Menu';
import MenuList from '@material-ui/core/MenuList';
import {
    Link,  
  } from 'react-router-dom'


const styles = theme => ({
    container: {
      display: 'flex',
      flexWrap: 'wrap',
    },
    textField: {
      marginLeft: theme.spacing.unit,
      marginRight: theme.spacing.unit,
    },
    dense: {
      marginTop: 16,
    },
    menu: {
      width: 200,
    },
    root: {
      flexGrow: 1,
    },
    grow: {
      flexGrow: 1,
    },
    menuButton: {
      marginLeft: -12,
      marginRight: 20,
    },
  });
function MenuAlert(props) {
  const { classes } = props;

  return (
    <div>
      <div >
      
    </div>
      <img src="assets/logo.png"></img>
      <div style={{ textDecoration:'none',textAlign:'center' }}>
       <Link to="/alerts" style={{ textDecoration:'none' }}>
         <IconButton >
            Alerts OverView
        </IconButton>
        </Link>   
        <Link to="/alerts/ListeRules" style={{ textDecoration:'none' }}>
         <IconButton >
           Alerts Rules
         </IconButton>    
        </Link>
        <Link to="/alerts/RegisterDataOwner" style={{ textDecoration:'none' }}>
         <IconButton >
           Register Data Owner
         </IconButton>    
        </Link>     
      </div>
      </div>
    

  );
}
export default connect(
    _ => ({}),
    dispatch => ({
        requestCreateRule: rule => dispatch({ type: 'REQUEST_CREATE_RULE', payload: rule }),
    }))
    (MenuAlert);

