/**
 * Created by Aloisio Alessandro
 * https://aloisio.work
 */

import React, { useState, useEffect } from "react";

import DatePicker from "react-datepicker";

import { getHealthRisks } from "./functions/fetchHealthData";
import convertDate from "./functions/convertDate";

import "./Filters.css";
import "react-datepicker/dist/react-datepicker.css";

const Filters = props => {
  const risks = getHealthRisks();
  const dateFormat = "MMM dd, yyyy";

  const [risk, setRisk] = useState(null);
  const [startDate, setStartDate] = useState(new Date("1-1-2019"));
  const [endDate, setEndDate] = useState(new Date());

  const handleHealthRisk = event => setRisk(event.target.value);

  useEffect(() => {
    let idToShow = [...props.reports];

    // RISK
    if (risk !== null && risk !== "all")
      idToShow = idToShow.filter(
        report => report.HealthRiskId === parseInt(risk)
      );

    // Start Date
    if (startDate !== null)
      idToShow = idToShow.filter(
        report => convertDate(report.Timestamp) >= new Date(startDate).getTime()
      );

    // End Date
    if (endDate !== null)
      idToShow = idToShow.filter(
        report => convertDate(report.Timestamp) <= new Date(endDate).getTime()
      );

    // SEND TO UPDATE MAPS COMPONENTS
    props.showing(idToShow.map(report => report.Id));
  }, [risk, startDate, endDate]);

  return (
    <div className="Filters">
      <div className="filter">
        <span className="label">Health risks</span>
        <div className="inputFilter">
          <select onChange={e => handleHealthRisk(e)}>
            <option key="all" value="all">
              All
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
        <div className="inputFilter datepicker">
          <DatePicker
            selected={startDate}
            onChange={date => setStartDate(date)}
            dateFormat={dateFormat}
          />
        </div>
      </div>

      <div className="filter">
        <span className="label">End date</span>
        <div className="inputFilter datepicker">
          <DatePicker
            selected={endDate}
            onChange={date => setEndDate(date)}
            dateFormat={dateFormat}
          />
        </div>
      </div>
    </div>
  );
};

export default Filters;
