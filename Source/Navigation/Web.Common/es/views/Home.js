"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _react = _interopRequireDefault(require("react"));

var _reactHelmet = _interopRequireDefault(require("react-helmet"));

var _reactRouterDom = require("react-router-dom");

var _default = function _default() {
  var title = 'CBS';
  var description = '';
  return _react.default.createElement(_react.default.Fragment, null, _react.default.createElement(_reactHelmet.default, null, _react.default.createElement("title", null, title), _react.default.createElement("meta", {
    property: "og:title",
    content: title
  }), _react.default.createElement("meta", {
    property: "og:description",
    content: description
  }), _react.default.createElement("meta", {
    name: "description",
    content: description
  })), _react.default.createElement("article", {
    id: "introduction",
    className: "container"
  }, _react.default.createElement("div", {
    className: "row"
  }, _react.default.createElement("div", {
    className: "col-md-12",
    style: {
      minHeight: '600px'
    }
  }, _react.default.createElement("h1", null, "Welcome to CBS")))));
};

exports.default = _default;