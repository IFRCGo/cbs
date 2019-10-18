import React from "react";
import { getHealthRisks } from "./functions/fetchHealthData";

import "./Filters.css";

const Filters = props => {
  // get health risk
  const risks = getHealthRisks();

  const handleHealthRisk = event => {
    console.log("clicked : ", event.target.value);
  };

  const handleStartDate = event => {
    console.log("start date : ", event.target.value);
  };

  const handleEndDate = event => {
    console.log("end date : ", event.target.value);
  };

  return (
    <div className="Filters">
      <div className="filter">
        <span className="label">Health risks</span>
        <div className="inputFilter">
          <select onChange={e => handleHealthRisk(e)}>
            <option key="all" value="all">
              ALL
            </option>

            {risks.map(risk => {
              return (
                <option key={risk.Id} value={risk.Id}>
                  {risk.Name}
                </option>
              );
            })}
          </select>
        </div>
      </div>

      <div className="filter">
        <span className="label">Start date</span>
        <div className="inputFilter">
          <input
            type="date"
            name="startDate"
            onChange={e => handleStartDate(e)}
          ></input>
        </div>
      </div>

      <div className="filter">
        <span className="label">End date</span>
        <div className="inputFilter">
          <input
            type="date"
            name="endDate"
            onChange={e => handleEndDate(e)}
          ></input>
        </div>
      </div>
    </div>
  );
};

export default Filters;
