import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
import "../assets/map.css";
import MapOverview from "./MapOverview";
import { Alert, Button, Text } from "evergreen-ui";
import { CaseReportsLast7DaysQuery } from "../Features/Map/CaseReportsLast7DaysQuery";
import { CaseReportsLast4WeeksQuery } from "../Features/Map/CaseReportsLast4WeeksQuery";
import { QueryCoordinator } from "@dolittle/queries";
import MapPieChart from "./MapPieChart"
import ReactDOMServer from 'react-dom/server';
import ReactDOM from 'react-dom';
import Select from 'react-select';
import MenuItem from '@material-ui/core/MenuItem';

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


var timePeriod = [
    {label: "7 days", value: 7},
    {label: "4 weeks", value: 28}
]
var health
function MarkerPopupContent(props) {
    return <div>{props.healthRisk}</div>
}

function CaseMarkers({ caseReportsLastWeek, healthRisks }) {

    
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
            caseReportsLastMonth: [], 
            currentVal: timePeriod[0],
            healthRisksMonth: {},
            healthRisksWeek: {},
            wheelZoom: false,
            isLoading: true,
            isError: false
        };
        this.enableZoom = this.enableZoom.bind(this);
        this.disableZoom = this.disableZoom.bind(this);
        this.saveSelectedValue = this.saveSelectedValue.bind(this);
        this.createClusterCustomIcon = this.createClusterCustomIcon.bind(this)
        
    }

    componentDidMount() {
        this.fetchCaseReportsBeforeDay();
    }

    componentDidUpdate(prevState, prevProps) {

        if(this.state.currentVal.value != prevProps.currentVal.value)
        {
            this.fetchCaseReportsBeforeDay();
        }
    }


    fetchCaseReportsBeforeDay() {
        this.queryCoordinator = new QueryCoordinator();
        let CaseReportsLast7Days;
        let CaseReportsLast28Days;
        CaseReportsLast7Days = new CaseReportsLast7DaysQuery();
        CaseReportsLast28Days = new CaseReportsLast4WeeksQuery();
        

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

        this.queryCoordinator.execute(CaseReportsLast28Days).then(queryResult => {
            if (queryResult.success) {
                this.setState({
                    caseReportsLastMonth: queryResult.items[0],
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
        ReactDOM.findDOMNode(this.refs.map).focus();
        event.target.style.display = "none";
    }
    disableZoom(event){
        var thisDocument = ReactDOM.findDOMNode(this.refs.mapCover);
    }
    saveSelectedValue(event){
        this.setState({ currentVal: event})
    }

    createClusterCustomIcon(cluster) {
        var markers = cluster.getAllChildMarkers();
        var markersInCluster = markers.length;
        var casesPerHealthRisk = {}

        for (var i = 0; i < markersInCluster; i++) {
            var healthRiskId = markers[i].options.icon.options.html.dataset.healthriskid
            var healthR;
            if(this.state.currentVal.value == 7){
                healthR = this.state.healthRisksWeek
            }else if(this.state.currentVal.value == 28){
                healthR = this.state.healthRisksMonth
            }

            if (!(healthRiskId in casesPerHealthRisk)) {
                if(healthR[healthRiskId]){
                casesPerHealthRisk[healthRiskId] = {
                    "name": healthR[healthRiskId].name,
                    "count": 1,
                    "color": colors[healthRiskId]
                }
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
        var caseReports;

        if(this.state.currentVal.value == 7){
            health = this.state.healthRisksWeek
            caseReports = this.state.caseReportsLastWeek

        }else if(this.state.currentVal.value == 28){
                health = this.state.healthRisksMonth

            caseReports = this.state.caseReportsLastMonth
        }else{
            return (<div>Loading...</div>);
        }
        return (
            <div>
            
            <div style={{position: "relative"}}>
                <Select onClick={this.keepFocus} style={{zIndex: "10000"}} value={this.state.currentVal} onChange={this.saveSelectedValue} options={timePeriod} ></Select>
                <div ref='mapCover' className="map-cover" onClick={this.enableZoom} onBlur={this.disableZoom}> Click anywhere in the map to start </div>
                    <Map ref='map' onFocusIn={this.clicked} onBlur={this.disableZoom} scrollWheelZoom={true} className="markercluster" center={[30.0, 2.0]} zoom={3} maxZoom={50}>
                        <TileLayer
                            attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                            url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                        />
                        <MarkerClusterGroup onClusterClick={this.test} iconCreateFunction={this.createClusterCustomIcon}>
                            <CaseMarkers caseReportsLastWeek={caseReports} healthRisks={health}></CaseMarkers>
                        </MarkerClusterGroup>
                        <MapOverview healthRisks={health}></MapOverview>
                    </Map>
            </div>
            </div>

        );
    }
}

function mapStateToProps(state) {
    return {
        range: state.analytics.range
    };
}

export default connect(mapStateToProps)(MapWidget);
