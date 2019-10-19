import React, { useState } from "react";

import { getHealthRisks } from "./functions/fetchHealthData";
import formatDate from "./functions/formatDate";
import sexAndAge from "./functions/sexAndAge";

import Modal from "./modal/Modal";
import ModalReports from "./modal/modalReports";

const Popup = props => {
  const risk = getHealthRisks();

  const [ShowModal, setShowModal] = useState(false);

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
        Time sent: <strong>{formatDate(props.report)}</strong>
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
        Sex/age: <strong>{sexAndAge(props.report)}</strong>
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
