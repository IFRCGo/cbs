import React from 'react';

import './AlertHistoryContainer.css'
import AlertHistoryItem from '../alert-history-item/AlertHistoryItem'

class AlertHistoryContainer extends React.Component {

  alertStatus = () => {
    return true
  }

  render() {

    const items = this.props.data
    console.log('++', items)
    return (
      <div className="alert-history-container">
        <ul className="alert-container">
          {
            items.map((item, i) => (
              // <div>{item.village}</div>

              // const alertStatus = 'd'

              <AlertHistoryItem 
                status={this.alertStatus} 
                key={i}
              />
            ))
          }
        </ul>
      </div>
    )
  }
}

export default AlertHistoryContainer;