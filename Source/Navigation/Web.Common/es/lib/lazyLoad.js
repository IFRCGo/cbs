"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _react = _interopRequireDefault(require("react"));

var _reactLoadable = _interopRequireDefault(require("react-loadable"));

var _Spinner = _interopRequireDefault(require("../views/Spinner"));

var _Error = _interopRequireDefault(require("../views/Error"));

/**
 * Return a lazy-loaded component which shows a spinner while loading and which
 * does some error handling.
 */
var _default = function _default(_loader) {
  return (0, _reactLoadable.default)({
    loader: function loader() {
      return _loader;
    },
    loading: function loading(props) {
      if (props.error) {
        return _react.default.createElement(_Error.default, {
          title: "Error",
          message: "Load error"
        });
      } else if (props.pastDelay) {
        return _react.default.createElement(_Spinner.default, null);
      }

      return null;
    }
  });
};

exports.default = _default;