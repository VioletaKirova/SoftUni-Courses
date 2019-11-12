function solve() {
  let stopId = "depot";
  let stopName = "";

  const span = document.querySelector("#info > span");
  const departBtn = document.querySelector("#depart");
  const arriveBtn = document.querySelector("#arrive");

  function handleException(res) {
    if (!res.ok) {
      span.textContent = "Error!";
      throw new Error(`Error: ${res.status} | ${res.statusText}`);
    }

    return res;
  }

  function handleSuccess(res) {
    stopId = res.next;
    stopName = res.name;

    span.textContent = `Next stop ${stopName}`;

    departBtn.disabled = true;
    arriveBtn.disabled = false;
  }

  function depart() {
    fetch(`https://judgetests.firebaseio.com/schedule/${stopId}.json`)
      .then(handleException)
      .then(res => res.json())
      .then(handleSuccess)
      .catch(err => {
        console.log(err.message);
      });
  }

  function arrive() {
    span.textContent = `Arriving at ${stopName}`;

    departBtn.disabled = false;
    arriveBtn.disabled = true;
  }

  return {
    depart,
    arrive
  };
}

let result = solve();
