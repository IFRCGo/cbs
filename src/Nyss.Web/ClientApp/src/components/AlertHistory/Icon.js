import React, { Component } from 'react';

import ClosedIcon from './Icons/Close-pict.svg';
import DismissedIcon from './Icons/Dismissed-pict.svg';
import EscalatedIcon from './Icons/Escalated-pict.svg';
import NothingIcon from './Icons/Nothing-pict.svg';
import OpenIcon from './Icons/Open-pict.svg';

export default class Icon extends Component {
  render() {
    const { status } = this.props

    if (status === "Open") {
      return <img src={OpenIcon} alt={`${status}`} />
    } else if (status === "Closed") {
      return <img src={ClosedIcon} alt={`${status}`} />
    } else if (status === "Escalated") {
      return <img src={EscalatedIcon} alt={`${status}`} />
    } else if (status === "Dismissed") {
      return <img src={DismissedIcon} alt={`${status}`} />
    }
    return <img src={NothingIcon} alt={`${status}`} />
  }
}
