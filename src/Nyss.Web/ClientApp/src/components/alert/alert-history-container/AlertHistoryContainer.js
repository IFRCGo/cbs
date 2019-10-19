import React from 'react';

import AlertHistoryItem from '../alert-history-item/AlertHistoryItem'

class AlertHistoryContainer extends React.Component {
  render() {
    return (
      <div>
        <ul>
          <AlertHistoryItem />
          <AlertHistoryItem />
          <AlertHistoryItem />
          <AlertHistoryItem />
          <AlertHistoryItem />
        </ul>
      </div>
    )
  }
}

export default AlertHistoryContainer;