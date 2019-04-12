Highcharts.chart('age', {
    chart: {
      type: 'column'
    },
    title: {
      text: 'Epicurve by week'
    },
    subtitle: {
      text: 'Source: CSB'
    },
    xAxis: {
      categories: [
        '<5',
        '>5',
      ],
      crosshair: true
    },
    yAxis: {
      min: 0,
      title: {
        text: 'Number in cases in total'
      }
    },
    tooltip: {
      headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
      pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
        '<td style="padding:0"><b>{point.y:.1f} </b></td></tr>',
      footerFormat: '</table>',
      shared: true,
      useHTML: true
    },
    plotOptions: {
      column: {
        pointPadding: 0.1,
        borderWidth: 0
      },
      bar: {
        dataLabels: {
            enabled: true
        }
      }
    },
    series: [{
      name: 'Number of cases in total',
      data: [
      
      49, 71
      
      ]
  
    }]
  });
  