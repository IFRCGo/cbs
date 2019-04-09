"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _react = _interopRequireDefault(require("react"));

var _reactRouterDom = require("react-router-dom");

var _default = function _default() {
  return _react.default.createElement("header", {
    className: "navigation-header"
  }, _react.default.createElement("figure", {
    className: "logo"
  }, _react.default.createElement("svg", {
    xmlns: "http://www.w3.org/2000/svg",
    width: "700",
    height: "400",
    viewBox: "0 0 175 100"
  }, _react.default.createElement("rect", {
    width: "175",
    height: "100",
    fill: "#fff"
  }), _react.default.createElement("path", {
    d: "M20,50h66m-33,-33v66",
    fill: "none",
    stroke: "#c00",
    strokeWidth: "20"
  }), _react.default.createElement("circle", {
    cx: "132",
    cy: "50",
    r: "34",
    fill: "#c00"
  }), _react.default.createElement("circle", {
    cx: "142",
    cy: "50",
    r: "28",
    fill: "#fff"
  }), _react.default.createElement("path", {
    d: "M7,7H168V93H7z",
    fill: "none",
    stroke: "#c00",
    strokeWidth: "3"
  }))), _react.default.createElement("nav", null, _react.default.createElement(_reactRouterDom.Link, {
    to: "/projects"
  }, "Project administration"), _react.default.createElement(_reactRouterDom.Link, {
    to: "/users"
  }, "User management"), _react.default.createElement(_reactRouterDom.Link, {
    to: "/reporting/all"
  }, "Reporting"), _react.default.createElement(_reactRouterDom.Link, {
    to: "/alerts"
  }, "Alerts"), _react.default.createElement(_reactRouterDom.Link, {
    to: "/analytics"
  }, "Analytics")), _react.default.createElement("div", {
    className: "login-status"
  }, _react.default.createElement("div", {
    className: "logged-in"
  }, _react.default.createElement("p", null, "Logged in as:"), _react.default.createElement("p", null, "DEV-USER"))));
};

exports.default = _default;