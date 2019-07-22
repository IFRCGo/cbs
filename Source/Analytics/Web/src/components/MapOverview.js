import React, { Component } from "react";

function ListOfHealthRisks({clusters,healthRisks, icons}){
    
    var listItem = healthRisks.map(function(healthRisk, i){
        var cl = icons[i];
        var clo = clusters[i];
        return <li className="map-overview-list-item"><div className={clo}></div> <i class={cl} id={healthRisk} ></i> : {healthRisk}</li>
    });
    return listItem
}

class MapOverview extends Component {
    constructor(props) {
        super(props);
        this.state = {
            healthRisks: props.healthRisks,
            iconClasses: props.icons,
            clusters: props.clusters,
            isLoading: true,
            isError: false
        };
    }

    render() {
        return (
            <ul className="healthRiskList">
                <ListOfHealthRisks clusters={this.state.clusters} healthRisks={this.state.healthRisks} icons={this.state.iconClasses}></ListOfHealthRisks>
            </ul>
        );
    }
}

export default MapOverview;
