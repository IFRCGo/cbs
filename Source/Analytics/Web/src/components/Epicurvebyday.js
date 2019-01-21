import React , { Component } from "react";
import { render } from 'react-dom'
import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'


const options = {
  chart: {
    type: 'column'
  },
  title: {
    text: 'Epicurve by day'
  },
  subtitle: {
    text: 'Source: CSB'
  },
  xAxis: {
    categories: [
      '01.07.2018',
      '05.07.2018',
      '08.07.2018',
      '10.07.2018',
      '15.07.2018',
      '17.07.2018',
      '18.07.2018',
      '22.07.2018',
      '29.07.2018',
      '01.08.2018',
      '05.08.2018',
      '12.08.2018',     
      '14.08.2018',
      '19.08.2018',
      '26.08.2018',
      '02.09.2018',
      '05.09.2018',
      '09.09.2018',
      '16.09.2018',
      '19.09.2018',
      '23.09.2018'


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
    
    4, 31, 50, 50, 56,  69, 70,  87, 78, 90, 86, 135, 148, 99, 116, 100, 94,  85, 70, 54, 30
    
    ]

  }]
}

class Epicurvebyday extends Component {

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

export default Epicurvebyday