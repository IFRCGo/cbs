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

var _reactSpinners = require("react-spinners");

// import './css/Spinner.css';

/**
 * Simple wrapper for react-spinners that uses some default options and applies
 * our custom styles.
 */
var _default =
/*#__PURE__*/
function (_React$Component) {
  (0, _inherits2.default)(_default, _React$Component);

  function _default(props) {
    var _this;

    (0, _classCallCheck2.default)(this, _default);
    _this = (0, _possibleConstructorReturn2.default)(this, (0, _getPrototypeOf2.default)(_default).call(this, props));
    _this.state = {
      showSpinner: false
    };
    return _this;
  }

  (0, _createClass2.default)(_default, [{
    key: "componentDidMount",
    value: function componentDidMount() {
      var _this2 = this;

      // According to Jakob Nielsen's research, "no special feedback is
      // necessary during delays of more than 0.1 but less than 1.0 second."
      //
      // react-spinkit, a competing library, does this by default
      //
      // https://www.nngroup.com/articles/response-times-3-important-limits/
      this.showSpinnerTimeout = setTimeout(function () {
        _this2.setState({
          showSpinner: true
        });
      }, 1000);
    }
  }, {
    key: "componentWillUnmount",
    value: function componentWillUnmount() {
      clearTimeout(this.showSpinnerTimeout);
    }
  }, {
    key: "render",
    value: function render() {
      return _react.default.createElement("div", {
        className: "spinner"
      }, _react.default.createElement(_reactSpinners.PulseLoader, {
        size: 20,
        loading: this.state.showSpinner
      }));
    }
  }]);
  return _default;
}(_react.default.Component);

exports.default = _default;