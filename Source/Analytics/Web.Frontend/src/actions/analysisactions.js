export function fetchPostsWithRedux(timeWindow, selectedColumns, name) {
  return (dispatch) => {
    dispatch(fetchPostsRequest(name));
    return fetchPosts(timeWindow, selectedColumns).then(([response, json]) => {
      if (response.status === 200) {
        dispatch(fetchPostsSuccess(json, name))
      }
      else {
        dispatch(fetchPostsError(name))
      }
    })
  }
}

function fetchPosts(timeWindow, selectedColumns) {
  let columns = selectedColumns.map(column => "selectedSeries=" + column).join("&");

  const URL = "https://localhost:5000/api/Analysis/2019-01-01/2020-01-01/" + timeWindow + "?" + columns;
  return fetch(URL, { method: 'GET' })
    .then(response => Promise.all([response, response.json()]));
}

function fetchPostsRequest(name) {
  return {
    type: "FETCH_REQUEST",
    name: name
  }
}

function fetchPostsSuccess(payload, name) {
  return {
    type: "FETCH_SUCCESS",
    payload,
    name: name
  }
}

function fetchPostsError(name) {
  return {
    type: "FETCH_ERROR",
    name: name
  }
}