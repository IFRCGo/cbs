import React, { Component } from 'react'
import axios from 'axios'
import { Timeline } from '../components/AlertHistory/Timeline'

export class ActivityHistoryContainer extends Component {
  state = {
    data: [],
  }

  componentDidMount = async () => {
    const { data } = await axios.get('http://localhost:5000/api/AlertHistory')
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
