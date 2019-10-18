import React from "react";

import "./modal.css";

const Modal = props => {
  const handleClose = () => {
    props.toClose(false);
  };

  return (
    <React.Fragment>
      <button type="button" onClick={handleClose}>
        Close
      </button>
      <h1>COUCOU</h1>
    </React.Fragment>
  );
};

export default Modal;
