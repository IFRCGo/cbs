import React, { Component } from "react";
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import Card from "./Card";

//import TotalCard from "./TotalCard";

import { CaseReportTotalQuery } from "../Features/Casereports/CaseReportTotalQuery";
import { DataCollectorsQuery } from "../Features/DataCollectors/DataCollectorsQuery"
import { QueryCoordinator } from "@dolittle/queries";

class LastWeekTotals extends Component {
    constructor(props) {
        super(props);

        this.state = {
            total: null,
            isLoading: true,
            isError: false,
        };
    }

    fetchLastWeekTotals() {
        
        this.queryCoordinator = new QueryCoordinator();
        let caseReportTotals  = new CaseReportTotalQuery();
        let dataCollectorsQuery = new DataCollectorsQuery();


        this.queryCoordinator.execute(dataCollectorsQuery).then(queryResult => {
        console.log(queryResult.items[1])
        if(queryResult.success){
            
            this.setState({
                activeDataCollectors: queryResult.items[1].value,
                inactiveDataCollectors: queryResult.items[0].value,
                isLoading: false,
                isError: false,
            });
        }
        }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            });
        });

        this.queryCoordinator.execute(caseReportTotals).then(queryResult => {
        console.log(queryResult)
        if(queryResult.success){
            var item = queryResult.totalItems
            this.setState({
                total: item,
                isLoading: false,
                isError: false,
            });
        }
    }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            });
        });
    }


    componentWillMount() {
        this.fetchLastWeekTotals();
    }

    render () {
        return (
            <div style={{display: "flex", justifyContent: "space-around", fontFamily: "'Lato', 'Helvetica Neue', 'sans-serif1'", fontWeight: "300"}}>
                <div style={{textAlign: "center", width: "20%"}}>
                    <i className="fa fa-heart" style={{textAlign:"center" ,transform: "scale(3)", color:"#D3D3D3"}}></i>
                    <p>All reports since project start:  {this.state.total} </p>
                </div>
                <div style={{textAlign: "center", width: "20%"}}>
                    <i className="fa fa-user" style={{textAlign:"center" ,transform: "scale(3)", color:"#D3D3D3"}}></i>
                    <p>All data collectors: <br/>
                        Active: {this.state.activeDataCollectors} <br/>
                        Inactive: {this.state.inactiveDataCollectors}
                    </p>
                </div>
            </div>
        );
    }
}
export default LastWeekTotals;