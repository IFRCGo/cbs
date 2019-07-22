import React, { Component } from "react";


function func(event){
    console.log("hej")
}

function Circles({size, numberOfCases, casesPerHealthRisk}){
            var nbrOfHealthRisks = casesPerHealthRisk.length
            var areaPerColor = 100.0/nbrOfHealthRisks;
            var nextOffset = 0
            var circles = []
            var listItems = []

            console.log(casesPerHealthRisk)
            console.log(numberOfCases)
            for(var i = 0; i < nbrOfHealthRisks; i++){
                var strokeDasharray  = areaPerColor + ' 100'
                var strokeDashoffset = nextOffset
                nextOffset -= areaPerColor
                var listItem = <li style={{fontSize:"10px"}}> <div style={{backgroundColor: casesPerHealthRisk[i][1], height: "10px", width: "10px", display:"inline-block"}}></div> {casesPerHealthRisk[i][0][1]} : {casesPerHealthRisk[i][0][0]}  </li>
                var stroke           = casesPerHealthRisk[i][1]
                var circle =  <circle cx={"50%"} cy={"50%"} r={"24.9%"} style={{strokeDasharray: strokeDasharray, strokeDashoffset: strokeDashoffset, stroke: stroke}}></circle>
                listItems.push(listItem)
                circles.push(circle)
            }

            var centerOffset = (size / 2) * (-1)
            var sizePx = size + "px"
            return (<div className="box-parent"><div className="box-overview">
                <h5 style={{textAlign: "center"}}> Total cases: {numberOfCases}</h5>
                <ul style={{paddingLeft: "5px"}} className="box-overview-list"> 
                    {listItems}
                </ul> 
                </div>
                <div style={{position:"absolute", zIndex:100000}}>{numberOfCases}</div>
                <svg  viewBox="0 0 64 64" className="pie" width={sizePx} height={sizePx} style={{top:centerOffset, left:centerOffset}}>{circles}</svg>
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

    func(event){
        console.log("okkookokkokkokkokokokk")
    }

    render() {
        return (
            <Circles size={this.state.size} numberOfCases={this.state.numberOfCases} casesPerHealthRisk={this.state.casesPerHealthRisk}></Circles>
        );
    }
}


export default MapPieChart;
