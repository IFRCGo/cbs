import React, { Component } from 'react'
import Timeline from '../components/Timeline'

const data = [
  {
    data: [
      {
        weeks: [
          {
            date: '10-02-1996',
            status: 'pending',
          },
          {
            date: '16-02-1996',
            status: 'pending',
          },
        ],
        region: 'Thies',
        district: 'Thies',
        village: "M'Bour",
      },
    ],
  },
]

export class ActivityHistoryContainer extends Component {
  render() {
    return (
      <div>
        <p>Hello from Activity History</p>
        <Timeline data={data[0].data[0]} />
      </div>
    )
  }
}
