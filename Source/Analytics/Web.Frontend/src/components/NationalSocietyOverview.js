import React, { Component } from "react";
import GridList from '@material-ui/core/GridList';
import Typography from '@material-ui/core/Typography';
import GridListTile from '@material-ui/core/GridListTile';
import ListSubheader from '@material-ui/core/ListSubheader';
import CaseReportByHealthRiskTable from "./healthRisk/CaseReportByHealthRiskTable";
import CardBySex from "./healthRisk/CardBySex";

class NationalSocietyOverview extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div className="analytics--container">
            <Typography component="h2" variant="headline" gutterBottom>
          Overview
        </Typography>
            <GridList>
        <GridListTile key="CaseReportByHealthRiskTable" style={{ height: 'auto' }}>
        <ListSubheader component="div">No. of case reports per health risk per time period.</ListSubheader>
        <CaseReportByHealthRiskTable />
        </GridListTile>
        <GridListTile key="CaseReportByHealthRiskTable2" style={{ height: 'auto' }}>
        <ListSubheader component="div">Blah</ListSubheader>
        <CardBySex />
        </GridListTile>
        </GridList>
            </div>
        );
    }
}

export default NationalSocietyOverview;
