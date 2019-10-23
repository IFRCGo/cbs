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
  getDataCollectors,
  getColorsHealthRIsks
} from "./functions/fetchHealthData";

//leaflet marker cluster group import
import MarkerClusterGroup from "react-leaflet-markercluster";
require("react-leaflet-markercluster/dist/styles.min.css");
require("./mapReports.css");

const MapReports = () => {
  const caseReports = getCaseReports();
  const dataCollectors = getDataCollectors();
  const healthRisk = getHealthRisks();
  const healthRiskColor = getColorsHealthRIsks();
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

  const createClusterCustomIcon = function (cluster) {
    const count = cluster.getChildCount();
    const clusterDetail = cluster.getAllChildMarkers();
    //scoreboard
    let tabHealRisk = {};
    for (let i = 0; i < clusterDetail.length; i++) {
      const healthRiskID =
        clusterDetail[i]._popup.options.children.props.report.HealthRiskId;

      if (tabHealRisk.hasOwnProperty(healthRiskID)) {
        tabHealRisk[healthRiskID]++;
      } else {
        tabHealRisk[healthRiskID] = 1;
      }
    }

    //most id reported
    let mostIdReported = { id: 0, value: -1 };
    Object.getOwnPropertyNames(tabHealRisk).forEach(el => {
      if (tabHealRisk[el] > mostIdReported.value) {
        mostIdReported.id = el;
        mostIdReported.value = tabHealRisk[el];
      }
    });
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

    const groupColor = {
      middle: healthRiskColor.filter(shade => {
        return shade.Id === parseInt(mostIdReported.id);
      })[0].Color,
      border: "E32219"
    };

    let icon = `
      <svg width="100%" height="100%" viewBox="0 0 42 42" class="donut" aria-labelledby="beers-title beers-desc" role="img">

        <circle class="donut-hole" cx="21" cy="21" r="15.91549430918954" fill="#fff" role="presentation"></circle>
        <circle class="donut-ring" cx="21" cy="21" r="15.91549430918954" fill="transparent" stroke="#d2d3d4" stroke-width="3" role="presentation"></circle>

    `;

    const sum = Object.values(tabHealRisk).reduce(
      (acc, current) => acc + current
    );

    let dash = 0;

    for (const risk in tabHealRisk) {
      let gap = (tabHealRisk[risk] * 100) / sum;
      dash += gap;

      const color = healthRiskColor.filter(shade => {
        return shade.Id === parseInt(risk);
      })[0].Color;

      icon += `
      <circle class="donut-segment" cx="21" cy="21" r="15.91549430918954" fill="transparent" stroke="#${color}" stroke-width="3" stroke-dasharray="${gap} ${100 -
        gap}" stroke-dashoffset="${dash}" aria-labelledby="donut-segment-1-title donut-segment-1-desc">
        <title id="donut-segment-1-title"></title>
      </circle>`;
    }

    icon += `
    <g class="chart-text">
    <text x="50%" y="50%" class="chart-number">
      ${count}
    </text>
    </g>`;

    icon += "</svg>";

    return L.divIcon({
      html: icon,
      className: `${options.cluster}`,
      iconSize: L.point(markerSizeXL, markerSizeXL, true)
    });
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