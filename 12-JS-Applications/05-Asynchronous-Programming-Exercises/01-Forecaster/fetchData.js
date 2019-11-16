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

function handleSuccess(res) {
  return res.json();
}

export function fetchData(url) {
  return fetch(url)
    .then(handleError)
    .then(handleSuccess)
    .catch(err => {
      console.log(err);
      throw err;
    });
}