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
  const healthRisk = getHealthRisks();
  //filter function

  // IF ShowingReports === [] => show all caseReports
  // IF ShowingReports !== null => only show reports with id in thois array
  const [ShowingReports, setShowingReports] = useState([]);
  const [tempCaseReports, setTempCaseReports] = useState(caseReports);
  const healthRiskColor = [
    {
      Id: 2,
      Color: "03A9F4"
    },
    {
      Id: 3,
      Color: "C0CA33"
    },
    {
      Id: 6,
      Color: "FF8F00"
    },
    {
      Id: 4,
      Color: "d32f2f"
    }
  ];

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
      <span>${cluster.getChildCount()}</span>
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200"><defs><style>.cls-1{fill:#${
        groupColor.orange
      };}.cls-2{fill:#${
        groupColor.black
      };}</style></defs><title>Fichier 1</title><g id="Calque_2" data-name="Calque 2"><g id="Calque_2-2" data-name="Calque 2"><circle class="cls-1" cx="100" cy="100" r="88.5"/><path class="cls-2" d="M100,23a77,77,0,1,1-77,77,77.08,77.08,0,0,1,77-77m0-23A100,100,0,1,0,200,100,100,100,0,0,0,100,0Z"/></g></g></svg>`,
      // <span>${cluster.getChildCount()}</span>
      className: "marker-cluster-custom",
      iconSize: L.point(40, 40, true)
    });
  };
  const groupColor = {
    orange: "e67e22",
    black: "2c3e50"
  };


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
          showCoverageOnHover={true}
          spiderfyDistanceMultiplier={2}
          iconCreateFunction={createClusterCustomIcon}
            singleMarkerMode={false}
          
        >
          {tempCaseReports.map((el, i) => {
            const collectorObject = dataCollectors.filter(
              elData => elData.Id === el.DataCollectorId
            )[0];
            const color = healthRiskColor.filter(shade => {
              return shade.Id === el.HealthRiskId;
            })[0].Color;
            console.log(color, el);
            

            return (
              <Marker
                key={i}
                position={[
                  collectorObject.Location.Latitude,
                  collectorObject.Location.Longitude
                ]}
                icon={L.divIcon({
                  html: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200"><defs><style>.cls${color}-1{fill:#${color};}.cls${color}-2{fill:#${color};}</style></defs><title>Fichier 1</title><g id="Calque_2" data-name="Calque 2"><g id="Calque_2-2" data-name="Calque 2"><circle class="cls${color}-1" cx="100" cy="100" r="99.5"/><path class="cls${color}-2" d="M100,1A99,99,0,1,1,1,100,99.11,99.11,0,0,1,100,1m0-1A100,100,0,1,0,200,100,100,100,0,0,0,100,0Z"/></g></g></svg>`,
                  iconSize: [40, 40],
                  iconAnchor: [20, 20],
                  className: "leaflet-marker-icon"
                })}
              >
                <Popup>{`
                  ${(() => {
                    return healthRisk.filter(desease => {
                      return desease.Id === el.HealthRiskId;
                    })[0].Name;
                  })()}
                `}</Popup>
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
