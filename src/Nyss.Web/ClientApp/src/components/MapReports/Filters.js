import React from "react";

import "./Filters.css";

const Filters = props => {
  // get health risk
  const risks = [
    {
      Id: "2",
      Name: "AWD"
    },
    {
      Id: "3",
      Name: "Measels"
    },
    {
      Id: "6",
      Name: "Bloody diarrhea"
    },
    {
      Id: "4",
      Name: "Ebola"
    }
  ];

  const handleHealthRisk = event => {
    console.log("clicked : ", event.target.value);
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
          <input type="date" name="startDate"></input>
        </div>
      </div>

      <div className="filter">
        <span className="label">End date</span>
        <div className="inputFilter">
          <input type="date" name="endDate"></input>
        </div>
      </div>
    </div>
  );
};

export default Filters;
