import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';


function AlertMenu(props) {
  const { classes } = props;

  return (
    <div className='alert-menu'>
      <Link to="/alerts" className='menu-button'>
        Alerts OverView
        </Link>
      <Link to="/alerts/ListeRules" className='menu-button'>
        Alerts Rules
        </Link>
      <Link to="/alerts/RegisterDataOwner" className='menu-button'>
        Register Data Owner
        </Link>
    </div>
  );
}
export default connect(
  _ => ({}),
  dispatch => ({
    requestCreateRule: rule => dispatch({ type: 'REQUEST_CREATE_RULE', payload: rule }),
  }))
  (AlertMenu);

