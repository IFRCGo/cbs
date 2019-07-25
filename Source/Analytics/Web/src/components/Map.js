import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
import "../assets/map.css";
import MapOverview from "./MapOverview";
import { Alert, Button, Text } from "evergreen-ui";
import { CaseReportsLast7DaysQuery } from "../Features/Map/CaseReportsLast7DaysQuery";
import { QueryCoordinator } from "@dolittle/queries";
import MapPieChart from "./MapPieChart"
import ReactDOMServer from 'react-dom/server';
import { red, blue } from "@material-ui/core/colors";

var clusterSize = {
    large: 80,
    medium: 60,
    small: 40
};

var colors = {
    1: "#FFBF00",
    2: "#e6194B",
    3: "#f032e6",
    4: "#aaffc3",
    5: "#42d4f4",
    6: "seashell"
}

var healthRisks = []
var iconsClasses = []
var clusters = []
var hr = {}

var createClusterCustomIcon = function (cluster) {
    var markers = cluster.getAllChildMarkers();
    var markersInCluster = markers.length;
    var casesPerHealthRisk = {}

    for (var i = 0; i < markersInCluster; i++) {
        var hrid = markers[i].options.icon.options.html.slice(11, -5) //todo: improve

        if (!(hrid in casesPerHealthRisk)) {
            casesPerHealthRisk[hrid] = {
                "name": hr[hrid],
                "count": 1,
                "color": colors[hrid]
            }
        } else {
            casesPerHealthRisk[hrid].count++;
        }
    }

    //Set cluster size
    var markerClusterSize

    if (markersInCluster <= 5) {
        markerClusterSize = clusterSize.small
    }
    else if (markersInCluster < 15) {
        markerClusterSize = clusterSize.medium
    }
    else {
        markerClusterSize = clusterSize.large
    }

    return new L.divIcon({
        html: ReactDOMServer.renderToString(<MapPieChart size={markerClusterSize} numberOfCases={markersInCluster} casesPerHealthRisk={casesPerHealthRisk}>{markersInCluster}</MapPieChart>),
        iconSize: L.point(markerClusterSize, markerClusterSize, true),
        className: "cluster-icon"
    });
}

function MarkerPopupContent(props) {
    return <div>{props.healthRisk}</div>
}

function CaseMarkers({ caseReportsLastWeek }) {
    // Returns one Marker for each case in a case-report and sets an unique color for each specific health risk
    return Object.keys(caseReportsLastWeek.caseReportsPerHealthRisk).map(function (healthRiskNumber) {

        var healthRiskName = caseReportsLastWeek.caseReportsPerHealthRisk[healthRiskNumber][0].healthRiskName
        var marker = "marker-" + healthRiskNumber.toString()
        var markerClass = marker + " fa fa-plus-square"
        var clusterClass = marker + "-cluster" + " marker-cluster-custom cluster-label"

        var icon = L.divIcon({
            className: 'custom-div-icon ' + markerClass,
            html: "<i data-hr=" + healthRiskNumber + "></i>",
        });

        healthRisks.push(healthRiskName)
        iconsClasses.push(markerClass)
        clusters.push(clusterClass)
        hr[healthRiskNumber] = healthRiskName

        var cs = caseReportsLastWeek.caseReportsPerHealthRisk[healthRiskNumber].map(cases => {
            cases.vals = new Array(cases.numberOfPeople);
            cases.vals.fill(1);
            return cases.vals.map(function (val) {
                return <Marker position={[cases.location.longitude, cases.location.latitude]} icon={icon}>
                    <Popup closeButton="true" autoClose="true">
                        <MarkerPopupContent healthRisk={healthRiskName + cases.location.longitude + cases.location.latitude}></MarkerPopupContent>
                    </Popup>
                </Marker>
            });
        });

        return cs
    });
};

class MapWidget extends Component {
    constructor(props) {
        super(props);

        this.state = {
            caseReportsLastWeek: [],
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
        let CaseReportsLast7Days = new CaseReportsLast7DaysQuery();


        this.queryCoordinator.execute(CaseReportsLast7Days).then(queryResult => {
            if (queryResult.success) {
                this.setState({
                    caseReportsLastWeek: queryResult.items[0],
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
        else if (this.state.isLoading) {
            return (<div>Loading...</div>);
        }

        console.log("healthrisks:" + healthRisks)

        return (
            <Map className="markercluster" center={[1.0, 1.0]} zoom={1} maxZoom={50}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />
                <MarkerClusterGroup onClusterClick={this.test} iconCreateFunction={createClusterCustomIcon}>
                    <CaseMarkers caseReportsLastWeek={this.state.caseReportsLastWeek}></CaseMarkers>
                </MarkerClusterGroup>
                <MapOverview clusters={clusters} healthRisks={healthRisks} icons={iconsClasses}></MapOverview>
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
