import React, { Component } from "react";

function ListOfHealthRisks({ healthRisks }) {

    var listItem = Object.keys(healthRisks).map(function (key) {
        return <li key={key} className="healthrisk-list-item">
            <span className="marker-cluster-custom" style={{ backgroundColor: healthRisks[key].color }}></span>
            {healthRisks[key].name}
        </li>
    })

    return listItem
}

class MapOverview extends Component {
    constructor(props) {
        super(props);
        this.state = {
            healthRisks: props.healthRisks,
            isLoading: true,
            isError: false
        };
    }

    render() {
        return (
            <ul className="healthRiskList">
                <ListOfHealthRisks healthRisks={this.state.healthRisks}></ListOfHealthRisks>
            </ul>
        );
    }
}

export default MapOverview;
