import React, { Component } from "react";
import AnalyticsBanner from "./AnalyticsBanner.js";
import Map from "./Map.js";
import Diagram from "./Diagram.js";

export const BASE_URL = "http://localhost:5000/api/";

class Analytics extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div className="analytics--container">
                <AnalyticsBanner />
                <Map />
                <Diagram
                    selectedSeries={["Total"]}
                    hasDatePicker
                    defaultRange={"Day"}
                    title={range => `Epicurve by ${range}`}
                />
                <Diagram
                    selectedSeries={["AgeUnderFive", "AgeFiveOrAbove"]}
                    hasDatePicker
                    defaultRange={"Week"}
                    title={range => `Epicurve by ${range} Dodged by Age`}
                />
                <div className={"analytics--twoDiagrams"}>
                    <div className="analytics--insideDiagram">
                        <Diagram
                            selectedSeries={["MaleUnderFive"]}
                            hasDatePicker={false}
                            defaultRange={"Week"}
                            title={_ => `Male Under five`}
                        />
                    </div>
                    <div className="analytics--insideDiagram">
                        <Diagram
                            selectedSeries={["MaleFiveOrAbove"]}
                            hasDatePicker={false}
                            defaultRange={"Week"}
                            title={_ => `Male Five or Above`}
                        />
                    </div>
                </div>
                <div className={"analytics--twoDiagrams"}>
                    <div className="analytics--insideDiagram">
                        <Diagram
                            selectedSeries={["FemaleUnderFive"]}
                            hasDatePicker={false}
                            defaultRange={"Week"}
                            title={_ => `Female Under five`}
                        />
                    </div>
                    <div className="analytics--insideDiagram">
                        <Diagram
                            selectedSeries={["FemaleFiveOrAbove"]}
                            hasDatePicker={false}
                            defaultRange={"Week"}
                            title={_ => `Female Five or Above`}
                        />
                    </div>
                </div>
            </div>
        );
    }
}

export default Analytics;
