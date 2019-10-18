import React, { useEffect, useRef } from "react";
//import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import {
  getCaseReports,
  getHealthRisks,
  getDataCollectors
} from "./functions/fetchHealthData";

const MapReports = () => {
  console.log(getCaseReports());
  console.log(getHealthRisks());
  console.log(getDataCollectors());

  return (
    <div className={"leaflet-map-container"}>
      <p>{"hello world"}</p>
      <Map
        id={"leaflet-map"}
        center={[0, 0]}
        zoom={2}
        maxZoom={19}
        style={{
          height: "545px",
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
