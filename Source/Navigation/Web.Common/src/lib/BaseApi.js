import fetch from 'isomorphic-fetch';

export default class BaseApi {
  static get Headers() {
    return {
      'Content-Type': 'application/json'
    };
  }

  static createErrorPayload(status, message, data) {
    const err = new Error(message);
    err.status = status;
    err.data = data;

    return err;
  }

  static formatUrl(url) {
    const parts = url.split('//');
    const protocol = parts.shift();

    return `${protocol}//` + parts.join('/');
  }

  constructor(opts = {}) {
    this.baseUrl = opts.baseUrl || 'http://localhost:3000';
  }

  post(url, data) {
    return this.fetch(url, {
      method: 'POST',
      headers: Object.assign({}, BaseApi.Headers),
      body: JSON.stringify(data)
    });
  }

  put(url, data) {
    return this.fetch(url, {
      method: 'PUT',
      headers: Object.assign({}, BaseApi.Headers),
      body: JSON.stringify(data)
    });
  }

  fetch(url, params = {}) {
    const fetchUrl = BaseApi.formatUrl(this.baseUrl + url);

    return fetch(fetchUrl, Object.assign(params, {
      credentials: 'same-origin'
    }))
      .then(function(resp) {
        if (resp.ok) {
          return resp.status === 204 ? '' : resp.json();
        }

        const contentType = resp.headers.get('content-type') || '';
        const isJson = contentType.includes('application/json');

        if (isJson) {
          return resp.json().then(json => {
            throw BaseApi.createErrorPayload(resp.status, json.message || resp.statusText, json);
          });
        }

        throw BaseApi.createErrorPayload(resp.status, resp.statusText || 'Unknown Error', resp);
      });
  }
}
