import { fetchData } from "./fetchData.js"

async function loadCommits(evt) {
  if (evt.target.id === "loadCommitsBth") {
    let commits;
    try {
      commits = await fetchData(
        `${baseUrl}${html.username().value}/${html.repo().value}/commits`
      );
    } catch (err) {
      const errObj = JSON.parse(err.message);

      commits = [
        {
          commit: {
            author: {
              name: "Error"
            },
            message: `${errObj.status} (${errObj.statusText})`
          }
        }
      ];
    }

    html.commits().innerHTML = "";

    commits.forEach(x => {
      const li = document.createElement("li");
      li.textContent = `${x.commit.author.name}: ${x.commit.message}`;

      html.commits().appendChild(li);
    });
  }
}

const baseUrl = "https://api.github.com/repos/";

const html = {
  username: () => document.htmlById("username"),
  repo: () => document.htmlById("repo"),
  commits: () => document.htmlById("commits")
};

document.addEventListener("click", loadCommits);
