import React, { Component } from "react";

export const BASE_URL = "http://localhost:3000/";

class Reporting extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div className="reporting--container">
                Welcome to Reporting!
            </div>
        );
    }
}

export default Reporting;
