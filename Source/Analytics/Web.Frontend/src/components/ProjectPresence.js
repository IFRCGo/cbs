import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import {
    Heading,
    Button,
    Spinner,
    Alert,
    Text
} from "evergreen-ui";
import { DatePicker } from "./DatePicker";
import { HeaderPanel } from "./HeaderPanel";
import Map from "./Map.js";
import { updateRange } from "../actions/analysisactions";
import { formatDate, fromOrDefault, toOrDefault } from "../utils/dateUtils";
import { BASE_URL } from "./Analytics";
import { getJson } from "../utils/request";

class ProjectPresence extends Component {
    constructor(props) {
        super(props);

        this.state = {
            showDatePicker: false,
            from: null,
            to: null,
            caseReports: { reportedHealthRisks: [] },
            alerts: { totalNumberOfAlerts: 0, alertsPerHealthRisk: [] },
            dataCollectors: {
                activeDataCollectors: 0,
                totalNumberOfDataCollectors: 0,
                inactiveDataCollectors: 0
            },
            isLoading: true,
            isError: false
        };
    }

    fetchData() {
        const from = fromOrDefault(this.props.range.from);
        const to = toOrDefault(this.props.range.to);

        this.url = `${BASE_URL}KPI/${formatDate(from)}/${formatDate(to)}/`;

        this.setState({ isLoading: true });

        getJson(this.url)
            .then(json =>
                this.setState({
                    alerts: json.alerts,
                    dataCollectors: json.dataCollectors,
                    caseReports: json.caseReports,
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

    componentDidUpdate(prevProps) {
        if (
            prevProps.range.from !== this.props.range.from ||
            prevProps.range.to !== this.props.range.to
        ) {
            this.fetchData();
        }
    }

    render() {
        const header = (
            <div className="analytics--header">
                <div>
                    <Heading paddingBottom="20px" size={600} display={"inline"}>
                        {`Overview`}
                    </Heading>
                    <Text size={600} paddingLeft={"10px"}>
                        {`from ${formatDate(
                            fromOrDefault(this.props.range.from)
                        )} to ${formatDate(toOrDefault(this.props.range.to))}`}
                    </Text>
                </div>
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
                            this.setState({
                                ...range,
                                showDatePicker: false
                            });

                            this.props.updateRange("Day", range);
                        }}
                    />
                )}
            </div>
        );

        if (this.state.isLoading) {
            return (
                <>
                    {header}
                    <div
                        className="analytics--loadingContainer"
                        style={{ height: "264px" }}
                    >
                        <Spinner />
                    </div>
                </>
            );
        }

        if (this.state.isError) {
            return (
                <>
                    {header}
                    <div
                        className="analytics--loadingContainer"
                        style={{ height: "264px" }}
                    >
                        <Alert
                            intent="danger"
                            title="We could not the reach the backend"
                        >
                            {`Url: ${this.url}`}
                        </Alert>
                        <Button
                            marginTop={"20px"}
                            iconBefore="repeat"
                            onClick={() => this.fetchData()}
                        >
                            Retry
                        </Button>
                    </div>
                </>
            );
        }

        let headerPanelContainerStyle = {
            display: 'flex',
            flexWrap: 'wrap',
            marginTop: 10,
            marginBottom: 10
        };
        
        return (
            <>
                {header}
                <Heading size={800} marginTop={20}>Project Presence</Heading>

                <div className="analytics--headerPanelContainer" style={headerPanelContainerStyle}>
                    <HeaderPanel 
                        headline={`${this.state.caseReports.totalNumberOfReports} Reports`}
                        list={this.state.caseReports.reportedHealthRisks}
                        color="#9f0000"
                        icon="fa-heartbeat"
                    />
                    
                    <HeaderPanel 
                        headline={`${this.state.dataCollectors.activeDataCollectors} Active Data Collectors`}
                        list={[{inactiveDataCollectors: this.state.dataCollectors.inactiveDataCollectors, name:"Inactive Data Collectors"}]}
                        color="#009f00"
                        icon="fa-user"
                    />
                    
                    <div>
                        {/*<Heading size={600} color={"#9f0000"}>Reports</Heading>*/}
                        <Map />
                    </div>
                    
                    
                    {/*
                    <HeaderPanel
                        headline={`${this.state.alerts.totalNumberOfAlerts} Alerts`}
                        list={this.state.alerts.alertsPerHealthRisk}
                        color="#9f0000"
                        icon="fa-exclamation-triangle"
                    />
                    */}
                </div>
            </>
        );
    }
}

function mapStateToProps(state) {
    return {
        range: state.analytics.range
    };
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators({ updateRange }, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ProjectPresence);
