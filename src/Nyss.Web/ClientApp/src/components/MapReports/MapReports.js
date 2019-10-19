import React, { useState, useEffect } from "react";
import L from "leaflet";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import Filters from "./Filters";
import MapPopup from "./Popup";
import ColorsLegend from "./ColorsLegend";

//data import
import {
  getCaseReports,
  getHealthRisks,
  getDataCollectors
} from "./functions/fetchHealthData";

//leaflet marker cluster group import
import MarkerClusterGroup from "react-leaflet-markercluster";
require("react-leaflet-markercluster/dist/styles.min.css");
require("./mapReports.css");

const MapReports = () => {
  const caseReports = getCaseReports();
  const dataCollectors = getDataCollectors();
  const healthRisk = getHealthRisks();

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

  const createClusterCustomIcon = function (cluster) {
    const count = cluster.getChildCount();
    let size = "medium";
    let markerSizeXL = 40;

    if (count < 10) {
      size = "Small";
      markerSizeXL = 30;
    } else if (count >= 10 && count < 50) {
      size = "Medium";
      markerSizeXL = 60;
    } else if (count >= 50 && count < 500) {
      size = "Large";
      markerSizeXL = 90;
    }
    const options = {
      cluster: `markerCluster${size}`
    };

    return L.divIcon({
      html: `
      <span style="position: absolute; left: 50%; top: 50%; transform: translate(-50%, -50%); font-size:15px; color:black; z-index:250">${cluster.getChildCount()}</span>
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200"><defs><style>.cls-1{fill:#${
        groupColor.white
        };}.cls-2{fill:#${
        groupColor.black
        };}</style></defs><title></title><g id="Calque_2" data-name="Calque 2"><g id="Calque_2-2" data-name="Calque 2"><circle class="cls-1" cx="100" cy="100" r="88.5"/><path class="cls-2" d="M100,23a77,77,0,1,1-77,77,77.08,77.08,0,0,1,77-77m0-23A100,100,0,1,0,200,100,100,100,0,0,0,100,0Z"/></g></g></svg>
      `,
      className: `${options.cluster}`,
      iconSize: L.point(markerSizeXL, markerSizeXL, true)
    });
  };
  const groupColor = {
    white: "FFF",
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

            const disease = healthRisk.filter(desease => {
              return desease.Id === el.HealthRiskId;
            })[0].Name;

            return (
              <Marker
                key={i}
                position={[
                  collectorObject.Location.Latitude,
                  collectorObject.Location.Longitude
                ]}
                icon={L.divIcon({
                  html: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200"><defs><style>.cls${color}-1{fill:#${color};}.cls${color}-2{fill:#${color};}</style></defs><title>${disease}</title><g id="Calque_2" data-name="Calque 2"><g id="Calque_2-2" data-name="Calque 2"><circle class="cls${color}-1" cx="100" cy="100" r="99.5"/><path class="cls${color}-2" d="M100,1A99,99,0,1,1,1,100,99.11,99.11,0,0,1,100,1m0-1A100,100,0,1,0,200,100,100,100,0,0,0,100,0Z"/></g></g></svg>`,
                  iconSize: [40, 40],
                  iconAnchor: [20, 20],
                  className: "leaflet-marker-icon"
                })}
              >
                <Popup>
                  <MapPopup collector={collectorObject} report={el} />
                </Popup>
              </Marker>
            );
          })}
        </MarkerClusterGroup>
      </Map>
      <ColorsLegend
        healthRiskColor={healthRiskColor}
        healthRisk={healthRisk}
      ></ColorsLegend>
    </div>
  );
};

export default MapReports;
