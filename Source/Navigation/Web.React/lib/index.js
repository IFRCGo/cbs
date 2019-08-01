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
    this.setState(prevState => ({
      showAnalyticsDropdown: !prevState.showAnalyticsDropdown
    }));
  }

  onMenuClick() {
    this.setState(prevState => ({
      collapseMenu: !prevState.collapseMenu
    }));
  }

  componentDidMount() {
    if (this.props.username !== undefined) {
      this.setState({
        username: this.props.username
      });
    }
  }

  rcLogo() {
    return React.createElement("div", {
      className: `rc-logo`
    }, React.createElement("figure", null, React.createElement("svg", {
      xmlns: "http://www.w3.org/2000/svg",
      width: "70",
      height: "40",
      viewBox: "0 0 175 100"
    }, React.createElement("rect", {
      className: "mainColorFill",
      width: "175",
      height: "100"
    }), React.createElement("path", {
      className: "backgroundColorStroke",
      d: "M20,50h66m-33,-33v66",
      fill: "none",
      strokeWidth: "20"
    }), React.createElement("circle", {
      className: "backgroundColorFill",
      cx: "132",
      cy: "50",
      r: "34"
    }), React.createElement("circle", {
      className: "mainColorFill",
      cx: "142",
      cy: "50",
      r: "28"
    }), React.createElement("path", {
      className: "backgroundColorStroke",
      d: "M7,7H168V93H7z",
      fill: "none",
      strokeWidth: "3"
    }))), React.createElement("div", {
      className: "logo-text"
    }, "CBS"));
  }

  analyticsDropdown() {
    return React.createElement("div", null, React.createElement("div", {
      className: "dropdown-content"
    }, React.createElement("a", {
      href: "/analytics/light",
      className: "dropdown-item"
    }, React.createElement("div", {
      className: "d-i-text"
    }, "Light area overview"))));
  }

  createMenuItem(url, text, hasDropdown) {
    var active = this.props.activeMenuItem;

    if (hasDropdown) {
      return React.createElement("a", {
        onClick: this.onClick,
        href: `/${url}/`,
        className: `menu-item ${url == active ? `active` : ``}`
      }, text, " ", React.createElement("i", {
        className: `fa ${this.state.showAnalyticsDropdown ? `fa-chevron-up` : `fa-chevron-down`}`
      }));
    }

    return React.createElement("a", {
      href: `/${url}/`,
      className: `menu-item ${url == active ? `active` : ``}`
    }, text);
  }

  render() {
    return React.createElement("header", {
      className: `header ${this.state.collapseMenu ? `hidden` : ``}`
    }, this.rcLogo(), React.createElement("div", {
      onClick: this.onMenuClick,
      className: "menu-toggler"
    }, React.createElement("i", {
      className: `fa ${this.state.collapseMenu ? `fa-bars` : `fa-times`}`
    })), React.createElement("div", {
      className: "menu-wrapper"
    }, React.createElement("nav", {
      className: "header-menu"
    }, this.createMenuItem("analytics", "Country Overview"), React.createElement("div", {
      className: `menu-dropdown ${this.state.showAnalyticsDropdown ? `active` : ``}`
    }, this.createMenuItem("analytics/#", `Analytics`, true), this.state.showAnalyticsDropdown && this.analyticsDropdown()), this.createMenuItem("admin", "Project Administration"), this.createMenuItem("reporting/datacollectors", "Data Collectors"), this.createMenuItem("reporting/case-reports", "Reports")), React.createElement("div", {
      className: "login-status"
    }, React.createElement("span", null, React.createElement("i", {
      className: "fa fa-user"
    }), " ", this.state.username), React.createElement("a", {
      className: "logout",
      href: "#"
    }, React.createElement("i", {
      className: "fa fa-sign-out"
    }), " Log out"))));
  }

}

export default CBSNavigation;

