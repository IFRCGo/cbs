import React, { Component } from "react";
import { AllCaseReportsQuery } from "../../Features/CaseReports/AllCaseReportsQuery";
import { DataCollectorsQuery } from "../../Features/DataCollectors/DataCollectorsQuery"
import { QueryCoordinator } from "@dolittle/queries";

class CountryKeyFigures extends Component {
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
            if (queryResult.success) {

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

    fetchTotalCaseReports() {
        this.queryCoordinator = new QueryCoordinator();
        let caseReportTotals = new AllCaseReportsQuery();
        this.queryCoordinator.execute(caseReportTotals).then(queryResult => {
            if (queryResult.success) {
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

    render() {
        return (
            <div className="country-key-figures">
                <div className="key-figure">
                    <i className="fa fa-heart icon"></i>
                    <p className="key-figure-text">
                        <span>All reports since project start: </span>
                        <span className="key-figure-number">{this.state.total}</span>
                    </p>
                </div>
                <div className="key-figure">
                    <i className="fa fa-male icon"></i>
                    <p>All data collectors:
                        <span className="key-figure-text key-figure-text--subcategory">
                            <span>Active: </span>
                            <span className="key-figure-number">{this.state.activeDataCollectors}</span>
                        </span>
                        <span className="key-figure-text key-figure-text--subcategory">
                            <span>Inactive: </span>
                            <span className="key-figure-number">{this.state.inactiveDataCollectors}</span>
                        </span>
                    </p>
                </div>
            </div>
        );
    }
}
export default CountryKeyFigures;