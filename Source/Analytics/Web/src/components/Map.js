import React, { Component } from "react";
import { connect } from "react-redux";
import {Map, Popup, CircleMarker, TileLayer, Markercluster } from "react-leaflet";
//import MarkerClusterGroup from "react-leaflet-markercluster";

import { formatDate, toOrDefault, fromOrDefault } from "../utils/dateUtils";
import { getJson } from "../utils/request";
import { Alert, Button, Text } from "evergreen-ui";

import { BASE_URL } from "./Analytics";
 
//require('react-leaflet-markercluster/dist/styles.min.css'); // inside .js file

function OutbreakMarkers({outbreakesLastWeek}){
    var i = 0;
    console.log("hej");
    console.log(outbreakesLastWeek);
     return outbreakesLastWeek.map(function(item){
           return <CircleMarker
                    center={[item.location.longitude + i++, item.location.latitude + i++ ]}
            ></CircleMarker>
        });
}

class MapWidget extends Component {
    constructor(props) {
        super(props);

        this.state = {
            outbreakesLastWeek: [],
            isLoading: true,
            isError: false
        };
    }

    componentWillMount() {
        console.log("Component will mount");
        this.fetchData();
    }

    componentDidMount() {
        console.log("it  did mount");
        this.fetchData();
        
    }

    componentWillUnmount(){
        console.log("it did unmount");
    }

    //  componentDidUpdate(prevProps) {
    //           this.fetchData();
    //   }

    fetchData() {
        //const from = fromOrDefault(this.props.range.from);
        //const to = toOrDefault(this.props.range.to);

        /*this.url = `${BASE_URL}M/${formatDate(
            from
        )}/${formatDate(to)}/`;
        */
        this.url = `${BASE_URL}CaseReport/Outbreak/Outbreaks`;

        this.setState({ isLoading: true });
        
        getJson(this.url)
            .then(json => {
                //console.log(json); 
                    this.setState({
                        outbreakesLastWeek: json,
                        isLoading: false ,
                        isError: false
                    });
                }
                
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
        } else if (this.state.isLoading) {
            return <div>Loading...</div>
        }
        console.log(this.state.outbreakesLastWeek);
        return (
            <Map center={position} zoom={5} style={{height: 210, width: 210}}>
                <TileLayer
                    attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                    url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
                />
                <OutbreakMarkers 
                    outbreakesLastWeek={this.state.outbreakesLastWeek}
                />
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
