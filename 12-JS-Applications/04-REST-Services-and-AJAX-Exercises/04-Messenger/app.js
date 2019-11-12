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

  function submit() {
    const authorValue = authorInput.value;
    const contentValue = contentInput.value;

    if (authorValue !== "" && contentValue !== "") {
      const headers = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ author: authorValue, content: contentValue })
      };

      fetch(url, headers)
        .then(handleException)
        .then(() => {
          contentInput.value = "";

          refresh();
        })
        .catch(logError);
    }
  }

  function refresh() {
    messagesArea.textContent = "";

    fetch(url)
      .then(handleException)
      .then(res => res.json())
      .then(res => {
        Object.values(res).forEach(({ author, content }) => {
          messagesArea.textContent += `${author}: ${content}\n`;
        });
      })
      .catch(logError);
  }

  const url = "https://rest-messanger.firebaseio.com/messanger.json";
  const authorInput = document.querySelector("#author");
  const contentInput = document.querySelector("#content");
  const messagesArea = document.querySelector("#messages");

  return {
    refresh,
    submit
  };
}

let result = solve();
