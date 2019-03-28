import React, { Component } from "react";
import { render } from 'react-dom'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as actions from '../actions/analysisactions';



class AnalyticsBanner extends Component {

    constructor(props) {
        super(props);
    }

    //TODO Implement component and diagrams
    render() {
        return (

            <div className="bs-example" data-example-id="thumbnails-with-custom-content">
                <h3>Overview (last 7 days)</h3>
                <div className="row">
                    <div className="col-sm-6 col-md-4">
                        <div className="thumbnail">
                            <i className="fa fa-heartbeat fa-5x" style={{ padding: '20px', display: 'block', backgroundColor: '#eee', textAlign: 'center' }}></i>
                            <div className="caption" style={{ height: '200px' }}>
                                <h2 style={{ color: '#9f0000', textAlign: 'center' }}>72 Reports</h2>
                                <ul>
                                    <li>43 Ebola</li>
                                    <li>12 Colera</li>
                                    <li>2 Dan's food poisoning</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-6 col-md-4">
                        <div className="thumbnail">
                            <i className="fa fa-user fa-5x" style={{ padding: '20px', display: 'block', backgroundColor: '#eee', textAlign: 'center' }}></i>
                            <div className="caption" style={{ height: '200px' }}>
                                <h2 style={{ color: '#009f00', textAlign: 'center' }}>123 Active Data Collectors</h2>
                                <ul>
                                    <li>13 Inactive</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-6 col-md-4">
                        <div className="thumbnail">
                            <i className="fa fa-exclamation-triangle fa-5x" style={{ padding: '20px', display: 'block', backgroundColor: '#eee', textAlign: 'center' }}></i>
                            <div className="caption" style={{ height: '200px' }}>
                                <h2 style={{ color: '#9f0000', textAlign: 'center' }}>6 Alerts</h2>
                                <ul>
                                    <li>2 Ebola</li>
                                    <li>4 Colera</li>
                                    <li>1 Dan's food poisoning</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    componentDidMount() {
        this.props.fetchPostsWithRedux("Day", ["Total"], "Day")
    }
}



function mapStateToProps(state) {
    return {
        options: state.epicurveByDay
    }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(AnalyticsBanner);