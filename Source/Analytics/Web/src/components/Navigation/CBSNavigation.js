import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Grid from '@material-ui/core/Grid';
import './cbs-navigation.scss';

const BASE_URL = process.env.API_BASE_URL;

class CBSNavigation extends Component {

    constructor(props) {
        super(props);
        this.onClick = this.onClick.bind(this);
        this.onMenuClick = this.onMenuClick.bind(this);

        this.state = {
            username: "Unknown",
            showAnalyticsDropdown: false,
            collapseMenu: true
        };
    }

    onClick(event) {
        event.preventDefault();
        this.setState(prevState => ({ showAnalyticsDropdown: !prevState.showAnalyticsDropdown }));
    }

    onMenuClick() {
        this.setState(prevState => ({ collapseMenu: !prevState.collapseMenu }));
    }

    fetchData() {
        if (process.env.environment !== 'production') {
            this.url = `http://www.mocky.io/v2/5cdc46d52d00003b12f5a6da`;
            fetch(this.url, { method: "GET" }).then(response => response.json())
                .then(json =>
                    this.setState({
                        username: json.name
                    })
                )
                .catch(_ =>
                    this.setState({
                        isLoading: false,
                        isError: true
                    })
                );
        }
        else {
            this.url = `${BASE_URL}/identity`;
            fetch(this.url, { method: "GET" }).then(response => response.text())
                .then(text =>
                    this.setState({
                        username: text
                    })
                )
                .catch(_ =>
                    this.setState({
                        isLoading: false,
                        isError: true
                    })
                );

        }
        this.setState({ isLoading: true });
    }

    componentDidMount() {
        this.fetchData();
    }

    rcLogo() {
        return (
            <div className={`rc-logo`}>
                <figure>
                    <svg xmlns="http://www.w3.org/2000/svg" width="70" height="40" viewBox="0 0 175 100">
                        <rect className="mainColorFill" width="175" height="100" />
                        <path className="backgroundColorStroke" d="M20,50h66m-33,-33v66" fill="none" strokeWidth="20" />
                        <circle className="backgroundColorFill" cx="132" cy="50" r="34" />
                        <circle className="mainColorFill" cx="142" cy="50" r="28" />
                        <path className="backgroundColorStroke" d="M7,7H168V93H7z" fill="none" strokeWidth="3" />
                    </svg>
                </figure>
                <div className="logo-text">
                    CBS
                </div>
            </div>
        )
    }

    analyticsDropdown() {
        return (
            <div>
                <div className="dropdown-content">
                    <Link to="/analytics/light" className="dropdown-item"><div className="d-i-text">Light area overview</div></Link>
                </div>
            </div>
        )
    }

    createMenuItem(url, text, hasDropdown) {
        var active = this.props.activeMenuItem;

        if (hasDropdown) {
            return <Link
                onClick={this.onClick}
                to={`/${url}/`}
                className={`menu-item ${url == active ? `active` : ``}`}>
                {text} <i className={`fa ${this.state.showAnalyticsDropdown ? `fa-chevron-up` : `fa-chevron-down`}`} />
            </Link>
        }

        return <Link to={`/${url}/`} className={`menu-item ${url == active ? `active` : ``}`}>
            {text}
        </Link>
    }

    render() {
        return (
            <Grid container spacing={0} justify="center" className="header-container">
                <Grid item xs={12} sm={10}>
                    <header className={`header ${this.state.collapseMenu ? `hidden` : ``}`}>
                        {this.rcLogo()}
                        <div onClick={this.onMenuClick} className="menu-toggler">
                            <i className={`fa ${this.state.collapseMenu ? `fa-bars` : `fa-times`}`} />
                        </div>
                        <div className="menu-wrapper">
                            <nav className="header-menu">
                                {this.createMenuItem("analytics", "Country Overview")}

                                <div className={`menu-dropdown ${this.state.showAnalyticsDropdown ? `active` : ``}`}>
                                    {this.createMenuItem("analytics/#", `Analytics`, true)}
                                    {this.state.showAnalyticsDropdown && this.analyticsDropdown()}
                                </div>

                                {this.createMenuItem("admin", "Project Administration")}
                                {this.createMenuItem("reporting/datacollectors", "Data Collectors")}
                                {this.createMenuItem("reporting/case-reports", "Reports")}
                            </nav>
                            <div className="login-status">
                                <span><i className="fa fa-user" /> {this.state.username}</span>
                                <a className="logout" href="#"><i className='fa fa-sign-out' /> Log out</a>
                            </div>
                        </div>
                    </header>
                </Grid>
            </Grid>
        );
    }
}
export default CBSNavigation;