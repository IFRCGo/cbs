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

var _reactRouterDom = require("react-router-dom");

var _Home = _interopRequireDefault(require("./Home.js"));

var _lazyLoad = _interopRequireDefault(require("../lib/lazyLoad.js"));

var Main =
/*#__PURE__*/
function (_React$Component) {
  (0, _inherits2.default)(Main, _React$Component);

  function Main() {
    (0, _classCallCheck2.default)(this, Main);
    return (0, _possibleConstructorReturn2.default)(this, (0, _getPrototypeOf2.default)(Main).apply(this, arguments));
  }

  (0, _createClass2.default)(Main, [{
    key: "render",
    value: function render() {
      var NotFound = (0, _lazyLoad.default)(import('./NotFound'));
      var reduxStore = this.props.store;
      return _react.default.createElement(_reactRouterDom.Switch, null, _react.default.createElement(_reactRouterDom.Route, {
        exact: true,
        path: "/",
        component: _Home.default
      }), this.props.routes.map(function (route, index) {
        var ConnectedComponent;

        if (route.component.component) {
          ConnectedComponent = route.component.component;
        } else {
          ConnectedComponent = route.component;
        }

        var FinalComponent = function FinalComponent() {
          var props = Object.assign({}, arguments.length <= 0 ? undefined : arguments[0], {
            store: reduxStore
          });
          return _react.default.createElement(ConnectedComponent, props);
        };

        return Array.isArray(route.path) ? _react.default.createElement("div", {
          key: index
        }, route.path.map(function (childRoute, childIndex) {
          return _react.default.createElement(_reactRouterDom.Route, {
            key: childIndex,
            path: childRoute,
            exact: route.exact,
            component: FinalComponent
          });
        })) : _react.default.createElement(_reactRouterDom.Route, {
          key: index,
          path: route.path,
          exact: route.exact,
          component: FinalComponent
        });
      }), _react.default.createElement(_reactRouterDom.Route, {
        component: NotFound
      }));
    }
  }]);
  return Main;
}(_react.default.Component);

exports.default = Main;
;