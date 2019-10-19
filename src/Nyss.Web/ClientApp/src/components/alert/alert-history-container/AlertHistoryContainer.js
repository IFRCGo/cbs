import React from 'react';

import './AlertHistoryContainer.css'
import AlertHistoryItem from '../alert-history-item/AlertHistoryItem'

class AlertHistoryContainer extends React.Component {
  render() {
    return (
      <div className="alert-history-container">
        <ul className="alert-container">
          <AlertHistoryItem />
        </ul>
      </div>
    )
  }
}

export default AlertHistoryContainer;