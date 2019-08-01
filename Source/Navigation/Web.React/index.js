import React, { Component } from 'react';
import './cbs-navigation.scss';

class CBSNavigation extends Component {

    constructor(props) {
        super(props);
        this.onClick = this.onClick.bind(this);
        this.onMenuClick = this.onMenuClick.bind(this);

        this.state = {
            username: "Unknown",
            showAnalyticsDropdown: false,
            collapseMenu: false
        };
    }

    onClick(event) {
        event.preventDefault();
        this.setState(prevState => ({ showAnalyticsDropdown: !prevState.showAnalyticsDropdown }));
    }

    onMenuClick() {
        this.setState(prevState => ({ collapseMenu: !prevState.collapseMenu }));
    }

    componentDidMount() {
        if (this.props.username !== undefined){
            this.setState({username: this.props.username});
        }
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
                    <a href="/analytics/light" className="dropdown-item"><div className="d-i-text">Light area overview</div></a>
                </div>
            </div>
        )
    }

    createMenuItem(url, text, hasDropdown) {
        const arr = window.location.pathname.split('/');
        var active = arr[1];
        if (active == 'reporting'){ //Reporting has more tabs within one bounded context, so we look at the next step
            active += '/' + arr[2];
        } else if (active == 'analytics' && arr[2] != ""){
            active += '/' + arr[2]; //For analytics/light
        }

        if (hasDropdown) {
            return <a
                onClick={this.onClick}
                href={`/${url}/`}
                className={`menu-item ${url == active ? `active` : ``}`}>
                {text} <i className={`fa ${this.state.showAnalyticsDropdown ? `fa-chevron-up` : `fa-chevron-down`}`} />
            </a>
        }

        return <a href={`/${url}/`} className={`menu-item ${url == active ? `active` : ``}`}>
            {text}
        </a>
    }

    render() {
        return (
            <header className={`header ${this.state.collapseMenu ? `collapsed` : ``}`}>
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
        );
    }
}
export default CBSNavigation;