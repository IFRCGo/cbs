import React, { useEffect, useRef } from "react";
import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";

//data import
import {
  getCaseReports,
  getHealthRisks,
  getDataCollectors
} from "./functions/fetchHealthData";

//mordal for each case
// import Modal from "./modal/modalReports";

//leaflet marker cluster group import
import MarkerClusterGroup from "react-leaflet-markercluster";
require("react-leaflet-markercluster/dist/styles.min.css");

const MapReports = () => {
  const casesReports = getCaseReports();
  console.log(getHealthRisks());
  console.log(getDataCollectors());
  //filter function

  const createClusterCustomIcon = function(cluster) {
    return L.divIcon({
      html: `<span>${cluster.getChildCount()}</span>`,
      className: "marker-cluster-custom",
      iconSize: L.point(40, 40, true)
    });
  };
  const markers = () => {
    return L.markerClusterGroup(
      <Marker position={[0, 0]}>
        <Popup>{`Hello world`}</Popup>
      </Marker>
    );
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
          {casesReports.map(el => {
            console.log(el.DataCollectorId);
            const lat = 0;
            const long = 0;
            return (
              <Marker key={el._id} position={[lat, long]}>
                <Popup>{`Hello world`}</Popup>
              </Marker>
            );
          })}
        </MarkerClusterGroup>
         
        {/* <Marker position={[0, 0]}>
          <Popup>{`Hello world`}</Popup>
        </Marker> */}
      </Map>
    </div>
  );
};

export default MapReports;
