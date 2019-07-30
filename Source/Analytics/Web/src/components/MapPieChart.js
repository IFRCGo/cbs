import React, { Component } from "react";


function Circles({ size, numberOfCases, casesPerHealthRisk }) {
    var nbrOfHealthRisks = Object.keys(casesPerHealthRisk).length
    var areaPerColor = Math.ceil(100.0 / nbrOfHealthRisks);
    var nextOffset = 0
    var circles = []
    var listItems = []

    for (var key in casesPerHealthRisk) {
        var strokeDasharray = areaPerColor + ' 100'
        var strokeDashoffset = nextOffset
        nextOffset -= areaPerColor
        var listItem = <li style={{ fontSize: "10px" }}>  <div className="overview-healthrisk-label" style={{backgroundColor: casesPerHealthRisk[key].color}}></div> {casesPerHealthRisk[key].name} : {casesPerHealthRisk[key].count}  </li>
        var stroke = casesPerHealthRisk[key].color
        var circle = <circle cx={"50%"} cy={"50%"} r={"24.9%"} style={{strokeDasharray: strokeDasharray, strokeDashoffset: strokeDashoffset, stroke: stroke }}></circle>
        listItems.push(listItem)
        circles.push(circle)
    }

    var centerOffset = (size / 2) * (-1)
    var sizePx = size - 4 + "px"
    return (<div className="box-parent"><div className="box-overview">
        <h6 style={{ textAlign: "center", margin: "auto" }}> Total cases: {numberOfCases}</h6>
        <ul style={{ padding: "inherit", marginBottom: "auto", marginTop: "auto" }} className="box-overview-list">
            {listItems}
        </ul>
    </div>
        <svg viewBox="0 0 64 64" className="pie" width={sizePx} height={sizePx}>{circles}</svg>
        <div className="number-of-cases-in-cluster">{numberOfCases}</div>

    </div>
    );
}

class MapPieChart extends Component {
    constructor(props) {
        super(props);
        this.state = {
            numberOfCases: props.numberOfCases,
            casesPerHealthRisk: props.casesPerHealthRisk,
            size: props.size,
            isLoading: true,
            isError: false
        };
    }

    render() {
        return (
            <Circles size={this.state.size} numberOfCases={this.state.numberOfCases} casesPerHealthRisk={this.state.casesPerHealthRisk}></Circles>
        );
    }
}


export default MapPieChart;
