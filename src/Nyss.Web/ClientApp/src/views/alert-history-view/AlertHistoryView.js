import React from 'react';
import moment from 'moment';
import axios from 'axios';
import Timeline from 'react-calendar-timeline'
import 'react-calendar-timeline/lib/Timeline.css'

class AlertHistoryView extends React.Component {

  state = {
    groups: [],
    items: []
  }

  componentDidMount = async () => {
    const { data } = await axios.get(`${this.props.url}/api/AlertHistory?numberOfWeeks=52&includeNoAlerts=true`)

    this.setState({
      groups: [ ...data.villages.map(item => {
        return {
          id: item.id,
          title: item.villageName
        }
      }) ],
      items: [ ...data.alerts.map((item, index) => {
        return {
          id: index,
          group: item.villageId,
          title: item.villageId,
          start_time: moment(item.startDate),
          end_time: moment(item.endDate)
        }
      }) ]
    })
  }
  
  render() {
    const groups = this.state.groups
    const items = this.state.items
    return (
      <div className="alert-history-view">
        <h1>Alert history:</h1>
        <Timeline
          groups={groups}
          items={items}
          defaultTimeStart={moment().subtract(12, 'month')}
          defaultTimeEnd={moment()}
        />
      </div>
    )
  }
}

export default AlertHistoryView;