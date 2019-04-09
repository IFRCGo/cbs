import React, { Component } from "react";
import { connect } from "react-redux";
import { Map, Popup, CircleMarker, TileLayer } from "react-leaflet";
import { formatDate, toOrDefault, fromOrDefault } from "../utils/dateUtils";
import { getJson } from "../utils/request";
import { Alert, Button } from "evergreen-ui";

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
            isLoading: false,
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

        this.url = `${BASE_URL}Analysis/Outbreaks/${formatDate(
            from
        )}/${formatDate(to)}/`;

        getJson(this.url)
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
        if (this.state.isError) {
            return (
                <div
                    className="analytics--loadingContainer"
                    style={{ height: "500px" }}
                >
                    <Alert
                        intent="danger"
                        title="We could not the reach the backend"
                    >
                        {`Url: ${this.url}`}
                    </Alert>
                    <Button
                        marginTop={"20px"}
                        iconBefore="repeat"
                        onClick={() => this.fetchData()}
                    >
                        Retry
                    </Button>
                </div>
            );
        }
        return (
            <Map center={position} zoom={6}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />
                <OutbreakMarkers outbreaks={this.state.outbreaks} />
            </Map>
        );
    }
}

function mapStateToProps(state) {
    return {
        range: state.analytics.range
    };
}

export default connect(mapStateToProps)(MapWidget);
