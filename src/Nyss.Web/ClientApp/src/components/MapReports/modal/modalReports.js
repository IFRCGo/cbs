import React from "react";

import formatDate from "../functions/formatDate";
import sexAndAge from "../functions/sexAndAge";
import { getHealthRisks } from "../functions/fetchHealthData";

import "./modal.css";

const Modal = props => {
  const risk = getHealthRisks();

  const handleClose = () => {
    props.toClose(false);
  };

  const showBtnAlert = () => {
    if (typeof props.report.Alert !== "undefined") {
      const href = `/alerts/${props.report.Alert}`;
      return (
        <a className="btn btn-alert" href={href}>
          Go to alert
        </a>
      );
    }
  };

  return (
    <React.Fragment>
      <div className="name">
        <h1>Report Informations</h1>
        <div className="row">
          <div className="col">
            <div className="info">
              <span className="label">Report from: </span>
              <p>{props.collector.DisplayName}</p>
            </div>
            <div className="info">
              <span className="label">Village: </span>
              <p>{props.collector.Village}</p>
            </div>
            <div className="info">
              <span className="label">Location: </span>
              <p>
                {props.collector.District}, {props.collector.Region}
              </p>
            </div>
            <div className="info">
              <span className="label">Phone: </span>
              <p>XXXXXXX</p>
            </div>
            <div className="info">
              <span className="label">Time sent: </span>
              <p>{formatDate(props.report)}</p>
            </div>
          </div>
          <div className="col">
            <div className="info">
              <span className="label">Health risk: </span>
              <p>
                {
                  risk.filter(
                    r => parseInt(r.Id) === props.report.HealthRiskId
                  )[0].Name
                }
              </p>
            </div>
            <div className="info">
              <span className="label">Sex/age: </span>
              <p>{sexAndAge(props.report)}</p>
            </div>
          </div>
        </div>
      </div>
      <div className="actions">
        {showBtnAlert()}
        <button className="btn btn-close" type="button" onClick={handleClose}>
          Close
        </button>
      </div>
    </React.Fragment>
  );
};

export default Modal;
