import fetch from 'isomorphic-fetch';
import defined from 'defined';

const CONTENT_TYPE = 'Content-Type';

export default class BaseApi {
  static get Headers() {
    return {
      [CONTENT_TYPE]: 'application/json'
    };
  }

  static createErrorPayload(status, message, json) {
    return Object.assign(new Error(message), {
      status,
      json
    });
  }

  static post(url, data) {
    return BaseApi.fetch(url, {
      method: 'POST',
      headers: Object.assign({}, BaseApi.Headers),
      body: JSON.stringify(data)
    });
  }

  static put(url, data) {
    return BaseApi.fetch(url, {
      method: 'PUT',
      headers: Object.assign({}, BaseApi.Headers),
      body: JSON.stringify(data)
    });
  }

  static fetch(url, params = {}) {
    return fetch(url, Object.assign(params, {
      credentials: 'same-origin'
    }))
      .then(function(resp) {
        if (resp.ok) {
          return resp.status === 204 ? '' : resp.json();
        }

        const contentType = resp.headers.get('content-type') || '';
        const isJson = contentType.includes('application/json');

        if (isJson) {
          return resp.json().then(function(json) {
            return BaseApi.createErrorPayload(resp.status, defined(json.message, resp.statusText), json);
          });
        }

        const error = new Error(resp.statusText || 'Unknown Error');
        error.data = resp;

        throw error;
      });
  }
}