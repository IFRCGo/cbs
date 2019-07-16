import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, Popup, CircleMarker, TileLayer, Marker} from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
import "../assets/map.css";
import MapOverview from "./MapOverview";
import { Alert, Button, Text } from "evergreen-ui";
import { CaseReportsLast7DaysQuery } from "../Features/Map/CaseReportsLast7DaysQuery";
import { QueryCoordinator } from "@dolittle/queries";

var colorForHealthRisks = {
    "AWD": "red",
    "Measels": "blue",
    "Bloody diarrhea": "green",
    "Ebola": "white"
};

var healthRisks = []
var iconsVals = []

function MarkerPopupContent(props){
    return <div>{props.healthRisk}</div>
}

function CaseMarkers({caseReportsLastWeek}){
    // Returns one Marker for each case in a case-report and sets an unique color for each specific health risk
    return  Object.keys(caseReportsLastWeek.caseReportsPerHealthRisk).map(function(key) {
        var htmlString = "<i style= 'color: " + colorForHealthRisks[key] + "' class='fa fa-plus-square awesome'> "
        var icon = L.divIcon({
            className: 'custom-div-icon',
            html: htmlString
        });
        healthRisks.push(key);
        iconsVals.push({color: colorForHealthRisks[key], class: "fa fa-plus-square awesome"}); 
        return caseReportsLastWeek.caseReportsPerHealthRisk[key].map(cases => {
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
            <Map className="markercluster" center={[1.0, 1.0]} zoom={1} maxZoom={10}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />
                <MarkerClusterGroup>
                    <CaseMarkers caseReportsLastWeek={this.state.caseReportsLastWeek}></CaseMarkers>
                </MarkerClusterGroup> 

                <MapOverview healthRisks={healthRisks} icons={iconsVals}></MapOverview>
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
