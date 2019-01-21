import React from "react";
import { Label } from "evergreen-ui";
import { GoogleMap, withGoogleMap, withScriptjs } from "react-google-maps";

export class MapWithLabel extends React.Component {
    constructor(props) {
        super(props);

        this._mapsRef = {};
    }

    shouldComponentUpdate() {
        return false;
    }

    getMapsRef() {
        return this._mapsRef;
    }

    render() {
        const { label, longitude, latitude, apiKey } = this.props;
        const MapComponent = withScriptjs(
            withGoogleMap(_props => (
                <GoogleMap
                    ref={ref => (this._mapsRef = ref)}
                    defaultZoom={8}
                    defaultCenter={{
                        lat: parseFloat(latitude),
                        lng: parseFloat(longitude)
                    }}
                />
            ))
        );
        return (
            <div className="mapWithLabel--container">
                <Label>{label}</Label>
                <MapComponent
                    loadingElement={<div style={{ height: `100%` }} />}
                    googleMapURL={`https://maps.googleapis.com/maps/api/js?key=${apiKey}`}
                    containerElement={<div style={{ height: `400px` }} />}
                    mapElement={<div style={{ height: `100%` }} />}
                />
            </div>
        );
    }
}
