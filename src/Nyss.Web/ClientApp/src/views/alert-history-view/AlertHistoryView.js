import React from 'react';

import './AlertHistoryView.css'
import AlertHistoryContainer from '../../components/alert/alert-history-container/AlertHistoryContainer'

class AlertHistoryView extends React.Component {
  render() {
    return (
      <div className="alert-history-view">
        <h1>Alert history:</h1>
        <AlertHistoryContainer />
      </div>
    )
  }
}

export default AlertHistoryView;