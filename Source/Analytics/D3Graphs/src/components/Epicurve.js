
import React, {Component} from 'react';
import * as d3 from 'd3';
import data from '../assets/data/epicurve_by_week.json';

class BarChart extends Component {
  constructor(props) {
    super(props);
    this.Graph = this.Graph.bind(this);
    
    console.log("OK");
    this.state = {
      
    };
    this.chartRef = React.createRef ();
  }

  Graph(){
    console.log(this.props.width);
    
    var margin = {top: 20, right: 20, bottom: 30, left: 50};
    const width = this.props.width - margin.left - margin.right;
    const height = this.props.height - margin.top - margin.bottom;

    var x = d3.scaleBand()
          .range([0, width])
          .padding(0.1)
          .domain(data.map(function(d) { return d.YearWeek; }));

    var y = d3.scaleLinear()
          .range([height, 0])
          .domain([0, d3.max(data, function(d) { return d.n; })]);

    const svg = d3.select(this.chartRef.current);
    svg.attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom);
    var graph = svg.append("g")
    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    graph.selectAll(".bar")
      .data(data)
      .enter().append("rect")
        .attr("class", "bar")
        .attr("x", function(d) { return x(d.YearWeek); })
        .attr("width", x.bandwidth())
        .attr("y", function(d) { return y(d.n); })
        .attr("height", function(d) { return height - y(d.n); });

    // add the x Axis
    graph.append("g")
      .attr("transform", "translate(0," + height + ")")
      .call(d3.axisBottom(x));

    // add the y Axis
    graph.append("g")
      .call(d3.axisLeft(y).ticks(3));

/*
    const chart = d3.select (this.chartRef.current);
    const barWidth = 20;
    const chartHeight = 200;
    const yScale = d3
      .scaleLinear()
      .range ([0, d3.max (dataVals)])
      .domain ([0, chartHeight]);
    const bar = chart
      .selectAll ('g')
      .data (dataVals)
      .enter ()
      .append ('g')
      .attr ('transform', (value, i) => `translate(0,${i * barWidth})`);
    bar
      .append ('rect')
      .attr ('height', value => yScale (value))
      .attr ('width', barWidth - 1)
      .attr ('style', 'fill: steelblue;');
    bar
      .append ('text')
      .attr ('y', value => yScale (value) - 5)
      .attr ('x', barWidth / 2)
      .attr ('dy', '.35em')
      .attr ('style', 'fill: white; font: 14px sans-serif; text-anchor: end;')
      .text (value => value);
      */
  }
  
  componentDidMount () {
    console.log("1");
    this.Graph();
  }

  componentDidUpdate () {
    this.Graph();
  }

  render () {
    
    return <svg width={this.props.width} height={this.props.height} ref={this.chartRef}  />;
  }
}

export default BarChart;
