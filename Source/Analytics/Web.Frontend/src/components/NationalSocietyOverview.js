import React, { Component } from "react";
import GridList from '@material-ui/core/GridList';
import Typography from '@material-ui/core/Typography';
import GridListTile from '@material-ui/core/GridListTile';
import ListSubheader from '@material-ui/core/ListSubheader';
import CaseReportByHealthRiskTable from "./healthRisk/CaseReportByHealthRiskTable";
import TotalCard from "./TotalCard";
import { getJson } from "../utils/request";
import HealthRiskPerDistrictBarCharts from "./healthRisk/HealthRiskPerDistrictBarCharts";
import Map from "./Map.js";

class NationalSocietyOverview extends Component {
    constructor(props) {
        super(props);

        this.state = {
            totalFemale: "-",
            totalMale: "-",
            totalUnder5: "-",
            totalOver5: "-",
            isLoading: true,
            isError: false
        };
    }
    
    fetchData() {
        this.url = 'http://5cb05d0af7850e0014629bce.mockapi.io/api/HealthRiskPerGender';
        //this.url = `${BASE_URL}KPI/${formatDate(from)}/${formatDate(to)}/`;

        this.setState({ isLoading: true });

        getJson(this.url)
            .then(json =>
                this.setState({
                    totalFemale: json.female,
                    totalMale: json.male,
                    totalUnder5: json.under5,
                    totalOver5: json.over5,
                    isLoading: false,
                    isError: false
                })
            )
            .catch(_ =>
                this.setState({
                    isLoading: false,
                    isError: true
                })
            );
    }

    componentDidMount() {
        this.fetchData();
    }


    render() {
        return (
            <div className="analytics--container">
            <Typography component="h2" variant="headline" gutterBottom>
          Overview
        </Typography>
            <GridList cols={4}>
        <GridListTile key="CaseReportByHealthRiskTable" cols={2} style={{ height: 'auto' }}>
        <ListSubheader component="div">No. of case reports per health risk per time period.</ListSubheader>
        <CaseReportByHealthRiskTable />
        </GridListTile>
        <GridListTile cols={1} key="TotalSex" style={{ height: 'auto' }}>
        <TotalCard className={"fa fa-female"} subTitle={"Female"} total={this.state.totalFemale}  />
        <TotalCard className={"fa fa-male"} subTitle={"Male"} total={this.state.totalMale}  />
        </GridListTile>
        <GridListTile cols={1} key="TotalAge" style={{ height: 'auto' }}>
        <TotalCard subTitle={"Under 5"} total={this.state.totalUnder5}  />
        <TotalCard subTitle={"Over 5"} total={this.state.totalOver5}  />
        </GridListTile>

     
        </GridList>
        <HorizontalBarChart />
        <Map />
            </div>
        );
    }
}

export default NationalSocietyOverview;
