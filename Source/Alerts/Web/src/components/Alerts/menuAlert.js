import React, { Component } from 'react';
import IconButton from '@material-ui/core/IconButton';
import { connect } from 'react-redux';
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
  });
function MenuAlert(props) {
  const { classes } = props;

  return (
    <div style={{ textDecoration:'none',textAlign:'center' }}>
         <IconButton >
            Alerts OverView
        </IconButton>
        <Link to="/alerts/ListeRules" style={{ textDecoration:'none' }}>
         <IconButton >
           Alerts Rules
         </IconButton>    
        </Link>   
      </div>
    

  );
}
export default connect(
    _ => ({}),
    dispatch => ({
        requestCreateRule: rule => dispatch({ type: 'REQUEST_CREATE_RULE', payload: rule }),
    }))
    (MenuAlert);

