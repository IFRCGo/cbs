import React, { Component } from "react";
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { getJson } from "../../utils/request";
import GridListTile from '@material-ui/core/GridListTile';
import GridList from '@material-ui/core/GridList';
import ListSubheader from '@material-ui/core/ListSubheader';
import { formatDate } from "../../utils/dateUtils";
import { QueryCoordinator } from "@dolittle/queries";

import { GetCaseReportsPerRegionLast7Days } from "../../Features/CaseReports/GetCaseReportsPerRegionLast7Days";


import { BASE_URL } from "../NationalSocietyOverview";

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
            healthRisksPerRegion: [],
            isLoading: true,
            isError: false,
            series: []
        };
    }

    fetchData() { 
        this.queryCoordinator = new QueryCoordinator();
        let healthRisksPerRegion = new GetCaseReportsPerRegionLast7Days();

        this.queryCoordinator.execute(healthRisksPerRegion).then(queryResult => {
            if(queryResult.success){
                this.setState({
                    healthRisksPerRegion: queryResult.items[0].caseReportsPerRegion,
                    isLoading: true,
                    isError: false
                })
                
            }
            else{
                this.setState({ isLoading: false, isError: true })
            }
        });
    }

    componentDidMount() {
        //this.fetchData();
    }

    render() {
        return (
            <GridList cols={4}>
               <GridListTile key="CaseReportBarCharts" cols={4} style={{ height: 'auto' }}>
        <ListSubheader component="div">No. of case reports per health risk per region in the last 7 days</ListSubheader>
        </GridListTile>
            {console.log(this.state.healthRisksPerRegion)}
            { this.state.healthRisksPerRegion.map((r) => (
               <GridListTile key={'Grid'+r.region} cols={2} style={{ height: 'auto' }}>
                <HighchartsReact key={r.region} highcharts={Highcharts} options={r.numberOfCaseReports} />
                </GridListTile>
            ))}
            </GridList>
        );
    }
}

export default HealthRiskPerDistrictBarCharts;
