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
