import React, { Component } from "react";
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { getJson } from "../../utils/request";
import GridListTile from '@material-ui/core/GridListTile';
import GridList from '@material-ui/core/GridList';
import ListSubheader from '@material-ui/core/ListSubheader';

import { BASE_URL } from "../Analytics";

const defaultOptions = {
    chart: {
        type: "bar"
    },
    title: {
        text: ""
    },
    subtitle: {
        text: "Source: CSB"
    },
    xAxis: {
        categories: [],
        crosshair: true
    },
    yAxis: {
        min: 0,
        title: {
            text: "Number in cases in total"
        }
    },
    plotOptions: {
        bar: {
            dataLabels: {
                enabled: true
            }
        }
    },
    series: [{
      name: 'Number of cases in total',
      data: []
    }
]
};

class HealthRiskPerDistrictBarCharts extends Component {
    constructor(props) {
        super(props);

        this.state = {
            healthRisks: [],
            isLoading: true,
            isError: false,
            series: []
        };
    }

    fetchData() {
        this.url = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/CaseReportByDistrict';
        // this.url = `${BASE_URL}Epicurve/${formatDate(from)}/${formatDate(to)}/${
        //     this.state.value
        // }?${series}`;

        getJson(this.url)
            .then(json =>
{
                let healthRisks = [];
                let healthRiskPerDistrict = json.healthRisksPerDistrict;

                for (let i = 0; i < healthRiskPerDistrict.length; i++) {
                    let healthRisk = { name:healthRiskPerDistrict[i].name, options:{}};
                    let districts_names = [], district_cases = [];
                    for (let district of healthRiskPerDistrict[i].districts) {
                        districts_names.push(district.name);
                        district_cases.push(district.numberOfCaseReports);
                     }

                    healthRisk.options = JSON.parse(JSON.stringify(defaultOptions));
                    healthRisk.options.title.text = healthRisk.name; 
                    healthRisk.options.xAxis.categories = districts_names;
                    healthRisk.options.series[0].data = district_cases;

                    healthRisks.push(healthRisk);
                }

                this.setState({
                    healthRisks: healthRisks,
                    isLoading: true,
                    isError: false
                })
            }
            )
            .catch(_ => this.setState({ isLoading: false, isError: true }));
    }

    componentDidMount() {
        this.fetchData();
    }

    render() {
        return (
            <GridList cols={4}>
               <GridListTile key="CaseReportBarCharts" cols={4} style={{ height: 'auto' }}>
        <ListSubheader component="div">No. of case reports per health risk per district in the last 7 days</ListSubheader>
        </GridListTile>
            {this.state.healthRisks.map((healthRisk) => (
               <GridListTile key={'Grid'+healthRisk.name} cols={2} style={{ height: 'auto' }}>
                <HighchartsReact key={healthRisk.name} highcharts={Highcharts} options={healthRisk.options} />
                </GridListTile>
            ))}
            </GridList>
        );
    }
}

export default HealthRiskPerDistrictBarCharts;
