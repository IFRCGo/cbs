import React from "react";
import { Label } from "evergreen-ui";
import { GoogleMap, withGoogleMap, withScriptjs } from "react-google-maps";

export class MapWithLabel extends React.Component {
    shouldComponentUpdate(nextProps) {
        return (
            nextProps.latitude !== this.props.latitude ||
            nextProps.longitude !== this.props.longitude
        );
    }
    render() {
        const { label, longitude, latitude, apiKey } = this.props;
        const MapComponent = withScriptjs(
            withGoogleMap(_props => (
                <GoogleMap
                    defaultZoom={0}
                    defaultCenter={{ lat: latitude, lng: longitude }}
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
