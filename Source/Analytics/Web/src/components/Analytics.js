import React , { Component } from "react";
import Epicurvebyweek from './Epicurvebyweek.js';

import Epicurvebyday from './Epicurvebyday.js';

import Epicurvebyweekdodgedbyage from './Epicurvebyweekdodgedbyage.js';



class Analytics extends Component {

    constructor(props) {
        super(props);

    }

    //TODO Implement component and diagrams
    render() {
        return (
            <article id="introduction">
          <section className="container">
          <h3>Epicurves</h3>
            <div>
                <Epicurvebyweek/>
                <Epicurvebyday/>
                <Epicurvebyweekdodgedbyage/>
            </div>
            </section>
            </article>
        );
    }

}

export default Analytics