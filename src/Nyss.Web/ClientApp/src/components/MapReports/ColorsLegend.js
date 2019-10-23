import React from "react";

function ColorsLegend(props) {
  return (
    <div className={"ColorsLegend"}>
      {props.healthRisk.map((el, i) => {
        const color = props.healthRiskColor.filter(elColor => {
          return elColor.Id === el.Id;
        })[0].Color;
        let styleCircle = {
          width: "2.5vw",
          height: "2.5vw",
          backgroundColor: `#${color}`
        };

        return (
          <div key={i} className="DiseaseAndColorCircle">
            {el.Name} : <div className={"circle"} style={styleCircle}></div>
          </div>
        );
      })}
    </div>
  );
}

export default ColorsLegend;
