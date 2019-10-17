import React, { useEffect, useRef } from "react";
//import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";

const MapReports = () => {
  return (
    <div className={"leaflet-map-container"}>
      <Map
        id={"leaflet-map"}
        center={[0, 0]}
        zoom={15}
        maxZoom={19}
        style={{
          height: "100%",
          width: "100%"
        }}
        attributionControl={false}
      >
        <TileLayer
          attribution={
            '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
          }
          url={"https://{s}.tile.osm.org/{z}/{x}/{y}.png"}
        />
        <Marker position={[0, 0]}>
          <Popup>{`Hello world`}</Popup>
        </Marker>
      </Map>
    </div>
  );
};

export default MapReports;
