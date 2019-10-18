import React, { useState } from "react";

import { getHealthRisks } from "./functions/fetchHealthData";
import convertDate from "./functions/convertDate";

import Modal from "./modal/Modal";
import ModalReports from "./modal/modalReports";

const Popup = props => {
  const risk = getHealthRisks();

  const [ShowModal, setShowModal] = useState(false);

  const formatDate = () => {
    let date = convertDate(props.report.Timestamp);
    date = new Date(date);
    date = date.toLocaleString("default", {
      month: "short",
      day: "numeric",
      hour: "2-digit",
      minute: "2-digit"
    });
    return date;
  };

  const sexAndAge = () => {
    if (props.report.NumberOfMalesUnder5 > 0) return `Male/Below 5`;
    if (props.report.NumberOfMalesAged5AndOlder > 0) return `Male/5 or more`;
    if (props.report.NumberOfFemalesUnder5 > 0) return `Female/Below 5`;
    if (props.report.NumberOfFemalesAged5AndOlder > 0)
      return `Female/5 or more`;
  };

  const handleModal = e => {
    e.preventDefault();
    setShowModal(true);
  };

  return (
    <div>
      <p>
        Report from: <strong>{props.collector.Name}</strong>
      </p>
      <p>
        Time sent: <strong>{formatDate()}</strong>
      </p>
      <p>
        Health risk:{" "}
        <strong>
          {
            risk.filter(r => parseInt(r.Id) === props.report.HealthRiskId)[0]
              .Name
          }
        </strong>
      </p>
      <p>
        Sex/age: <strong>{sexAndAge()}</strong>
      </p>
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
    </div>
  );
};

export default Popup;
