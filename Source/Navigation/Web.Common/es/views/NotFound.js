"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _react = _interopRequireDefault(require("react"));

var _reactHelmet = _interopRequireDefault(require("react-helmet"));

var _Error = _interopRequireDefault(require("./Error"));

var _default = function _default() {
  return _react.default.createElement(_react.default.Fragment, null, _react.default.createElement(_reactHelmet.default, null, _react.default.createElement("meta", {
    name: "robots",
    content: "noindex"
  })), _react.default.createElement(_react.default.Fragment, null, _react.default.createElement("div", {
    className: "container"
  }, _react.default.createElement("div", {
    className: "row"
  }, _react.default.createElement("div", {
    className: "col-md-12",
    style: {
      minHeight: '500px'
    }
  }, _react.default.createElement(_Error.default, {
    id: "not-found",
    title: "Page Not Found"
  }))))));
};

exports.default = _default;