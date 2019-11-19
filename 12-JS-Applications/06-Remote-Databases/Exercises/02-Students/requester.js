const username = "root";
const password = "root";

const baseUrl = "https://baas.kinvey.com";
const appKey = "kid_r1Qr4aCiH";
const appSecret = "25febbe120b54bb797b05a0ebc413fa5";

function makeHeaders(httpMethod, data) {
  const headers = {
    method: httpMethod,
    headers: {
      Authorization: `Basic ${btoa(`${username}:${password}`)}`,
      "Content-Type": "application/json"
    }
  };

  if (httpMethod === "POST" || httpMethod === "PUT") {
    headers.body = JSON.stringify(data);
  }

  return headers;
}

function handleError(res) {
  if (!res.ok) {
    throw new Error(
      JSON.stringify({
        status: res.status,
        statusText: res.statusText
      })
    );
  }

  return res;
}

function serializeData(res) {
  return res.json();
}

function fetchData(kinveyModule, endPoint, headers) {
  const url = `${baseUrl}/${kinveyModule}/${appKey}/${endPoint}`;

  return fetch(url, headers)
    .then(handleError)
    .then(serializeData);
}

export function get(kinveyModule, endPoint) {
  const headers = makeHeaders("GET");

  return fetchData(kinveyModule, endPoint, headers);
}

export function post(kinveyModule, endPoint, data) {
  const headers = makeHeaders("POST", data);

  return fetchData(kinveyModule, endPoint, headers);
}

export function put(kinveyModule, endPoint, data) {
  const headers = makeHeaders("PUT", data);

  return fetchData(kinveyModule, endPoint, headers);
}

export function del(kinveyModule, endPoint) {
  const headers = makeHeaders("DELETE");

  return fetchData(kinveyModule, endPoint, headers);
}