
Highcharts.chart('container', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'Epicurve by day dodged by age'
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
            text: 'Number of cases summed per day'
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
        data: [2, 30, 20, 55, 46, 39, 20, 47, 28, 40, 56, 35, 48, 39, 16, 10, 24, 35, 50, 24, 20]

    }, {
        name: '5 years and older',
        data: [4, 31, 50, 50, 56,  69, 70,  87, 78, 90, 86, 135, 148, 99, 116, 100, 94,  85, 70, 54, 30]

    }]
});