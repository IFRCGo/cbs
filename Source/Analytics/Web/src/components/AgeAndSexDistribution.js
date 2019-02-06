import React , { Component } from "react";
import { render } from 'react-dom'
import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'


const options = {
  chart: {
    type: 'column'
  },
  title: {
    text: 'Age and sex distribution YYYY-MM-DD - YYYY-MM-DD'
  },
  subtitle: {
    text: 'Source: CSB'
  },
  xAxis: {
    categories: [
      'Male <5',
      'Male 5+',
      'Female <5',
      'Female 5+',
     
  ],
    crosshair: true
  },
  yAxis: {
    min: 0,
    title: {
      text: 'Number in cases in total'
    }
  },
  plotOptions: {
    column: {
      pointPadding: 0.1,
      borderWidth: 0
    }
  },
  
  options: {
  barPercentage: 1.0,
  categoryPercentage: 1.0
},
  
  series: [{
    name: 'Number of cases in total',
    data: [
    
    4, 31, 50, 50
    
    ]

  }]
}

class Ageandsexdistribution extends Component {

  constructor(props) {
      super(props);

  }

  //TODO Implement component and diagrams
  render() {
      return (
        <HighchartsReact
    highcharts={Highcharts}
    options={options}
  />
      );
  }

}

export default Ageandsexdistribution