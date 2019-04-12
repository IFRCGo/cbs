import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import IconButton from '@material-ui/core/IconButton';



function MenuRule(props) {
  const { classes } = props;

  return (
    <div style={{ marginLeft:'30%' }}>
         <IconButton aria-label="Delete" className={classes.margin}>
            Alerts OverView
        </IconButton>
        <IconButton aria-label="Delete" className={classes.margin}>
           Alerts Rules
        </IconButton>       
      </div>
    

  );
}

