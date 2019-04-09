"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _classCallCheck2 = _interopRequireDefault(require("@babel/runtime/helpers/classCallCheck"));

var _createClass2 = _interopRequireDefault(require("@babel/runtime/helpers/createClass"));

var _possibleConstructorReturn2 = _interopRequireDefault(require("@babel/runtime/helpers/possibleConstructorReturn"));

var _getPrototypeOf2 = _interopRequireDefault(require("@babel/runtime/helpers/getPrototypeOf"));

var _inherits2 = _interopRequireDefault(require("@babel/runtime/helpers/inherits"));

var _react = _interopRequireDefault(require("react"));

var _reactHelmet = _interopRequireDefault(require("react-helmet"));

var _Header = _interopRequireDefault(require("./Header"));

var _Main = _interopRequireDefault(require("./Main"));

var _Footer = _interopRequireDefault(require("./Footer"));

var Application =
/*#__PURE__*/
function (_React$Component) {
  (0, _inherits2.default)(Application, _React$Component);

  function Application() {
    (0, _classCallCheck2.default)(this, Application);
    return (0, _possibleConstructorReturn2.default)(this, (0, _getPrototypeOf2.default)(Application).apply(this, arguments));
  }

  (0, _createClass2.default)(Application, [{
    key: "render",
    value: function render() {
      var maybeGraphURL = null;

      if (window.location.href) {
        maybeGraphURL = _react.default.createElement("meta", {
          property: "og:url",
          content: window.location.href
        });
      }

      return _react.default.createElement("div", {
        id: "application"
      }, _react.default.createElement(_reactHelmet.default, null, maybeGraphURL), _react.default.createElement(_Header.default, null), _react.default.createElement(_Main.default, {
        routes: this.props.routes,
        store: this.props.store
      }), _react.default.createElement(_Footer.default, null));
    }
  }]);
  return Application;
}(_react.default.Component);

exports.default = Application;