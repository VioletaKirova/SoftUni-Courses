function solve() {
  function handleException(res) {
    if (!res.ok) {
      throw new Error(`Error: ${res.status} | ${res.statusText}`);
    }

    return res;
  }

  function logError(err) {
    console.log(err.message);
  }

  function handleLoadSuccess(res) {
    phonebookUl.innerHTML = "";

    Object.entries(res).forEach(([id, data]) => {
      const { person, phone } = data;
      const li = document.createElement("li");
      li.textContent = `${person}: ${phone}`;

      const deleteBth = document.createElement("button");
      deleteBth.textContent = "Delete";
      deleteBth.classList.add("deleteBtn");
      deleteBth.setAttribute("data-target", id);
      deleteBth.addEventListener("click", deleteEntry);

      li.appendChild(deleteBth);
      phonebookUl.appendChild(li);
    });
  }

  function loadEntries() {
    fetch("https://phonebook-nakov.firebaseio.com/phonebook.json")
      .then(handleException)
      .then(res => res.json())
      .then(handleLoadSuccess)
      .catch(logError);
  }

  function createEntry() {
    const person = personInput.value;
    const phone = phoneInput.value;

    if (person !== "" && phone !== "") {
      const headers = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          person,
          phone
        })
      };

      fetch("https://phonebook-nakov.firebaseio.com/phonebook.json", headers)
        .then(handleException)
        .then(() => {
          personInput.value = "";
          phoneInput.value = "";
          loadEntries();
        })
        .catch(logError);
    }
  }

  function deleteEntry() {
    const key = this.getAttribute("data-target");
    const headers = {
      method: "DELETE"
    };

    fetch(
      `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`,
      headers
    )
      .then(handleException)
      .then(() => {
        phonebookUl.innerHTML = "";
        loadEntries();
      })
      .catch(logError);
  }

  const phonebookUl = document.querySelector("#phonebook");
  const personInput = document.querySelector("#person");
  const phoneInput = document.querySelector("#phone");

  return {
    loadEntries,
    createEntry,
    deleteEntry
  };
}

let result = solve();
