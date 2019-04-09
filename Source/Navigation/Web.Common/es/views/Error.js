"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _react = _interopRequireDefault(require("react"));

var _default = function _default(props) {
  var maybeMessage = null;

  if (props.message) {
    maybeMessage = _react.default.createElement("p", null, props.message);
  }

  return _react.default.createElement("section", {
    id: props.id,
    className: "error"
  }, _react.default.createElement("h2", null, props.title), maybeMessage || 'The page you are looking for doesn\'t exist.');
};

exports.default = _default;