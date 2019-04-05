import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, Popup, CircleMarker, TileLayer } from "react-leaflet";
import { formatDate, toOrDefault, fromOrDefault } from "../utils/dateUtils";

import { BASE_URL } from "./Analytics";

const OutbreakMarkers = ({ outbreaks }) => (
    <>
        {outbreaks.map((data, index) => (
            <CircleMarker
                key={index}
                center={data.center}
                color={data.color}
                radius={data.radius}
            >
                <Popup>{data.popup}</Popup>
            </CircleMarker>
        ))}
    </>
);

class MapWidget extends Component {
    constructor(props) {
        super(props);

        this.state = {
            outbreaks: [],
            isLoading: true,
            isError: false
        };
    }

    componentDidMount() {
        this.fetchData();
    }

    componentDidUpdate(prevProps) {
        if (
            prevProps.range.from !== this.props.range.from ||
            prevProps.range.to !== this.props.range.to
        ) {
            this.fetchData();
        }
    }

    fetchData() {
        const from = fromOrDefault(this.props.range.from);
        const to = toOrDefault(this.props.range.to);

        const url = `${BASE_URL}Analysis/Outbreaks/${formatDate(
            from
        )}/${formatDate(to)}/`;

        fetch(url, { method: "GET" })
            .then(response => response.json())
            .then(json =>
                this.setState({
                    outbreaks: json,
                    isLoading: false,
                    isError: false
                })
            )
            .catch(_ => this.setState({ isLoading: false, isError: true }));
    }

    render() {
        const position = [48.8, 2.3];
        return (
            <div>
                <Map center={position} zoom={6}>
                    <TileLayer
                        attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                        url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                    />
                    <OutbreakMarkers outbreaks={this.state.outbreaks} />
                </Map>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        range: state.analytics.range
    };
}

export default connect(mapStateToProps)(MapWidget);
