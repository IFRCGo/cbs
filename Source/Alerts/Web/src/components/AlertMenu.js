import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';


function AlertMenu(props) {
  const { classes } = props;

  return (
    <div className='alert-menu'>
      <Link to="/alerts" className='menu-button'>
        Alert OverView
        </Link>
      <Link to="/alerts/rules" className='menu-button'>
        Alert Rules
        </Link>
      <Link to="/alerts/registerdataowner" className='menu-button'>
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

