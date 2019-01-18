import React, { Component } from 'react';
import { render } from "react-dom";

import App from './components/App.js';
import Cx from './main.css';
console.log(Cx);

render(<App name={"ok"} />, document.getElementById("app"));
