import React from 'react';
import moment from 'moment';
import axios from 'axios';

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

  getParsedDataByMonth = data => {
    console.log('data', data)

    const monthsList = moment.monthsShort()
    console.log(monthsList)



    return 'test'
  }

  getListItemsByVillage = data => {
    console.log('hey', data)
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

    const parsedData = this.getParsedDataByMonth([items[0]])

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
    return (
      <div className="alert-history-view">
        <h1>Alert history:</h1>
        <AlertHistoryContainer 
          dateRange={this.state.dateRange}
          label="Villages"
          data={this.state.data}
        />
      </div>
    )
  }
}

export default AlertHistoryView;