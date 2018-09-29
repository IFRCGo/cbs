import { select } from 'd3-selection';
import * as React from 'react';
import * as d3 from "d3";

interface Props {
  data: number[];
  width: number;
  height: number;
}

class Epicurve extends React.Component<Props> {
    constructor(props) {
        super(props);
        this.svgRef = React.createRef();
    }

  drawChart(data: number[]) {
    /* ...Draw the chart with D3... */
      const svg = select(this.svgRef.current);
      svg.append("circle").attr("cx",50)
          .append("div")
        .html("First!");
      console.log("HI");


  }

    componentDidMount() {

      console.log(this.svg);
        var data = [4, 8, 15, 16, 23, 42];
        this.drawChart(data);
    }

  render() {
    const { width, height } = this.props;
    return (
      <circle width={width} height={height} ref={this.svg} />
    );
  }
}

export default Epicurve;
