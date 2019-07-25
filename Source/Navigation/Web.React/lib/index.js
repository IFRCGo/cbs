import React, { Component } from 'react';
import './cbs-navigation-v1.scss';

class CBSNavigation extends Component {
  constructor(props) {
    super(props);
    this.onClick = this.onClick.bind(this);
    this.onMouseLeave = this.onMouseLeave.bind(this);
    this.state = {
      username: "Unknown",
      showAnalyticsDropdown: false
    };
  }

  onClick() {
    this.setState(prevState => ({
      showAnalyticsDropdown: !prevState.showAnalyticsDropdown
    }));
  }

  onMouseLeave() {
    this.setState({
      showAnalyticsDropdown: false
    });
  }

  fetchData() {
    if (process.env.environment !== 'production') {
      this.url = `http://www.mocky.io/v2/5cdc46d52d00003b12f5a6da`;
      fetch(this.url, {
        method: "GET"
      }).then(response => response.json()).then(json => this.setState({
        username: json.name
      })).catch(_ => this.setState({
        isLoading: false,
        isError: true
      }));
    } else {
      this.url = `${BASE_URL}/identity`;
      fetch(this.url, {
        method: "GET"
      }).then(response => response.text()).then(text => this.setState({
        username: text
      })).catch(_ => this.setState({
        isLoading: false,
        isError: true
      }));
    }

    this.setState({
      isLoading: true
    });
  }

  componentDidMount() {
  }

  rcLogo(color) {
    var backgroundColor = color == "red" ? "#c00" : "#fff";
    var mainColor = color == "red" ? "#fff" : "#c00";
    return React.createElement("div", {
      className: `logo logo-${color}`
    }, React.createElement("figure", null, React.createElement("svg", {
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
    }))), React.createElement("div", {
      className: "logo-text"
    }, "CBS"));
  }

  analyticsDropdown() {
    return React.createElement("div", null, React.createElement("div", {
      className: "dropdown-content"
    }, React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, React.createElement("div", {
      className: "d-i-text"
    }, "Health risks")), React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, React.createElement("div", {
      className: "d-i-text"
    }, "Regions")), React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, React.createElement("div", {
      className: "d-i-text"
    }, "Light area overview")), React.createElement("a", {
      href: "/analytics/",
      className: "dropdown-item"
    }, React.createElement("div", {
      className: "d-i-text"
    }, "Volunteer performance"))));
  }

  createMenuItem(url, text) {
    var active = this.props.activeMenuItem == url;
    var url = url ? "/" + url + "/" : "javascript:void(0)"; //Do nothing if no url is provided

    return React.createElement("a", {
      href: url,
      className: `menu-item ${active ? `active` : ``}`
    }, text, " ", text=="Analytics" && React.createElement("i", {
      className: `fa ${this.state.showAnalyticsDropdown ? `fa-chevron-up` : `fa-chevron-down`}`
    }));
  }

  render() {
    return React.createElement("header", {
      className: "navigation-header"
    }, this.rcLogo("white"), this.rcLogo("red"), React.createElement("nav", null, this.createMenuItem("analytics", "Country Overview"), React.createElement("div", {
      className: "dropdown",
      onClick: this.onClick,
      onMouseLeave: this.onMouseLeave
    }, this.createMenuItem(null, `Analytics`), this.state.showAnalyticsDropdown && this.analyticsDropdown()), this.createMenuItem("admin", "Project Administration"), this.createMenuItem("reporting/datacollectors", "Data Collectors"), this.createMenuItem("reporting/case-reports", "Reports")), React.createElement("div", {
      className: "login-status"
    }, React.createElement("div", {
      className: "logged-in"
    }, React.createElement("p", null, "Logged in as: ", this.state.username), React.createElement("a", {
      className: "logout",
      href: "#"
    }, React.createElement("i", {
      className: "fa fa-sign-out"
    }), " Log out"))));
  }

}
export default CBSNavigation;