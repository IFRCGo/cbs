import React, { Component } from 'react';

//const BASE_URL = process.env.API_BASE_URL;


class CBSNavigation extends Component {
  constructor(props) {
    super(props);
    this.onMouseOver = this.onMouseOver.bind(this);
    this.onMouseLeave = this.onMouseLeave.bind(this);
    this.state = {
      username: "Unknown",
      showAnalyticsDropdown: false
    };
  }

  onMouseOver() {
    this.setState({
      showAnalyticsDropdown: true
    });
  }

  onMouseLeave() {
    this.setState({
      showAnalyticsDropdown: false
    });
  }

  componentWillMount(){

    }

  componentDidMount() {

  }

  rcLogo(color) {
    var backgroundColor = color == "red" ? "#c00" : "#fff";
    var mainColor = color == "red" ? "#fff" : "#c00";
    return React.createElement("figure", {
      className: `logo logo-${color}`
    }, React.createElement("svg", {
      xmlns: "http://www.w3.org/2000/svg",
      width: "70",
      height: "40",
      viewBox: "0 0 175 100"
    }, React.createElement("rect", {
      width: "175",
      height: "100",
      fill: mainColor
    }), React.createElement("path", {
      d: "M20,50h66m-33,-33v66",
      fill: "none",
      stroke: backgroundColor,
      strokeWidth: "20"
    }), React.createElement("circle", {
      cx: "132",
      cy: "50",
      r: "34",
      fill: backgroundColor
    }), React.createElement("circle", {
      cx: "142",
      cy: "50",
      r: "28",
      fill: mainColor
    }), React.createElement("path", {
      d: "M7,7H168V93H7z",
      fill: "none",
      stroke: backgroundColor,
      strokeWidth: "3"
    })));
  }

  analyticsDropdown() {
    return React.createElement("div", null, React.createElement("div", {
      className: "dropdown-content"
    }, React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, "Health risks"), React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, "Regions"), React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, "Light area overview"), React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, "Volunteer performance")));
  }

  render() {
    return React.createElement("header", {
      className: "navigation-header"
    }, this.rcLogo("white"), this.rcLogo("red"), React.createElement("nav", null, React.createElement("a", {
      href: "/analytics/"
    }, "Country Overview"), React.createElement("div", {
      className: "dropdown",
      onMouseOver: this.onMouseOver,
      onMouseLeave: this.onMouseLeave
    }, React.createElement("a", {
      href: "/analytics/"
    }, "Analytics ", React.createElement("i", {
      className: "fa fa-caret-down"
    })), this.state.showAnalyticsDropdown && this.analyticsDropdown()), React.createElement("a", {
      href: "/admin/"
    }, "Project Administration"), React.createElement("a", {
      href: "/reporting/datacollectors/"
    }, "Data Collectors"), React.createElement("a", {
      href: "/reporting/case-reports/"
    }, "Reports")), React.createElement("div", {
      className: "login-status"
    }, React.createElement("div", {
      className: "logged-in"
    }, React.createElement("p", null, "Logged in as:"), React.createElement("p", null, this.state.username), React.createElement("button", null, "Logout"))));
  }

}

export default CBSNavigation;