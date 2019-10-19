import React from 'react';

import AlertHistoryContainer from '../components/alert/alert-history-container/AlertHistoryContainer'

class AlertHistoryView extends React.Component {
  render() {
    return (
      <div>
        <h1>Alert history:</h1>
        <AlertHistoryContainer />
      </div>
    )
  }
}

export default AlertHistoryView;