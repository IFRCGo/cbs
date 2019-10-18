import React, { useState, useEffect, useRef } from "react";
import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import Filters from "./Filters";

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
  const caseReports = getCaseReports();
  const dataCollectors = getDataCollectors();
  //filter function

  // IF ShowingReports === [] => show all caseReports
  // IF ShowingReports !== null => only show reports with id in thois array
  const [ShowingReports, setShowingReports] = useState([]);
  const [tempCaseReports, setTempCaseReports] = useState(caseReports);

  useEffect(() => {
    setTempCaseReports(
      caseReports.filter(el => {
        return ShowingReports.includes(el.Id);
      })
    );
  }, [ShowingReports]);
  const createClusterCustomIcon = function(cluster) {
    return L.divIcon({
      html: `
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200"><defs><style>.cls-1{fill:#${color.orange};}.cls-2{fill:#${color.black};}</style></defs><title>Fichier 1</title><g id="Calque_2" data-name="Calque 2"><g id="Calque_2-2" data-name="Calque 2"><circle class="cls-1" cx="100" cy="100" r="88.5"/><path class="cls-2" d="M100,23a77,77,0,1,1-77,77,77.08,77.08,0,0,1,77-77m0-23A100,100,0,1,0,200,100,100,100,0,0,0,100,0Z"/></g></g></svg>`,
      // <span>${cluster.getChildCount()}</span>
      className: "marker-cluster-custom",
      iconSize: L.point(40, 40, true)
    });
  };
const color = {
  orange : "e67e22",
  black : "2c3e50"};
  const greenMarker = L.divIcon({
    html: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200"><defs><style>.cls-1{fill:#a3d300;}.cls-2{fill:#fff;}</style></defs><title>Fichier 1</title><g id="Calque_2" data-name="Calque 2"><g id="Calque_2-2" data-name="Calque 2"><circle class="cls-1" cx="100" cy="100" r="99.5"/><path class="cls-2" d="M100,1A99,99,0,1,1,1,100,99.11,99.11,0,0,1,100,1m0-1A100,100,0,1,0,200,100,100,100,0,0,0,100,0Z"/></g></g></svg>`,
    iconSize: [40, 40],
    iconAnchor: [20, 20],
    className: "leaflet-marker-icon"
  });


  return (
    <div className={"leaflet-map-container"}>
      <h2>{"Reports"}</h2>
      <Filters reports={caseReports} showing={setShowingReports} />
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
          animate={true}
        >
          {tempCaseReports.map((el, i) => {
            const collectorObject = dataCollectors.filter(
              elData => elData.Id === el.DataCollectorId
            )[0];
            return (
              <Marker
                key={i}
                position={[
                  collectorObject.Location.Latitude,
                  collectorObject.Location.Longitude
                ]}
                icon={greenMarker}
              >
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
