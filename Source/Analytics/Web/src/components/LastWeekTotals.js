import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';

//import TotalCard from "./TotalCard";

import { CaseReportTotalQuery } from "../Features/Casereports/CaseReportTotalQuery";
import { QueryCoordinator } from "@dolittle/queries";


class LastWeekTotals extends Component {
    constructor(props) {
        super(props);

        this.state = {
            total: 0,
            isLoading: true,
            isError: false
        };
    }

    fetchLastWeekTotals() {
        
        this.queryCoordinator = new QueryCoordinator();
        let caseReportTotals  = new CaseReportTotalQuery();


        this.queryCoordinator.execute(caseReportTotals).then(queryResult => {
            console.log(queryResult)
        if(queryResult.success){
            var group = queryResult.items[0]
            var totalCases = group.femalesUnder5 + group.malesUnder5 + group.femalesOver5 + group.malesOver5
            this.setState({
                total: totalCases,
                isLoading: false,
                isError: false
            });
        }
    }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            })
        })
    }


    componentDidMount() {
        this.fetchLastWeekTotals();
    }

    render () {
        return (
            <>
                <Grid item xs={3} key="TotalSex" style={{ height: 'auto' }}>
                    <Typography component="h2" variant="headline">
                        Total Number Of Cases
                    </Typography>
                    <div>{this.state.total}</div>
                </Grid>
            </>
        );
    }
}
export default LastWeekTotals;