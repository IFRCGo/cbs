import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, TileLayer, Marker } from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
import "../assets/map.css";

import { Alert, Button, Text } from "evergreen-ui";
import { CaseReportsLast7DaysQuery } from "../Features/Map/CaseReportsLast7DaysQuery";
import { QueryCoordinator } from "@dolittle/queries";

var redCrossIcon = L.icon({
    iconUrl: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_the_Red_Cross.svg/250px-Flag_of_the_Red_Cross.svg.png',
    iconSize: [10, 10], // size of the icon
});


function CaseMarkers({ casesLastWeekAndMonth }) {

    return Object.keys(casesLastWeekAndMonth.caseReportsPerHealthRisk).map(cases => {
        var arr = []
        for(var i = 0; i < casesLastWeekAndMonth.caseReportsPerHealthRisk[cases].length; i++){
            var nbr =  casesLastWeekAndMonth.caseReportsPerHealthRisk[cases][i].numberOfPeople
            var ca = new Array(nbr);
            ca.fill(1);
            arr.push(ca.map(function (val) {
                return <Marker
                    position={[casesLastWeekAndMonth.caseReportsPerHealthRisk[cases][i].location.longitude, casesLastWeekAndMonth.caseReportsPerHealthRisk[cases][i].location.latitude]} icon={redCrossIcon}
                ></Marker>
            }));
        }
        return arr;
    }
)};

class MapWidget extends Component {
    constructor(props) {
        super(props);

        this.state = {
            casesLastWeekAndMonth: [],
            isLoading: true,
            isError: false
        };
    }

    componentDidMount() {
        this.fetchCaseReportsBeforeDay();
    }

    componentDidUpdate(prevProps) {
        if (
            prevProps.range.from !== this.props.range.from ||
            prevProps.range.to !== this.props.range.to
        ) {
            this.fetchCaseReportsBeforeDay();
        }
    }

    fetchCaseReportsBeforeDay() {
        this.queryCoordinator = new QueryCoordinator();
        let caseReportsLast7Days = new CaseReportsLast7DaysQuery();

        console.log(caseReportsLast7Days)

        this.queryCoordinator.execute(caseReportsLast7Days).then(queryResult => {
                    console.log(queryResult)
            if (queryResult.success) {

                this.setState({
                    casesLastWeekAndMonth: queryResult.items[0],
                    isError: false,
                    isLoading: false
                })
            }
        }).catch(_ => {
            this.setState({
                isLoading: false,
                isError: true
            })
        }
        );
    }

    render() {
        const position = [48.8, 2.3];
        if (this.state.isError) {
            return (
                <div
                    className="analytics--loadingContainer"
                    style={{ height: "500px" }}
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
                        onClick={() => this.fetchCaseReportsBeforeDay()}
                    >
                        Retry
                    </Button>
                </div>
            );
        }
        if (this.state.isLoading) {
            return (<div>Loading...</div>);
        }
        return (
            <Map className="markercluster" center={[1.0, 1.0]} zoom={1} maxZoom={10}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />
                <MarkerClusterGroup>
                    <CaseMarkers casesLastWeekAndMonth={this.state.casesLastWeekAndMonth}></CaseMarkers>
                </MarkerClusterGroup>
            </Map>

        );
    }
}

function mapStateToProps(state) {
    return {
        range: state.analytics.range
    };
}

export default connect(mapStateToProps)(MapWidget);
