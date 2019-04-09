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

require("../assets/footer.scss");

var _default =
/*#__PURE__*/
function (_React$Component) {
  (0, _inherits2.default)(_default, _React$Component);

  function _default() {
    (0, _classCallCheck2.default)(this, _default);
    return (0, _possibleConstructorReturn2.default)(this, (0, _getPrototypeOf2.default)(_default).apply(this, arguments));
  }

  (0, _createClass2.default)(_default, [{
    key: "componentDidMount",
    value: function componentDidMount() {
      var links = document.querySelectorAll('footer a'); // IE doesn't support NodeList.forEach, so we need to convert links to
      // an array first.

      links = Array.from(links);
      links.forEach(function (anchor) {
        anchor.target = '_blank';
        anchor.rel = 'noopener noreferrer';
      });
    }
  }, {
    key: "render",
    value: function render() {
      return _react.default.createElement("footer", null, _react.default.createElement("div", {
        className: "container"
      }, _react.default.createElement("div", {
        className: "row"
      }, _react.default.createElement("div", {
        className: "col-md-4 pull-left footer-logo"
      }, _react.default.createElement("svg", {
        className: "pull-left",
        xmlns: "http://www.w3.org/2000/svg",
        width: "60",
        height: "60",
        viewBox: "0 0 60 60"
      }, _react.default.createElement("title", null, "The Red Cross"), _react.default.createElement("g", {
        fill: "none",
        fillRule: "evenodd"
      }, _react.default.createElement("path", {
        fill: "#F2F2F2",
        d: "M60 60H0V0h60v60z"
      }), _react.default.createElement("path", {
        fill: "#D52B1E",
        d: "M24 36v12h12V36h12V24H36V12H24v12H12v12h12z"
      }))), _react.default.createElement("h4", {
        className: "pull-left"
      }, "Norwegian Red Cross")), _react.default.createElement("div", {
        className: "col-md-4"
      }, _react.default.createElement("nav", null, _react.default.createElement("ul", null, _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://www.rodekors.no/en/english-pages/"
      }, "About Us")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://www.rodekors.no/en/english-pages/international-strategy/"
      }, "International Strategy")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://www.rodekors.no/om-rode-kors/presse/"
      }, "Pressroom")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://www.rodekors.no/om-rode-kors/kontaktinformasjon/"
      }, "Contact Information")), _react.default.createElement("li", {
        className: "footer-social"
      }, _react.default.createElement("ul", null, _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://twitter.com/rodekorsnorge",
        title: "Norwegian RedCross on Twitter"
      }, _react.default.createElement("svg", {
        width: "18",
        height: "18",
        viewBox: "0 0 18 18",
        xmlns: "http://www.w3.org/2000/svg"
      }, _react.default.createElement("title", null, "twitter"), _react.default.createElement("path", {
        d: "M18 3.775a7.23 7.23 0 0 1-2.12.596 3.788 3.788 0 0 0 1.623-2.093 7.33 7.33 0 0 1-2.347.92A3.64 3.64 0 0 0 12.46 2c-2.038 0-3.69 1.696-3.69 3.787 0 .297.03.586.094.863-3.068-.158-5.79-1.666-7.61-3.958-.318.56-.5 1.21-.5 1.904 0 1.315.653 2.474 1.643 3.153a3.622 3.622 0 0 1-1.673-.477v.048c0 1.836 1.274 3.367 2.962 3.715-.31.086-.636.133-.973.133-.238 0-.47-.024-.695-.07.47 1.505 1.833 2.6 3.448 2.63A7.29 7.29 0 0 1 0 15.297 10.247 10.247 0 0 0 5.66 17c6.793 0 10.505-5.772 10.505-10.778l-.012-.49A7.48 7.48 0 0 0 18 3.775z",
        fill: "#010002",
        fillRule: "evenodd"
      })))), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://facebook.com/rodekors/",
        title: "Norwegian RedCross on Facebook"
      }, _react.default.createElement("svg", {
        width: "18",
        height: "18",
        viewBox: "0 0 18 18",
        xmlns: "http://www.w3.org/2000/svg"
      }, _react.default.createElement("title", null, "facebook"), _react.default.createElement("path", {
        d: "M15.227 2H2.773A.773.773 0 0 0 2 2.773v12.454c0 .427.346.773.773.773h6.705v-5.422H7.653V8.466h1.825v-1.56c0-1.807 1.104-2.792 2.717-2.792.773 0 1.437.058 1.63.084v1.89h-1.118c-.877 0-1.047.417-1.047 1.03v1.348h2.092l-.272 2.112h-1.82V16h3.567a.773.773 0 0 0 .773-.773V2.773A.773.773 0 0 0 15.227 2",
        fill: "#000",
        fillRule: "evenodd"
      }))))))))), _react.default.createElement("div", {
        className: "col-md-4"
      }, _react.default.createElement("nav", null, _react.default.createElement("ul", null, _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://cbsrc.org/cbs/"
      }, "About CBS")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://cbsrc.org/contactus/"
      }, "Contact Us")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://cbsrc.org/contribute/"
      }, "Get Involved")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://medium.com/redcrosscbs"
      }, "Blog")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://cbsv2.slack.com/"
      }, "CBS on Slack")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://github.com/ifrcgo/cbs"
      }, "CBS on GitHub")))))), _react.default.createElement("div", {
        className: "footer-secondary"
      }, _react.default.createElement("ul", null, _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "https://www.rodekors.no/om-rode-kors/behandlingsgrunnlag/"
      }, "Privacy")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "#"
      }, "Cookies")), _react.default.createElement("li", null, _react.default.createElement("a", {
        href: "#"
      }, "Legal"))), _react.default.createElement("p", null, "\xA9", new Date().getFullYear(), " Community Based Surveillance"))));
    }
  }]);
  return _default;
}(_react.default.Component);

exports.default = _default;