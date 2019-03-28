import React, { Component } from "react";
import { connect } from 'react-redux';
import Epicurvebyweek from './Epicurvebyweek.js';
import Epicurvebyday from './Epicurvebyday.js';
import Epicurvebyweekdodgedbyage from './Epicurvebyweekdodgedbyage.js';
import AnalyticsBanner from './AnalyticsBanner.js';
import Map from './Map.js'
import EpicurvebyweekGrid from './EpicurvebyweekGrid.js';
import EpicurvebyweekGrid2 from './EpicurvebyweekGrid2.js';
import EpicurvebyweekGrid3 from './EpicurvebyweekGrid3.js';
import EpicurvebyweekGrid4 from './EpicurvebyweekGrid4.js';



// import Counter from './Counter.js';


class Analytics extends Component {

    constructor(props) {
        super(props);
    }

    //TODO Implement component and diagrams
    render() {
        return (
            <article id="introduction">
                <section className="container">
                    <div>
                        {/* <Counter /> */}
                        <AnalyticsBanner />
                        <Map />
                        <Epicurvebyweek />
                        <Epicurvebyday />
                        <Epicurvebyweekdodgedbyage />
                        <table>
                            <tbody>
                            <tr>
                                <td><EpicurvebyweekGrid /></td>
                                <td><EpicurvebyweekGrid2 /></td>
                            </tr>
                            <tr>
                                <td><EpicurvebyweekGrid3 /></td>
                                <td><EpicurvebyweekGrid4 /></td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </section>
            </article>
        );
    }

}

export default Analytics;