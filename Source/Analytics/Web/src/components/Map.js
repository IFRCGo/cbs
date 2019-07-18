import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, Popup, CircleMarker, TileLayer, Marker} from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
import "../assets/map.css";
import MapOverview from "./MapOverview";
import { Alert, Button, Text } from "evergreen-ui";
import { CaseReportsLast7DaysQuery } from "../Features/Map/CaseReportsLast7DaysQuery";
import { QueryCoordinator } from "@dolittle/queries";

var clusterSize = {
    large: 40,
    medium: 30,
    small: 20
};

var clusters     = []
var createClusterCustomIcon = function(cluster) {
    var markersInCluster  = cluster.getChildCount();

    // Get css class from markers
    var getClusterNbr = cluster.getAllChildMarkers()[0].options.icon.options.className.split(" ")[1]

    // Get healthRiskNumber from css class 
    var healthRiskNbr = getClusterNbr[getClusterNbr.length - 1]
    var markerClusterSize

    if(markersInCluster <= 5){
        markerClusterSize = clusterSize.small
    }
    else if(markersInCluster < 20){
        markerClusterSize = clusterSize.medium
    }
    else{
        markerClusterSize = clusterSize.large
    }

    return new L.divIcon({
      html: `${cluster.getChildCount()}`,
      className: "marker-" + healthRiskNbr + "-cluster marker-cluster-custom",
      iconSize: L.point(markerClusterSize, markerClusterSize, true )
    });
  }


var healthRisks  = []
var iconsClasses = []

function MarkerPopupContent(props){
    return <div>{props.healthRisk}</div>
}

function CaseMarkers({caseReportsLastWeek}){
    // Returns one Marker for each case in a case-report and sets an unique color for each specific health risk
    return  Object.keys(caseReportsLastWeek.caseReportsPerHealthRisk).map(function(key) {
        var healthRiskName   = caseReportsLastWeek.caseReportsPerHealthRisk[key][0].healthRiskName
        var healthRiskNumber = key
        var marker = "marker-" + healthRiskNumber.toString()
        var markerClass = marker + " fa fa-plus-square"
        var clusterClass = marker + "-cluster" + " marker-cluster-custom cluster-label"

        var icon = L.divIcon({
            className: 'custom-div-icon ' + markerClass,
            html: "<i></i>"
        });

        healthRisks.push(healthRiskName)
        iconsClasses.push(markerClass)
        clusters.push(clusterClass)

        var cs = caseReportsLastWeek.caseReportsPerHealthRisk[key].map(cases => {
            cases.vals = new Array(cases.numberOfPeople);
            cases.vals.fill(1);
            return cases.vals.map(function(val){
                var hl = healthRisks[healthRisks.length - 1]
                return <Marker
                    position={[cases.location.longitude, cases.location.latitude]} icon={icon}
                >
                    <Popup><MarkerPopupContent healthRisk={hl}></MarkerPopupContent></Popup>
                </Marker>
            });
        });

        return <MarkerClusterGroup iconCreateFunction={createClusterCustomIcon}>{cs}</MarkerClusterGroup>
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
            if(queryResult.success){
                this.setState({ 
                    caseReportsLastWeek: queryResult.items[0],
                    isError: false,
                    isLoading: false 
                })
            }
        }).catch(_ => 
            this.setState({
                isLoading: false,
                isError: true
            })
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
                        onClick={() => this.fetchData()}
                    >
                        Retry
                    </Button>
                </div>
            );
        } else if(this.state.isLoading) {
            return (<div>Loading...</div>);
        }
        return (
            <Map className="markercluster" center={[1.0, 1.0]} zoom={1} maxZoom={50}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />

                <CaseMarkers caseReportsLastWeek={this.state.caseReportsLastWeek}></CaseMarkers>
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
