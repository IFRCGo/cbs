import React, { Component } from "react";
import { render } from 'react-dom'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as actions from '../actions/analysisactions';
import { Map, Marker, Popup, TileLayer } from 'react-leaflet'


class MapWidget extends Component {

    constructor(props) {
        super(props);
    }

    //TODO Implement component and diagrams
    render() {
        const position = [51.505, -0.09]

        return (
            <Map center={position} zoom={8}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url='http://{s}.tile.osm.org/{z}/{x}/{y}.png'
                />
                <Marker position={position}>
                    <Popup>
                        A pretty CSS3 popup. <br /> Easily customizable.
                    </Popup>
                </Marker>
            </Map>
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