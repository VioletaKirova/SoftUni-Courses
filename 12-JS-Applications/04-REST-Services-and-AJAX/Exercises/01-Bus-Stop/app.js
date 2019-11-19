function getInfo() {
  function handleException(res) {
    if (!res.ok) {
      stopName.textContent = "Error!";
      throw new Error(`Error: ${res.status} | ${res.statusText}`);
    }

    return res;
  }

  function handleSuccess(res) {
    stopName.textContent = res.name;

    Object.entries(res.buses).forEach(([busId, time]) => {
      let li = document.createElement("li");
      li.textContent = `Bus ${busId} arrives in ${time} minutes`;

      busesUl.appendChild(li);
    });
  }

  const stopName = document.querySelector("#stopName");
  const busesUl = document.querySelector("#buses");
  const stopIdInput = document.querySelector("#stopId");
  const stopId = stopIdInput.value.trim();

  busesUl.innerHTML = "";

  if (stopId.value !== "") {
    fetch(`https://judgetests.firebaseio.com/businfo/${stopId}.json`)
      .then(handleException)
      .then(res => res.json())
      .then(handleSuccess)
      .catch(err => {
        console.log(`${err.message}`);
      });
  }
}
