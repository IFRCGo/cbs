import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, Popup, CircleMarker, TileLayer, Marker} from "react-leaflet";
import MarkerClusterGroup from "react-leaflet-markercluster";
//import "../assets/map.css";

import { Alert, Button, Text } from "evergreen-ui";
import { CaseReportsLast7DaysQuery } from "../Features/Map/CaseReportsLast7DaysQuery";
import { QueryCoordinator } from "@dolittle/queries";


function ListOfHealthRisks({healthRisks, icons}){
    var listItem = healthRisks.map(function(healthRisk, i){
        var col = icons[i].color;
        var cl = icons[i].class;
        return <li className="map-overview-list-item"><i style={{"color" : col}} class={cl} ></i>   :    {healthRisk}</li>
    });
    return listItem
}

class MapOverview extends Component {
    constructor(props) {
        super(props);
        this.state = {
            healthRisks: props.healthRisks,
            icons: props.icons,
            isLoading: true,
            isError: false
        };
    }

    componentDidMount() {

    }

    componentDidUpdate(prevProps) {

    }

    render() {
        console.log(this.state.icons);
        return (
            <ul className="healthRiskList">
                <ListOfHealthRisks healthRisks={this.state.healthRisks} icons={this.state.icons}></ListOfHealthRisks>
            </ul>
        );
    }
}


export default MapOverview;
