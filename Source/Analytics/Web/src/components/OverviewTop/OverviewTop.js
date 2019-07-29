import React, { Component } from "react";
import './overview-top.scss';

import { CaseReportTotalQuery } from "../../Features/CaseReports/CaseReportTotalQuery";
import { DataCollectorsQuery } from "../../Features/DataCollectors/DataCollectorsQuery"
import { QueryCoordinator } from "@dolittle/queries";

class OverviewTop extends Component {
    constructor(props) {
        super(props);

        this.state = {
            total: null,
            isLoading: true,
            isError: false,
        };
    }

    fetchDataCollectors() {
        this.queryCoordinator = new QueryCoordinator();
        let dataCollectorsQuery = new DataCollectorsQuery();

        this.queryCoordinator.execute(dataCollectorsQuery).then(queryResult => {
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
    }

    fetchTotalCaseReports(){
        this.queryCoordinator = new QueryCoordinator();
        let caseReportTotals  = new CaseReportTotalQuery();
        this.queryCoordinator.execute(caseReportTotals).then(queryResult => {
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
        this.fetchDataCollectors();
        this.fetchTotalCaseReports();
    }

    render () {
        return (
            <div className="overview-top">
                <div className="card">
                    <i className="fa fa-heart icon"></i>
                    <p>All reports since project start:  {this.state.total} </p>
                </div>
                <div className="card">
                    <i className="fa fa-user icon"></i>
                    <p>All data collectors: <br/>
                        Active: {this.state.activeDataCollectors} <br/>
                        Inactive: {this.state.inactiveDataCollectors}
                    </p>
                </div>
            </div>
        );
    }
}
export default OverviewTop;