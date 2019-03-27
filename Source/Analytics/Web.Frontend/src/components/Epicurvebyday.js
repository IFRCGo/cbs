import React, { Component } from "react";
import { render } from 'react-dom'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import * as actions from '../actions/analysisactions';



class Epicurvebyday extends Component {

  constructor(props) {
    super(props);
  }

  //TODO Implement component and diagrams
  render() {
    console.log(this.props)
    return (
      <HighchartsReact
        highcharts={Highcharts}
        options={ this.props.options }
      />
    );
  }

  componentDidMount() {
    this.props.fetchPostsWithRedux("Day", ["Total"], "Day")
  }
}



function mapStateToProps(state){
  return {
  	options: state.epicurveByDay
  }
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(Epicurvebyday);