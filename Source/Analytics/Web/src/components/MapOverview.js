import React, { Component } from "react";

function ListOfHealthRisks({healthRisks, icons}){
    var listItem = healthRisks.map(function(healthRisk, i){
        var col = icons[i].color;
        var cl = icons[i].class;
        return <li className="map-overview-list-item"><i style={{"color" : col}} class={cl} ></i> : {healthRisk}</li>
    });
    return listItem
}

class MapOverview extends Component {
    constructor(props) {
        super(props);
        this.state = {
            healthRisks: props.healthRisks,
            icons: props.icons,
            isLoading: true,
            isError: false
        };
    }

    render() {
        console.log(this.state.icons);
        return (
            <ul className="healthRiskList">
                <ListOfHealthRisks healthRisks={this.state.healthRisks} icons={this.state.icons}></ListOfHealthRisks>
            </ul>
        );
    }
}


export default MapOverview;
