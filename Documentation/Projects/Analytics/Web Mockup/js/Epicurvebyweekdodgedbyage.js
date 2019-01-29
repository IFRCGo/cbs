
Highcharts.chart('container', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'Epicurve by week dodged by age'
    },
    subtitle: {
    text: 'Source: CSB'
    },
    xAxis: {
        categories: [
      '01.07.2018',
      '08.07.2018',
      '15.07.2018',
      '22.07.2018',
      '29.07.2018',
      '05.08.2018',
      '12.08.2018',      
      '19.08.2018',
      '26.08.2018',
      '02.09.2018',
      '09.09.2018',
      '16.09.2018',
      '23.09.2018'
        ],
        crosshair: true
    },
    yAxis: {
        min: 0,
        title: {
            text: 'Number of cases summed per week'
        }
    },
    tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
    },
    plotOptions: {
        column: {
            pointPadding: 0.1,
            borderWidth: 0
        }
    },
    series: [{
        name: 'Younger than 5 years old',
        data: [49, 71, 106, 129, 144, 176, 135, 148, 216, 194, 95, 54]

    }, {
        name: '5 years and older',
        data: [83, 78, 98, 93, 106, 84, 105, 104, 91, 83, 106, 92]

    }]
});