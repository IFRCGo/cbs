import React, { Component } from "react";
import Epicurvebyweek from "./Epicurvebyweek.js";
import Epicurvebyday from "./Epicurvebyday.js";
import Epicurvebyweekdodgedbyage from "./Epicurvebyweekdodgedbyage.js";
import AnalyticsBanner from "./AnalyticsBanner.js";
import Map from "./Map.js";
import EpicurvebyweekGrid from "./EpicurvebyweekGrid.js";
import EpicurvebyweekGrid2 from "./EpicurvebyweekGrid2.js";
import EpicurvebyweekGrid3 from "./EpicurvebyweekGrid3.js";
import EpicurvebyweekGrid4 from "./EpicurvebyweekGrid4.js";
import Diagrams from "./Diagrams.js";

class Analytics extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div className="analytics--container">
                <AnalyticsBanner />
                <Diagrams />
                <Map />
                <Epicurvebyweek />
                <Epicurvebyday />
                <Epicurvebyweekdodgedbyage />
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <EpicurvebyweekGrid />
                            </td>
                            <td>
                                <EpicurvebyweekGrid2 />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <EpicurvebyweekGrid3 />
                            </td>
                            <td>
                                <EpicurvebyweekGrid4 />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }
}

export default Analytics;
