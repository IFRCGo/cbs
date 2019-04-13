const url_district = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/CaseReportByDistrict';
let categories = [], cases = [];
let title, districts_names = [], district_cases = [];


fetch(url_district).then(data => data.json())
  .then(response => {
    let healthDistricts = response.healthRisksPerDistrict;
    for(let i=0; i < healthDistricts.length; i++){
      //console.log("Chart : "+ i);
        title = healthDistricts[i].name; 
       for(let district of healthDistricts[i].districts){
          districts_names.push(district.name);
          district_cases.push(district.numberOfCaseReports);
       }
       let id = 'container';
       id= id+(i+1);
       console.log("ID: "+id); 
       buildChart(id, title, districts_names, district_cases);

    }
  });


const buildChart = (i, text, names, data) => {
  Highcharts.chart(i, {
    chart: {
      type: 'bar'
    },
    title: {
      text: text
    },
    subtitle: {
      text: 'Source: CSB'
    },
    xAxis: {
      categories: names,
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
      data: data
    }]
  });

}

