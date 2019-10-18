import React, { useState, useEffect, useRef } from "react";
//import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import Filters from "./Filters";
import { getCaseReports, getDataCollectors } from "./functions/fetchHealthData";

const MapReports = () => {
  const caseReports = getCaseReports();
  // console.log(getDataCollectors());

  // IF ShowingReports === [] => show all caseReports
  // IF ShowingReports !== null => only show reports with id in thois array
  const [ShowingReports, setShowingReports] = useState([]);

  return (
    <div className={"leaflet-map-container"}>
      <h2>{"Reports"}</h2>
      <Filters reports={caseReports} showing={setShowingReports} />
      {console.log(ShowingReports)}
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
