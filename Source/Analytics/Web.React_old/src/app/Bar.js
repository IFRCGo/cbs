
import React, {Component} from 'react';
import * as d3 from 'd3';

class BarChart extends Component {
  chartRef = React.createRef ();

  componentDidMount () {
    console.log(this.props.width);
    if(length(this.props.data)==0){
      return;
    }

    var dataVals = this.props.data.map(function(d) {
      return d.n
    });

    const chart = d3.select (this.chartRef.current);
    const barHeight = 20;
    const chartWidth = 200;
    const xScale = d3
      .scaleLinear()
      .domain ([0, d3.max (dataVals)])
      .range ([0, chartWidth]);
    const bar = chart
      .selectAll ('g')
      .data (dataVals)
      .enter ()
      .append ('g')
      .attr ('transform', (value, i) => `translate(0,${i * barHeight})`);
    bar
      .append ('rect')
      .attr ('width', value => xScale (value))
      .attr ('height', barHeight - 1)
      .attr ('style', 'fill: steelblue;');
    bar
      .append ('text')
      .attr ('x', value => xScale (value) - 5)
      .attr ('y', barHeight / 2)
      .attr ('dy', '.35em')
      .attr ('style', 'fill: white; font: 14px sans-serif; text-anchor: end;')
      .text (value => value);
  }

  render () {
    return <svg ref={this.chartRef} />;
  }
}

export default BarChart;
