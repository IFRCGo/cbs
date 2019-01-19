
// Prepare random data
var data = [
    ['DE.SH', 8],
    ['DE.BE', 70],
    ['DE.MV', 63],
    ['DE.HB', 1],
    ['DE.HH', 22],
    ['DE.RP', 66],
    ['DE.SL', 38],
    ['DE.BY', 25],
    ['DE.SN', 23],
    ['DE.ST', 105],
    ['DE.NW', 37],
    ['DE.BW', 157],
    ['DE.HE', 134],
    ['DE.NI', 6],
    ['DE.TH', 704],
    ['DE.', 361]
];

$.getJSON('https://cdn.jsdelivr.net/gh/highcharts/highcharts@v7.0.0/samples/data/germany.geo.json', function (geojson) {

    // Initiate the chart
    Highcharts.mapChart('container', {
        chart: {
            map: geojson
        },
       colors: ['rgba(19,64,117,0.0005)', 'rgba(19,64,117,0.2)', 'rgba(19,64,117,0.4)',
                'rgba(19,64,117,0.5)', 'rgba(19,64,117,0.6)', 'rgba(19,64,117,0.8)', 'rgba(19,64,117,1)'],

        title: {
            text: 'Map by geographical area'
        },

        mapNavigation: {
            enabled: true,
            buttonOptions: {
                verticalAlign: 'bottom'
            }
            
        },
                    legend: {
                title: {
                    text: 'Total number of cases per region',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'black'
                    }
                },
                align: 'left',
                verticalAlign: 'bottom',
                floating: true,
                layout: 'vertical',
                valueDecimals: 0,
                backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || 'rgba(255, 255, 255, 0.85)',
                symbolRadius: 0,
                symbolHeight: 14
            },

        colorAxis: {
         dataClasses: [{
                    to: 10
                }, {
                    from: 11,
                    to: 20
                }, {
                    from: 21,
                    to: 50
                }, {
                    from: 51,
                    to: 100
                },  {
                    from: 101
                }]  
            
            
            
            
        },
       
        series: [{
            data: data,
            keys: ['code_hasc', 'value'],
            joinBy: 'code_hasc',
            name: 'Number of cases',
            states: {
                hover: {
                    color: '#a4edba'
                }
            },
            dataLabels: {
                enabled: true,
                format: '{point.properties.postal}'
            }
        }]
    });
});
