import React, { Component, useState } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as actions from "../actions/kpiactions";
import { Heading, UnorderedList, ListItem, Button } from "evergreen-ui";
import { DatePicker } from "./DatePicker";
import { updateRange } from "../actions/analysisactions";

class AnalyticsBanner extends Component {
    constructor(props) {
        super(props);

        this.state = { showDatePicker: false, from: null, to: null };
    }

    render() {
        const test = this.props.kpi.payload || {
            caseReports: {
                totalNumberOfReports: 0,
                reportedHealthRisks: []
            }
        };
        return (
            <>
                <div className="analytics--header">
                    <Heading paddingBottom="20px" size={700}>
                        Overview
                    </Heading>
                    <Button
                        iconBefore="calendar"
                        onClick={() =>
                            this.setState({
                                showDatePicker: !this.state.showDatePicker
                            })
                        }
                    >
                        Choose date
                    </Button>
                    {this.state.showDatePicker && (
                        <DatePicker
                            numberOfReports={2}
                            onRangeSelected={range => {
                                console.log(range);
                                this.setState({
                                    ...range,
                                    showDatePicker: false
                                });

                                this.props.updateRange("Day", range);
                            }}
                        />
                    )}
                </div>

                <div className="analytics--headerPanelContainer">
                    <div className="analytics--headerPanel">
                        <i className=" fa fa-heartbeat fa-5x analytics--headerPanelIcon" />

                        <Heading color="#9f0000" size={800} paddingTop={"20px"}>
                            {test.caseReports.totalNumberOfReports} Reports
                        </Heading>
                        <div className="analytics--listContainer">
                            <UnorderedList size={500}>
                                {test.caseReports.reportedHealthRisks.map(
                                    (data, index) => (
                                        <ListItem key={index}>
                                            {data.numberOfReports} {data.name}
                                        </ListItem>
                                    )
                                )}
                            </UnorderedList>
                        </div>
                    </div>
                    <div className="analytics--headerPanel">
                        <i className="analytics--headerPanelIcon fa fa-user fa-5x" />

                        <Heading color="#009f00" size={800} paddingTop={"20px"}>
                            45 Active Data Collectors
                        </Heading>
                        <div className="analytics--listContainer">
                            <UnorderedList size={500}>
                                <ListItem>13 Inactive</ListItem>
                            </UnorderedList>
                        </div>
                    </div>
                    <div className="analytics--headerPanel">
                        <i className="analytics--headerPanelIcon fa fa-exclamation-triangle fa-5x " />

                        <Heading color="#9f0000" size={800} paddingTop={"20px"}>
                            3 Alerts
                        </Heading>
                        <div className="analytics--listContainer">
                            <UnorderedList size={500}>
                                <ListItem>7 Measels</ListItem>
                                <ListItem>14 Cholera</ListItem>
                                <ListItem>6 Acute Watery Diarrhea</ListItem>
                            </UnorderedList>
                        </div>
                    </div>
                </div>
            </>
        );
    }

    componentDidMount() {
        this.props.fetchPostsWithRedux();
    }
}

function mapStateToProps(state) {
    return {
        kpi: state.kpi
    };
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators({ ...actions, updateRange }, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AnalyticsBanner);
