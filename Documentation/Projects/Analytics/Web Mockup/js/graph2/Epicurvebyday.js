//var categories ='http://5cb05d0af7850e0014629bce.mockapi.io/api/Analysis';
 $(function () {
                var processed_json = new Array();   
                var categories = [];
                var series = [];
                $.getJSON('http://demo.cbsrc.org/analytics/api/Analysis/2019-04-06/2019-04-12/Day?selectedSeries=Female&selectedSeries=Male', function(data) {
                  //console.log(data);
                  categories = data.categories;
                  series = data.series[0].data;
                
                    // draw chart
                    Highcharts.chart('container_selectedSeries_Female_selectedSeries_Male', {
                      chart: {
                        type: 'column'
                      },
                      title: {
                        text: 'Day selected Series Female & Series Male'
                      },
                      subtitle: {
                        text: 'Source: CSB'
                      },
                      xAxis: {
              
                        categories: categories,
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
                        }
                      },
                      
                      options: {
                      barPercentage: 1.0,
                      categoryPercentage: 1.0
                    },
                      
                      series: [{
                        name: 'Number of cases in total',
                        data: series
                    
                      }]
                }); 
            });
        });
12