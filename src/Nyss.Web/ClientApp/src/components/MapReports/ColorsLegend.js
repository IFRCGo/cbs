import React from "react";

function ColorsLegend(props) {
  return (
    <div className={"ColorsLegend"}>
      {props.healthRisk.map((el, i) => {
        const color = props.healthRiskColor.filter(elColor => {
          console.log(elColor.Id, "Healthrisk", el.Id);

          return elColor.Id === el.Id;
        })[0].Color;
        let styleCircle = {
          width: "3vw",
          height: "3vw",
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
