import React from 'react';
import './AlertHistoryItem.css'

class AlertHistoryItem extends React.Component {
  render() {
    let className = 'alert-item';
    if (this.props.status) {
      className += ' active';
    }
    return (
      <li className={className}>
        ite
      </li>
    )
  }
}

export default AlertHistoryItem;