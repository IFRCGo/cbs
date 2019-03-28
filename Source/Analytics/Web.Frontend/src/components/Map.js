import React, { Component } from "react";
import { render } from 'react-dom'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as actions from '../actions/analysisactions';
import {
    Map,
    Popup,
    CircleMarker,
    TileLayer,
} from 'react-leaflet'

const OutbreakMarkers = ({ outbreaks }) => (
    <>
        {outbreaks.map((data, index) => (
            <CircleMarker key={index} center={data.center} color={data.color} radius={data.radius}>
                <Popup>{data.popup}</Popup>
            </CircleMarker>
        ))}
    </>
);

var outbreakCollection = [
    { center: [51.51, -0.12], color: 'red', radius: 50, popup: 'Kolera' },
    { center: [71.51, -30.12], color: 'yellow', radius: 30, popup: 'Ebola' }
];

class MapWidget extends Component {

    constructor(props) {
        super(props);
    }

    //TODO Implement component and diagrams
    render() {
        const position = [0, 0]

        return (
            <div>
                <Map center={position} zoom={1}>
                    <TileLayer
                        attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                        url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                    />
                    <OutbreakMarkers outbreaks={outbreakCollection} />
                </Map>
            </div>
        );
    }

    componentDidMount() {
    }
}

function mapStateToProps(state) {
    return {
        options: state.epicurveByDay
    }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(MapWidget);