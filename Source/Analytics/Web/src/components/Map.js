import React, { Component } from "react";
import { connect } from "react-redux";
import {Map, Popup, CircleMarker, TileLayer, Markercluster, Marker } from "react-leaflet";

import MarkerClusterGroup from "react-leaflet-markercluster";
import "../assets/map.css";



import { formatDate, toOrDefault, fromOrDefault } from "../utils/dateUtils";
import { getJson } from "../utils/request";
import { Alert, Button, Text } from "evergreen-ui";

import { BASE_URL } from "./Analytics";


var firefoxIcon = L.icon({
    iconUrl: 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_the_Red_Cross.svg/250px-Flag_of_the_Red_Cross.svg.png',
    iconSize: [10, 10], // size of the icon
    });

var div = document.createElement("div");
div.id = "map";


function OutbreakMarkers({outbreakesLastWeek}){
    outbreakesLastWeek.forEach(outbreak => {
        outbreak.vals = new Array(outbreak.numberOfPeople.value);
        outbreak.vals.fill(1);
    });
    return outbreakesLastWeek.map(function(item){
               return item.vals.map(function(val){     
                    return <Marker
                        position={[item.location.longitude, item.location.latitude]} icon={firefoxIcon}
                    ></Marker>
            });
                
    });
};


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

        return (
            // <Map center={position} zoom={5} style={{height: 800, width: 800}} maxZoom={100}>
            //     <TileLayer
            //         attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            //         url="http://{s}.tile.osm.org/{z}/{x}/{y}.png"
            //     />
            // <MarkerClusterGroup>
            //     
            // </MarkerClusterGroup>
            // </Map>

            <Map className="markercluster" center={[5100.0, 19.0]} zoom={4} maxZoom={18}>
            <TileLayer
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            />

            <MarkerClusterGroup>
                <OutbreakMarkers outbreakesLastWeek={this.state.outbreakesLastWeek}></OutbreakMarkers>
            </MarkerClusterGroup>

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
