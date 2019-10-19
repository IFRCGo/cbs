import React, { useState } from "react";

import { getHealthRisks } from "./functions/fetchHealthData";
import formatDate from "./functions/formatDate";
import sexAndAge from "./functions/sexAndAge";

import Modal from "./modal/Modal";
import ModalReports from "./modal/modalReports";

import "./Popup.css";

const Popup = props => {
  const risk = getHealthRisks();
  const [ShowModal, setShowModal] = useState(false);
  const handleModal = e => {
    e.preventDefault();
    setShowModal(true);
  };

  return (
    <React.Fragment>
      <div className="popup-content">
        <div className="info">
          <p className="label">Report from:</p>
          <p className="bold">{props.collector.Name}</p>
        </div>

        <div className="info">
          <p className="label">Time sent:</p>
          <p className="bold">{formatDate(props.report)}</p>
        </div>

        <div className="info">
          <p className="label">Health risk:</p>
          <p className="bold">
            {
              risk.filter(r => parseInt(r.Id) === props.report.HealthRiskId)[0]
                .Name
            }
          </p>
        </div>

        <div className="info">
          <p className="label">Sex/age:</p>
          <p className="bold">{sexAndAge(props.report)}</p>
        </div>
      </div>

      <a href="#" onClick={e => handleModal(e)}>
        REPORT
      </a>

      <Modal show={ShowModal}>
        <ModalReports
          collector={props.collector}
          report={props.report}
          toClose={setShowModal}
        />
      </Modal>
    </React.Fragment>
  );
};

export default Popup;
