import React, { Component } from "react";
import { render } from 'react-dom'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as actions from '../actions/kpiactions';

const ReportedHealthRisks = ({ list }) => (
    <>
        {list.map((data, index) => (
            <li key={index}>{data.numberOfReports} {data.name}</li>
        ))}
    </>
);

class AnalyticsBanner extends Component {

    constructor(props) {
        super(props);
    }

    //TODO Implement component and diagrams
    render() {
        let test = this.props.kpi.payload || {
            caseReports:
            {
                totalNumberOfReports: 0,
                reportedHealthRisks: []
            }
        }
        console.log(test);
        return (

            <div className="bs-example" data-example-id="thumbnails-with-custom-content">
                <h3>Overview (last 7 days)</h3>
                <div className="row">
                    <div className="col-sm-6 col-md-4">
                        <div className="thumbnail">
                            <i className="fa fa-heartbeat fa-5x" style={{ padding: '20px', display: 'block', backgroundColor: '#eee', textAlign: 'center' }}></i>
                            <div className="caption" style={{ height: '200px' }}>
                                <h2 style={{ color: '#9f0000', textAlign: 'center' }}>{test.caseReports.totalNumberOfReports} Reports</h2>
                                <ul>
                                    <ReportedHealthRisks list={test.caseReports.reportedHealthRisks} />
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-6 col-md-4">
                        <div className="thumbnail">
                            <i className="fa fa-user fa-5x" style={{ padding: '20px', display: 'block', backgroundColor: '#eee', textAlign: 'center' }}></i>
                            <div className="caption" style={{ height: '200px' }}>
                                <h2 style={{ color: '#009f00', textAlign: 'center' }}>45 Active Data Collectors</h2>
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
                                <h2 style={{ color: '#9f0000', textAlign: 'center' }}>3 Alerts</h2>
                                <ul>
                                    <li>7 Measels</li>
                                    <li>14 Cholera</li>
                                    <li>6 Acute Watery Diarrhea</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    componentDidMount() {
        this.props.fetchPostsWithRedux()
    }
}



function mapStateToProps(state) {
    return {
        kpi: state.kpi
    }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(AnalyticsBanner);