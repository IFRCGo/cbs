import React, {Component} from 'react';
import moment from 'moment';
import Controller from '../controller.js';
import {CaseReportForListing} from "../../../Web.Angular/src/app/shared/models/case-report-for-listing.model";
import Epicurve from './Epicurve.js';
import data from '../assets/data/epicurve.json';


const Success = 'Success';
const TextMessageParsingError = 'TextMessageParsingError';
const UnknownDataCollector = 'UnknownDataCollector';
const TextMessageParsingErrorAndUnknownDataCollector = 'TextMessageParsingErrorAndUnknownDataCollector';

const stringCompare = (a, b) => {
  if (a < b) {
    return -1;
  }

  if (a > b) {
    return 1;
  }

  return 0;
};

const hasHealthRisk = c => {
  return c.healthRiskId !== null;
};

const CaseReportColumns = {
  date: ['Date', (a, b) => a.timestamp.valueOf() - b.timestamp.valueOf(), c => true],
  time: 'Time',
  status: ['Status', (a, b) => Number(!!a.healthRiskId) - Number(!!b.healthRiskId), c => true],
  dataCollector: ['Data Collector', (a, b) => stringCompare(a.dataCollectorDisplayName, b.dataCollectorDisplayName), hasHealthRisk],
  region: ['Region', (a, b) => stringCompare(a.dataCollectorRegion, b.dataCollectorRegion), hasHealthRisk],
  district: ['District', (a, b) => stringCompare(a.dataCollectorDistrict, b.dataCollectorDistrict), hasHealthRisk],
  village: ['Village', (a, b) => stringCompare(a.dataCollectorVillage, b.dataCollectorVillage), hasHealthRisk],
  healthRisk: ['Health Risk', (a, b) => stringCompare(a.healthRisk, b.healthRisk), hasHealthRisk],
  malesAges0To4: ['Males < 5', (a, b) => a.numberOfMalesUnder5 - b.numberOfMalesUnder5, hasHealthRisk],
  malesAgedOver4: ['Males ≥ 5', (a, b) => a.numberOfMalesAged5AndOlder - b.numberOfMalesAged5AndOlder, hasHealthRisk],
  femalesAges0To4: ['Females < 5', (a, b) => a.numberOfFemalesUnder5 - b.numberOfFemalesUnder5, hasHealthRisk],
  femalesAgesOver4: ['Females ≥ 5', (a, b) => a.numberOfFemalesAged5AndOlder - b.numberOfFemalesAged5AndOlder, hasHealthRisk]
};

const CaseReportStatus = {
  Success,
  TextMessageParsingError,
  UnknownDataCollector,
  TextMessageParsingErrorAndUnknownDataCollector
};

class Analytics extends Component {

  static get Filters () {
    return {
      all: 'All',

      success: ['Success', report => {
        return report.status === CaseReportStatus.Success
          || report.status === CaseReportStatus.UnknownDataCollector;
      }],

      error: ['Data error', report => {
        return report.status === CaseReportStatus.TextMessageParsingError
          || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
      }],

      unknownSender: ['Unknown sender', report => {
        return report.status === CaseReportStatus.UnknownDataCollector
          || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
      }]
    }
  }

  constructor(props) {
    super(props);
    
    this.state = {
      data : null
    };
  }


  componentDidMount() {
    //this.props.fetchAllCaseReports();

/*
    var that = this;
    json("data/epicurve.json").then(function(data) {
      //console.log(data); // [{"Hello": "world"}, …]
      that.setState({
        data: data
      });
    });
*/
  }

  componentDidUpdate(prevProps) {

  }

  clickFilter() {

  }

  openExporter() {

  }

  formatDate(dateString) {
    return moment(dateString).format('DD.MM.YYYY');
  }

  formateTime(dateString) {
    return moment(dateString).format('HH:mm');
  }

  isSuccessStatus(status) {
    return status === 0 || status === 2;
  }

  isOriginStatus(status) {
    return status === 2 || status === 3;
  }

  render() {
    const userName = 'DEV';
    const {caseReports} = this.props;
    const isLoggedIn = false;
    const currentFilter = 'all';
    const currentSortColumn = '';
    const sortDescending = '';

    return <div>
      <header className="navigation-header">
        <figure className="logo">
          <svg xmlns="http://www.w3.org/2000/svg" width="700" height="400" viewBox="0 0 175 100">
            <rect width="175" height="100" fill="#fff" />
            <path d="M20,50h66m-33,-33v66" fill="none" stroke="#c00" strokeWidth="20" />
            <circle cx="132" cy="50" r="34" fill="#c00" />
            <circle cx="142" cy="50" r="28" fill="#fff" />
            <path d="M7,7H168V93H7z" fill="none" stroke="#c00" strokeWidth="3" />
          </svg>
        </figure>

        <nav>
          <a href="/">Project administration</a>
          <a href="/users">User management</a>
          <a href="/reporting">Volunteer reporting</a>
        </nav>

        <div className="login-status">
          <div className="logged-in">
            <p>
              Logged in as:
            </p>
            <p>{userName}</p>
          </div>
        </div>
      </header>

      <div className="container">
        <h3>
            Analytics
        </h3>

         <Epicurve width={750} height={500} data={data}/>

      </div>
    </div>;
  }
}

export default new Controller(Analytics);
