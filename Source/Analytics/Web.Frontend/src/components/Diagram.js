import React, { Component } from "react";
import { connect } from "react-redux";
import { formatDate, toOrDefault, fromOrDefault } from "../utils/dateUtils";
import { SegmentedControl } from "evergreen-ui";
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";

import { BASE_URL } from "./Analytics";

const defaultOptions = {
    chart: {
        type: "column"
    },
    subtitle: {
        text: "Source: CSB"
    },
    xAxis: {
        categories: [],
        crosshair: true
    },
    yAxis: {
        min: 0,
        title: {
            text: "Number in cases in total"
        }
    },
    plotOptions: {
        column: {
            pointPadding: 0.1,
            borderWidth: 0
        }
    },

    options: {
        barPercentage: 1.0,
        categoryPercentage: 1.0
    }
};

class Diagram extends Component {
    constructor(props) {
        super(props);

        this.state = {
            options: [
                { label: "Daily", value: "Day" },
                { label: "Weekly", value: "Week" }
            ],
            value: this.props.defaultRange,
            isLoading: true,
            isError: false,
            series: []
        };
    }

    fetchData() {
        const from = fromOrDefault(this.props.range.from);
        const to = toOrDefault(this.props.range.to);

        const series = this.props.selectedSeries
            .map(series => `selectedSeries=${series}`)
            .join("&");

        const url = `${BASE_URL}Analysis/${formatDate(from)}/${formatDate(
            to
        )}/${this.state.value}?${series}`;

        fetch(url, { method: "GET" })
            .then(response => response.json())
            .then(json =>
                this.setState({
                    series: json.series,
                    xAxis: { categories: json.categories },
                    isLoading: false,
                    isError: false
                })
            )
            .catch(_ => this.setState({ isLoading: false, isError: true }));
    }

    componentDidMount() {
        this.fetchData();
    }

    componentDidUpdate(prevProps, prevState) {
        if (
            this.state.value !== prevState.value ||
            prevProps.range.from !== this.props.range.from ||
            prevProps.range.to !== this.props.range.to
        ) {
            this.fetchData();
        }
    }

    render() {
        var options = {
            ...defaultOptions,
            title: { text: this.props.title(this.state.value) },
            series: this.state.series,
            xAxis: this.state.xAxis
        };

        return (
            <>
                {this.props.hasDatePicker && (
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
                )}
                <HighchartsReact highcharts={Highcharts} options={options} />
            </>
        );
    }
}

Diagram.defaultProps = {
    selectedSeries: ["Total"],
    hasDatePicker: true,
    defaultRange: "Day",
    title: range => `Epicurve by ${range}`
};

function mapStateToProps(state) {
    return {
        range: state.analytics.range
    };
}

export default connect(mapStateToProps)(Diagram);
