import React, {Component} from 'react';
import * as d3 from 'd3';

let x = d3.scaleTime();
let y = d3.scaleLinear();
let lineValue = d3.line();
let lineVertical = d3.line();

class BarChart extends Component {
  constructor(props) {
    super(props);
    
    this.GetVerticalLineData = this.GetVerticalLineData.bind(this);
    this.FetchData = this.FetchData.bind(this);
    this.GraphInitialize = this.GraphInitialize.bind(this);
    this.GraphUpdate = this.GraphUpdate.bind(this);
    
    console.log("OK");
    
    this.state = {
      timeNow : new Date(),
      timer: null,
    };
    this.chartRef = React.createRef ();
  }
  
  GetVerticalLineData(){
    return([{xval: this.state.timeNow, yval:5.5},
            {xval: this.state.timeNow, yval:6.0}]);
  }
  
  FetchData(fn){
    var that = this;
    fetch(this.props.dataurl).
    then((response) => {
         return response.json()
         }).then((data) => {
                 console.log(data); // [{"Hello": "world"}, …]
                 
                 var parseTime = d3.timeParse("%Y-%m-%d %H:%M:%S");
                 var dataClean = data.map(function(d){ return(
                                                              {time: parseTime(d.time),
                                                              value: d.value
                                                              }
                                                              )}).slice(that.props.datapoints)
                 console.log(dataClean); // [{"Hello": "world"}, …]
                 
                 that.setState({
                               timeNow: new Date(),
                               data: dataClean
                               },() => {
                               fn();
                               });
                 });
  }
  
  GraphInitialize(){
    
    var fullData = this.state.data.concat(
                                          {time: this.state.timeNow,
                                          value: 5.75});
    //console.log(fullData);
    
    var margin = {top: 20, right: 50, bottom: 30, left: 50};
    const width = this.props.width - margin.left - margin.right;
    const height = this.props.height - margin.top - margin.bottom;
    
    //var x = d3.scaleTime()
    x.range([0, width])
    .domain(d3.extent(fullData.map(function(d){
                                   return(d.time)
                                   })));
    
    //var y = d3.scaleLinear()
    var yDom = d3.extent(fullData.map(function(d){
                                     return(d.value)
                                      }));
    yDom[0]=yDom[0]-0.25;
    yDom[1]=yDom[1]+0.25;
    y.range([height, 0])
    .domain(yDom);
    
    const svg = d3.select(this.chartRef.current);
    svg.attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom);
    var graph = svg.append("g")
    .attr("transform", "translate(" + margin.left + "," + margin.top + ")")
    .attr("data-name","graph");
    
    // add the x Axis
    graph.append("g")
    .attr("class","x axis")
    .attr("transform", "translate(0," + height + ")")
    .call(d3.axisBottom(x));
    
    // add the y Axis
    graph.append("g")
    .attr("class","y axis left")
    .attr("transform", "translate(0, 0)")
    .call(d3.axisLeft(y).ticks(5));
    
    graph.append("g")
    .attr("class","y axis right")
    .attr("transform", "translate(" + width + ",0)")
    .call(d3.axisRight(y).ticks(5));
    
    lineValue
    .x(function(d) { return x(d.time);})
    .y(function(d) {return y(d.value);});
    
    lineVertical
    .x(function(d) { console.log(d); return x(d.xval);})
    .y(function(d) {return y(d.yval);});
    
    /*
    graph.append("path")
    .data([this.state.data])
    .attr("class", "line")
    .attr("data-name", "lineValue")
    .attr("d", lineValue);
    */
    graph.selectAll("circle")
    .data(this.state.data)
    .enter()
    .append("circle")
    .attr("r", 1)
    .attr("cx", function(d) { return x(d.time); })
    .attr("cy", function(d) { return y(d.value); });
    
    graph.append("path")
    .data([this.GetVerticalLineData()])
    .attr("class", "line")
    .attr("data-name", "lineVertical")
    .attr("d", lineVertical);
    
    
    
   /* graph.append("path")
    .data(this.GetVerticalLineData())
    .attr("class", "line")
    .attr("d", lineVertical)
    .style("stroke-width", 2)
    .style("stroke", "red")
    .style("fill", "none");*/
    
  }
  
  GraphUpdate(){
    console.log("UPDATING")
    var date1 = new Date();
    date1.setMinutes(date1.getMinutes()+5);
    var fullData = this.state.data.concat(
                                          {time: this.state.timeNow,
                                          value: 5.75});
    //fullData = this.state.data.concat(date1);
    
    x.domain(d3.extent(fullData.map(function(d){
                                   return(d.time)
                                   })));
    
    var yDom = d3.extent(fullData.map(function(d){
                                      return(d.value)
                                      }));
    yDom[0]=yDom[0]-0.25;
    yDom[1]=yDom[1]+0.25;
    console.log(yDom);
    y.domain(yDom);
    
    const svg = d3.select(this.chartRef.current);
    /*
    svg.select("[data-name=lineValue]")
    .transition()
    .duration(750)
    .attr("d", lineValue(fullData));
    */
    svg.select("[data-name=lineVertical]")
    .transition()
    .duration(750)
    .attr("d", lineVertical(this.GetVerticalLineData()));
    
    var u = svg.select("[data-name=graph]").selectAll("circle")
    .data(this.state.data, function(d){
          return d;
          });
    
    u.enter()
    .append("circle")
    .attr("r", 1)
    .attr("cx", function(d) { return x(d.time); })
    .attr("cy", function(d) { return y(d.value); })
    .merge(u)
    .transition()
    .duration(750)
    .attr("r", 1)
    .attr("cx", function(d) { return x(d.time); })
    .attr("cy", function(d) { return y(d.value); });
    
    u.exit().remove();
    
    svg.select(".x.axis")
    .transition()
    .duration(750)
    .call(d3.axisBottom(x));
    
    svg.select(".y.axis.left")
    .transition()
    .duration(750)
    .call(d3.axisLeft(y));
    
    svg.select(".y.axis.right")
    .transition()
    .duration(750)
    .call(d3.axisRight(y));
    
  }
  
  componentDidMount () {
    var that = this;
    that.FetchData(that.GraphInitialize);
    
    console.log("0");
    let timer = setInterval(function() { that.FetchData(that.GraphUpdate); }, 5000);
    this.setState({timer});
    console.log("1");
    
  }
  
  componentDidUpdate () {
    //this.Graph();
  }
  
  componentWillUnmount() {
    this.clearInterval(this.state.timer);
  }
  
  render () {
    
    return <svg width={this.props.width} height={this.props.height} ref={this.chartRef}  />;
  }
}

export default BarChart;
