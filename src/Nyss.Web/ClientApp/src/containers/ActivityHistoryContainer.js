import axios from 'axios'
import React, { Component } from 'react'

import { Timeline } from '../components/AlertHistory/Timeline'

export class ActivityHistoryContainer extends Component {
  constructor(props) {
    super(props)
    this.state = {
      data: []
    }
  }
  componentDidMount = async () => {
    const { data } = await axios.get(`${this.props.url}/api/AlertHistory`)
    this.setState({ data: data })
  }

  render() {
    return (
      <div>
        <p>Hello from Activity History</p>
        <Timeline data={this.state.data} />
      </div>
    )
  }
}
