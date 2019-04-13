//var categories ='http://5cb05d0af7850e0014629bce.mockapi.io/api/Analysis';
$(function () {
  var processed_json = new Array();   
  var under;
  var over;
  $.getJSON('http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRiskPerAgeGroup', function(data) {
    //console.log(data);
  
    under = data.under5;
    over = data.over5;
      // draw chart
      Highcharts.chart('container_HealthRiskPerAgeGroupr', {
        chart: {
          type: 'column'
        },
        title: {
          text: 'Health Risk Per Age Groupr '
        },
        subtitle: {
          text: 'Source: CSB'
        },
        xAxis: {

          categories: [
            '<5','>5'
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
          }
        },
        
        options: {
        barPercentage: 1.0,
        categoryPercentage: 1.0
      },
        
        series: [{
          name: 'Number of cases in total',
          data: 
          [
            under,
            over
          ]
      
        }]
  }); 
});
});


