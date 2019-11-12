function loadRepos() {
  function notFoundMessage() {
    let li = document.createElement("li");
    li.textContent = `${username} does not exist.`;

    list.appendChild(li);
  }

  function handleException(res) {
    if (res.message && res.documentation_url) {
      throw new Error(`${res.message} - ${res.documentation_url}`);
    }

    return res;
  }

  function drawHTML(res) {
    res.forEach(repo => {
      let li = document.createElement("li");

      let a = document.createElement("a");
      a.href = repo.html_url;
      a.textContent = repo.full_name;

      li.appendChild(a);
      list.appendChild(li);
    });
  }

  const list = document.querySelector("#repos");
  const input = document.querySelector("#username");
  const username = input.value;

  Array.from(list.children).forEach(x => {
    x.parentNode.removeChild(x);
  });

  if (username !== "") {
    let url = `https://api.github.com/users/${username}/repos`;
    fetch(url)
      .then(res => {
        if (res.status === 404) {
          notFoundMessage();
        }
        if (res.status >= 500) {
          throw new Error(`${res.status} - ${res.statusText}`);
        }
        return res.json();
      })
      .then(res => handleException(res))
      .then(res => drawHTML(res))
      .catch(err => console.log(err));
  }
}
