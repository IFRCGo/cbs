const url_district = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/CaseReportByDistrict';
const url_gender = 'http://demo.cbsrc.org/analytics/api/Analysis/2019-04-06/2019-04-12/Day?selectedSeries=Female&selectedSeries=Male';
const url_gender_total = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRiskPerGender';
const url_period = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRisksLast4Weeks';
const url_age = 'http://demo.cbsrc.org/analytics/api/Analysis/2019-04-06/2019-04-12/Day?selectedSeries=AgeUnderFive&selectedSeries=AgeFiveOrAbove';
const url_age_total = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRiskPerAgeGroup';


// Case Reports By Districts
let categories = [], cases = [];
let xtext, districts_names = [], district_cases = [];
const ytext="";
const serieName = "Number of cases in total";
fetch(url_district).then(data => data.json())
    .then(response => {
        let healthDistricts = response.healthRisksPerDistrict;
        for (let i = 0; i < healthDistricts.length; i++) {
            xtext = healthDistricts[i].name;
            for (let district of healthDistricts[i].districts) {
                districts_names.push(district.name);
                district_cases.push(district.numberOfCaseReports);
            }
            let id = 'container';
            id = id + (i + 1);
            console.log("ID: " + id);
            const type='bar'
            buildChart(id, xtext, districts_names, district_cases, type, ytext, serieName);

        }
    });


const buildChart = (i, xtext, names, data, type, ytext, serieName) => {
    Highcharts.chart(i, {
        chart: {
            type: type
        },
        title: {
            text: xtext
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
                text: ytext
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
            name: serieName,
            data: data
        }]
    });
}

// Health Risks Last 4 Weeks
fetch(url_period).then(data => data.json())
    .then(response => {
        let data = response.healthRisks;
        for (let i = 0; i < data.length; i++) {
            if (i === 0) {
                for (let time of data[i].timeSeries) {
                    $('#header-period').append("<th scope='col'>" + time.name + "</th>");
                }
            }
            let reports = [];
            reports.push(data[i].name);
            for (let time of data[i].timeSeries) {
                reports.push(time.numberOfCaseReports);
            }
            let row = $("<tr>");
            for (let i = 0; i < reports.length; i++) {
                row.append($("<td>" + reports[i] + "</td>"));
            }
            $("#tablePeriod tbody").append(row);
        }
    });

// Female and Male Analytics
fetch(url_gender_total).then(data => data.json())
    .then(response => {
        $('#femaleNo').text(response.female);
        $('#maleNo').text(response.male);
        const container = 'gender';
        const text = '';
        const names = ['Male', 'Female'];
        const type = 'column';
        const ytext = "No of reports";
        const serieName = "Gender";
        let data = [ response.male, response.female];
        buildChart(container, text, names, data, type, ytext, serieName); 
        
    });

// Analystics Age Five or Above

fetch(url_age_total).then(data => data.json())
    .then(response => {
        $('#under5').text(response.under5);
        $('#over5').text(response.over5);
        const container = 'age';
        const xtext = '';
        const names = ['<5', '>5'];
        const type = 'column';
        let data = [ response.under5, response.over5];
        const ytext= "No of reports";
        const serieName = "Age";
        buildChart(container, xtext, names, data, type, ytext, serieName);   
    });

