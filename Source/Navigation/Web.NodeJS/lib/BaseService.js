const requestPromise = require('request-promise-native');

class BaseService {

  /**
   *
   * @param options
   */
  constructor(options = {}) {
    this.options = options;
    this.requestOptions = Object.assign({}, {
      json: true
    }, options.request || {});
  }

  __handleResponse(response) {
    if (response.invalid && response.exception) {
      const err = new Error('An error occurred.');
      err.data = response.exception;
      throw err;
    }

    return response;
  }

  /**
   * Get new HTTP client instance.
   *
   * @readonly
   */
  get client() {
    return requestPromise.defaults(this.requestOptions);
  }

  post(uri, {body = {}, json = true}) {
    return this.client({
      method: 'POST',
      uri,
      body,
      json
    }).then(response => {
      return this.__handleResponse(response);
    })
  }

  get() {
    return this.client.get.apply(this.client, arguments);
  }
}

module.exports = BaseService;
