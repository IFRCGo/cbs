import React, { useEffect } from "react";
import ReactDOM from "react-dom";

const modalRoot = document.getElementById("modal-root");

const Modal = props => {
  const el = document.createElement("div");
  el.classList.add("modal-container");

  useEffect(() => {
    if (props.show) {
      modalRoot.appendChild(el);
      modalRoot.style.display = "block";
    } else {
      modalRoot.innerHTML = "";
      modalRoot.style.display = "none";
    }
  }, [props.show]);

  return ReactDOM.createPortal(props.children, el);
};

export default Modal;
