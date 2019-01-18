import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import {BrowserRouter, Route} from "react-router-dom";
import Home from "./components/Home";

ReactDOM.render(
    <BrowserRouter>
        <App>
            <Route path="/" exact component={Home}/>
        </App>
    </BrowserRouter>
    , document.getElementById('root'));

