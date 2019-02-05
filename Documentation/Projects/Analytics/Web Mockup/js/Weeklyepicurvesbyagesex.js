var weeks = epiCurveByWeek.getWeeks();
var sexes = epiCurveByWeek.getSexes();
var ages = epiCurveByWeek.getAges();

//This will get the data series for Highchart weekAll
var series = [{
    name:'Number of reported cases',
    data:[],
    dataLabels: {
        enabled: true,
        rotation: 0,
        color: '#FFFFFF',
        align: 'right',
        format: '{point.y:.0f}', // no decimal
        y: 10, // 10 pixels down from the top
        style: {
            fontSize: '13px',
            fontFamily: 'Verdana, sans-serif'
        }
    }
}];

weeks.forEach(function(week) {
    series[0].data.push([
        week,
        epiCurveByWeek.getCountOf([
            {property: 'epiWeek', value: week}
        ])
    ]);
});


//This will get the data seriesSexAge for Highchart weekSexAge
var seriesSexAge = [];
var sexAgeFakes = ['Male <5','Male 5+','Female <5','Female 5+']

function getCountsForFunction(array, fn) {
    var data = [];
    weeks.forEach(function(week) {
        //data.push(array.__proto__[fn](week));

        //This is random data, need to be change to json data -- to Einar
        data.push(Math.random()*20);
    });
    return data;
}

seriesSexAge.push({
    name: 'Male <5',
    data: getCountsForFunction(epiCurveByWeek,"getCountOfMalesAbove5ForWeek")
});    

seriesSexAge.push({
    name: 'Male 5+',
    data: getCountsForFunction(epiCurveByWeek,"getCountOfMalesUnder5ForWeek")
});    
seriesSexAge.push({
    name: 'Female <5',
    data: getCountsForFunction(epiCurveByWeek,"getCountOfFemalesAbove5ForWeek")
});    
seriesSexAge.push({
    name: 'Female 5+',
    data: getCountsForFunction(epiCurveByWeek,"getCountOfFemalesUnder5ForWeek")
});  

//Highcharts weekAll with the data series
Highcharts.chart('weekAll', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'Epicurve by week from 2018-37 to 2018-47'
    },
    subtitle: {
        text: 'Source: <a href="#">YouLinkHere</a>'
    },
    xAxis: {
        type: 'category',
        labels: {
            rotation: -45,
            style: {
                fontSize: '13px',
                fontFamily: 'Verdana, sans-serif'
            }
        }
    },
    yAxis: {
        min: 0,
        title: {
            text: 'Number of reported cases'
        }
    },
    legend: {
        enabled: false
    },
    tooltip: {
        pointFormat: 'Epicurve by week: <b>{point.y:.0f} </b>'
    },
    series: series
});

//Highcharts weekSexAge with the data seriesSexAge
Highcharts.chart('weekSexAge', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'Epicurve by week from 2018-37 to 2018-47 dodged by Age'
    },
    subtitle: {
        text: 'Source: <a href="#">YouLinkHere</a>'
    },
    
    xAxis: {
        categories: weeks,
        crosshair: true
    },
    yAxis: {
        min: 0,
        title: {
            text: 'Number og reported cases'
        }
    },
    tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y:0f} </b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
    },
    plotOptions: {
        column: {
            pointPadding: 0.2,
            borderWidth: 0
        }
    },
    series: seriesSexAge
});