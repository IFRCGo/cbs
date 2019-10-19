import React from 'react';
import moment from 'moment';
import axios from 'axios';
import Timeline from 'react-calendar-timeline'
import 'react-calendar-timeline/lib/Timeline.css'

import './AlertHistoryView.css'
import AlertHistoryContainer from '../../components/alert/alert-history-container/AlertHistoryContainer'

class AlertHistoryView extends React.Component {

  state = {
    data: [],
    dateRange: {
      startDate: null,
      endDate: null
    }
  }

  getParsedDataByMonth = item => {
    console.log('data', item)

    const monthsList = moment.monthsShort()
    const dateStart = moment('2013-8-31');
    const dateEnd = moment('2015-3-30');

    const timeValues = [];

    while (dateEnd > dateStart || dateStart.format('M') === dateEnd.format('M')) {
      timeValues.push(dateStart.format('YYYY-MM'));
      dateStart.add(1,'month');
    }
    monthsList.forEach(month => {
      console.log('month', month)
    })
    // console.log(monthsList)



    return 'test'
  }

  getListItemsByVillage = data => {
    const villages = data.villages.map(item => {
      return {
        itemLabel: item.village,
        data: item.alerts
      }
    })
    return villages
  }

  componentDidMount = async () => {
    const { data } = await axios.get("http://localhost:5000/api/AlertHistory?numberOfWeeks=52&includeNoAlerts=true")

    const items = this.getListItemsByVillage(data)

    console.log('items', items)

    const res = items.map(item => this.getParsedDataByMonth(item))

    console.log('res', res)


    // const parsedData = this.getParsedDataByMonth([items[0]])

    // console.log('++', )

    this.setState({ 
      data: [  ],
      dateRange: {
        startDate: data.from,
        endDate: data.to
      }
    })
  }
  
  render() {

    const groups = [{ id: 1, title: 'group 1' }, { id: 2, title: 'group 2' }]

    const items = [
      {
        id: 1,
        group: 1,
        title: 'item 1',
        start_time: moment(),
        end_time: moment().add(1, 'hour')
      },
      {
        id: 2,
        group: 2,
        title: 'item 2',
        start_time: moment().add(-0.5, 'hour'),
        end_time: moment().add(0.5, 'hour')
      },
      {
        id: 3,
        group: 1,
        title: 'item 3',
        start_time: moment().add(2, 'hour'),
        end_time: moment().add(3, 'hour')
      }
    ]


   

    return (
      <div className="alert-history-view">
        <h1>Alert history:</h1>
        {/* <AlertHistoryContainer 
          dateRange={this.state.dateRange}
          label="Villages"
          data={this.state.data}
        /> */}
        <Timeline
          groups={groups}
          items={items}
          defaultTimeStart={moment().add(-12, 'hour')}
          defaultTimeEnd={moment().add(12, 'hour')}
        />

      </div>
    )
  }
}

export default AlertHistoryView;