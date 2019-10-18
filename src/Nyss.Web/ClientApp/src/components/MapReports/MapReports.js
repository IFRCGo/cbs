import React, { useEffect, useRef } from "react";
import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import {
  getCaseReports,
  getHealthRisks,
  getDataCollectors
} from "./functions/fetchHealthData";
import Modal from "./modal/modalReports";
import MarkerClusterGroup from "react-leaflet-markercluster";

const MapReports = () => {
  console.log(getCaseReports());
  console.log(getHealthRisks());
  console.log(getDataCollectors());
  //fonction de filter

  const createClusterCustomIcon = function (cluster) {
    return L.divIcon({
      html: `<span>${cluster.getChildCount()}</span>`,
      className: 'marker-cluster-custom',
      iconSize: L.point(40, 40, true),
    });
  };


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

      {/* CLUSTER GROUP */}
          <MarkerClusterGroup
    showCoverageOnHover={false}
    spiderfyDistanceMultiplier={2}
    iconCreateFunction={createClusterCustomIcon}
    
  >

    <Marker position={[49.8397, 24.0297]}/>
    <Marker position={[50.4501, 30.5234]} />
    <Marker position={[52.2297, 21.0122]} />
    <Marker position={[50.0647, 19.9450]} />
    <Marker position={[48.9226, 24.7111]} />
    <Marker position={[48.7164, 21.2611]} />
    <Marker position={[51.5, -0.09]}><Popup>{"plop"}</Popup></Marker>  
    <Marker position={[51.5, -0.09]} />
    <Marker position={[51.5, -0.09]} />

  </MarkerClusterGroup>



        {/* <Marker position={[0, 0]}>
          <Popup>{`Hello world`}</Popup>
        </Marker> */}
      </Map>
    </div>
  );
};

export default MapReports;
