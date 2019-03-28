import React, { Component } from "react";
import { render } from 'react-dom'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import * as actions from '../actions/analysisactions';

class EpicurvebyweekGrid2 extends Component {

  constructor(props) {
    super(props);
  }

  //TODO Implement component and diagrams
  render() {
    var options = Object.assign({}, this.props.options, {title: {text: "Male Five Or Above"}})
    return (
      <HighchartsReact
        highcharts={Highcharts}
        options={ options }
      />
    );
  }

  componentDidMount() {
    this.props.fetchPostsWithRedux("Week", ["MaleFiveOrAbove"], "WeekGrid2")
  }
}



function mapStateToProps(state){
  return {
  	options: state.epicurvebyweekGrid2
  }
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(EpicurvebyweekGrid2);