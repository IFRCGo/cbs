export function getJson(url) {
    return fetch(url, { method: "GET" }).then(response => response.json());
}
