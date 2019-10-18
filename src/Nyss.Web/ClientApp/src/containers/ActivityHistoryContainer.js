import React, { Component } from 'react'

import { Timeline } from '../components/AlertHistory/Timeline'

const data = [
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
  {
    weeks: [
      {
        date: '20-02-1996',
        status: 'penwding',
      },
      {
        date: '26-02-1996',
        status: 'penqwding',
      },
    ],
    region: 'Thiews',
    district: 'Thiwqees',
    village: "M'wqeeqour",
  },
]

export class ActivityHistoryContainer extends Component {
  render() {
    return (
      <div>
        <p>Hello from Activity History</p>
        {data.map(item => (
          <Timeline data={item} />
        ))}
      </div>
    )
  }
}
