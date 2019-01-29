var locations = epiCurveByWeek.getLocations();

var series = [];
locations.forEach(function(location) {
    var data = [];

    data.push(epiCurveByWeek.getCountOf([
      {property: 'geo', value: location},
      {property: 'sex', value: 'Male'},
      {property: 'age', value: 'Age <5'}
    ]));

    data.push(epiCurveByWeek.getCountOf([
      {property: 'geo', value: location},
      {property: 'sex', value: 'Male'},
      {property: 'age', value: 'Age 5+'}
    ]));

    data.push(epiCurveByWeek.getCountOf([
      {property: 'geo', value: location},
      {property: 'sex', value: 'Female'},
      {property: 'age', value: 'Age <5'}
    ]));

    data.push(epiCurveByWeek.getCountOf([
      {property: 'geo', value: location},
      {property: 'sex', value: 'Female'},
      {property: 'age', value: 'Age 5+'}
    ]));

    
    series.push({
      name: location,
      data: data
    });
  });


Highcharts.chart('ageSexDistribution', {
    chart: {
        type: 'column'
    },
    title: {
        text: 'Age and sex distribution over different geographical regions'
    },
    subtitle: {
        text: 'Source: youlinkhere.com'
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
    series: series
});