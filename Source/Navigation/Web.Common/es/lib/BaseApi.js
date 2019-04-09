"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.default = void 0;

var _classCallCheck2 = _interopRequireDefault(require("@babel/runtime/helpers/classCallCheck"));

var _createClass2 = _interopRequireDefault(require("@babel/runtime/helpers/createClass"));

var _isomorphicFetch = _interopRequireDefault(require("isomorphic-fetch"));

var BaseApi =
/*#__PURE__*/
function () {
  (0, _createClass2.default)(BaseApi, null, [{
    key: "createErrorPayload",
    value: function createErrorPayload(status, message, data) {
      var err = new Error(message);
      err.status = status;
      err.data = data;
      return err;
    }
  }, {
    key: "formatUrl",
    value: function formatUrl(url) {
      var parts = url.split('//');
      var protocol = parts.shift();
      return "".concat(protocol, "//") + parts.join('/');
    }
  }, {
    key: "Headers",
    get: function get() {
      return {
        'Content-Type': 'application/json'
      };
    }
  }]);

  function BaseApi() {
    var opts = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : {};
    (0, _classCallCheck2.default)(this, BaseApi);
    this.baseUrl = opts.baseUrl || 'http://localhost:3000';
  }

  (0, _createClass2.default)(BaseApi, [{
    key: "post",
    value: function post(url, data) {
      return this.fetch(url, {
        method: 'POST',
        headers: Object.assign({}, BaseApi.Headers),
        body: JSON.stringify(data)
      });
    }
  }, {
    key: "put",
    value: function put(url, data) {
      return this.fetch(url, {
        method: 'PUT',
        headers: Object.assign({}, BaseApi.Headers),
        body: JSON.stringify(data)
      });
    }
  }, {
    key: "fetch",
    value: function fetch(url) {
      var params = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : {};
      var fetchUrl = BaseApi.formatUrl(this.baseUrl + url);
      return (0, _isomorphicFetch.default)(fetchUrl, Object.assign(params, {
        credentials: 'same-origin'
      })).then(function (resp) {
        if (resp.ok) {
          return resp.status === 204 ? '' : resp.json();
        }

        var contentType = resp.headers.get('content-type') || '';
        var isJson = contentType.includes('application/json');

        if (isJson) {
          return resp.json().then(function (json) {
            throw BaseApi.createErrorPayload(resp.status, json.message || resp.statusText, json);
          });
        }

        throw BaseApi.createErrorPayload(resp.status, resp.statusText || 'Unknown Error', resp);
      });
    }
  }]);
  return BaseApi;
}();

exports.default = BaseApi;