import React from "react";
import { Label } from "evergreen-ui";
import { GoogleMap, withGoogleMap, withScriptjs } from "react-google-maps";

export class MapWithLabel extends React.Component {
    render() {
        const { label, longitude, latitude } = this.props;
        const MapComponent = withScriptjs(
            withGoogleMap(props => (
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
                    googleMapURL="https://maps.googleapis.com/maps/api/js?key=AIzaSyCB2IPddbweufj2myYTB4NhlLmpr58kU04"
                    containerElement={<div style={{ height: `400px` }} />}
                    mapElement={<div style={{ height: `100%` }} />}
                />
            </div>
        );
    }
}
