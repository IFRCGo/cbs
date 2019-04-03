import React, { Component, useState } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as actions from "../actions/kpiactions";
import {
    Heading,
    UnorderedList,
    ListItem,
    Button,
    Text,
    SegmentedControl
} from "evergreen-ui";

import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";

class Diagram extends Component {
    constructor(props) {
        super(props);

        this.state = {
            options: [
                { label: "Daily", value: "daily" },
                { label: "Weekly", value: "weekly" }
            ],
            value: "daily"
        };
    }

    render() {
        var options = {
            ...this.props.options,
            title: { text: "Epicurve by Day" }
        };

        const from = this.props.range.from
            ? new Date(this.props.range.from)
            : new Date();
        const to = this.props.range.to
            ? new Date(this.props.range.to)
            : new Date();

        return (
            <>
                <h1>{from.toLocaleDateString()}</h1>
                <h1>{to.toLocaleDateString()}</h1>
                <div className="analytics--diagramLabel">
                    <SegmentedControl
                        name="switch"
                        width={250}
                        height={30}
                        options={this.state.options}
                        value={this.state.value}
                        onChange={value => this.setState({ value })}
                    />
                </div>
                <HighchartsReact highcharts={Highcharts} options={options} />
            </>
        );
    }

    componentDidMount() {
        this.props.fetchPostsWithRedux("Day", ["Total"], "Day");
    }
}

function mapStateToProps(state) {
    return {
        range: state.epicurveByDay.range,
        options: state.epicurveByDay
    };
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(actions, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Diagram);
