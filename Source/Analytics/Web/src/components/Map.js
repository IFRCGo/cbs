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

var clusterSize = {
    large: 60,
    medium: 40,
    small: 30
};

var colors = {
    1: "#FFBF00",
    2: "#537B35",
    3: "#ED1B2E",
    4: "#56A0D3",
    5: "#7F181B",
    6: "#6D6E70",
    7:"#aaffc3",
    8:"#800000",
    9:"#42d4f4",
    10:"#bfef45",
    11:"#000075",
    12:"#a9a9a9",
    13:"#808000",
    14:"#aaffc3",
    15:"aquamarine",
    16:"seashell",
    17:"black",
    18:"#f58231",
    19:"skyblue",
    20:"#fabebe",
    21:"fa9907",
    23:"teal",
    24:"tomato",
    25:"gray",
    26:"#7F181B",
    27:"violet",
    28:"#fa9907",
    29:"peachpuff",
    30:"white",
    31:"silver",
    32:"wheat",
    99:"lightcoral"
}

var healthRisks = {}

var createClusterCustomIcon = function (cluster) {
    var markers = cluster.getAllChildMarkers();
    var markersInCluster = markers.length;
    var casesPerHealthRisk = {}

    for (var i = 0; i < markersInCluster; i++) {
        var healthRiskId = markers[i].options.icon.options.html.dataset.healthriskid

        if (!(healthRiskId in casesPerHealthRisk)) {
            casesPerHealthRisk[healthRiskId] = {
                "name": healthRisks[healthRiskId].name,
                "count": 1,
                "color": colors[healthRiskId]
            }
        } else {
            casesPerHealthRisk[healthRiskId].count++;
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
    if (caseReportsLastWeek == null) return null;
    
    // Returns one Marker for each case in a case-report and sets an unique color for each specific health risk
    return Object.keys(caseReportsLastWeek.caseReportsPerHealthRisk).map(function (healthRiskId) {
        var allCasesReportsForHealthRisk = caseReportsLastWeek.caseReportsPerHealthRisk[healthRiskId]
        var healthRiskName = allCasesReportsForHealthRisk[0].healthRiskName
        var healthRiskColor = colors[healthRiskId]

        healthRisks[healthRiskId] = {
            "name": healthRiskName,
            "color": healthRiskColor
        }

        return allCasesReportsForHealthRisk.map(grouping => {
            var markers = []



            for (var i = 0; i < grouping.numberOfPeople; i++) {
                var htmlElement = document.createElement("i")
                htmlElement.className = "fa fa-circle"
                htmlElement.setAttribute("data-healthriskid", healthRiskId)
                htmlElement.style.color = healthRiskColor

                var icon = L.divIcon({
                    className: "custom-div-icon",
                    html: htmlElement
                });

                markers.push(<Marker position={[grouping.location.longitude, grouping.location.latitude]} icon={icon}>
                    <Popup closeButton="true" autoClose="true">
                        <MarkerPopupContent healthRisk={healthRiskName}></MarkerPopupContent>
                    </Popup>
                </Marker>)
            }

            return markers;
        });
    });
};

class MapWidget extends Component {
    constructor(props) {
        super(props);

        this.state = {
            caseReportsLastWeek: [],
            wheelZoom: false,
            isLoading: true,
            isError: false
        };
        this.enableZoom = this.enableZoom.bind(this);
        this.disableZoom = this.disableZoom.bind(this);
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
                    wheelZoom: false,
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

    enableZoom(event){
        event.target.scrollWheelZoom.enable();
    }
    disableZoom(event){
        event.target.scrollWheelZoom.disable()
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
        console.log(this.state.wheelZoom)
        return (
            <Map onFocusIn={this.clicked} onBlur={this.disableZoom} onFocus={this.enableZoom} scrollWheelZoom={false} className="markercluster" center={[1.0, 1.0]} zoom={1} maxZoom={50}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />
                <MarkerClusterGroup onClusterClick={this.test} iconCreateFunction={createClusterCustomIcon}>
                    <CaseMarkers caseReportsLastWeek={this.state.caseReportsLastWeek}></CaseMarkers>
                </MarkerClusterGroup>
                <MapOverview healthRisks={healthRisks}></MapOverview>
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
