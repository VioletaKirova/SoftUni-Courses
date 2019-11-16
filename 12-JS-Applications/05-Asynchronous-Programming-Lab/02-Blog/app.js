import { fetchData } from "../01-GitHub-Commits/fetchData.js";

function showError(message) {
  const messageObj = JSON.parse(message);
  html.postTitle().textContent = "Error!";
  html.commentsHeading().textContent = `${messageObj.status} | ${messageObj.statusText}`;
}

async function loadPosts() {
  try {
    const posts = await fetchData(`${baseUrl}posts.json`);

    html.select().innerHTML = "";

    Object.entries(posts).forEach(x => {
      const option = document.createElement("option");
      option.value = x[0];
      option.textContent = x[1].title;

      html.select().appendChild(option);
    });
  } catch (err) {
    showError(err.message);
  }
}

async function viewPost() {
  try {
    const post = await fetchData(`${baseUrl}posts/${html.select().value}.json`);
    const comments = await fetchData(`${baseUrl}comments.json`);

    html.postTitle().textContent = post.title;
    html.postBody().textContent = post.body;

    Object.values(comments)
      .filter(x => x.postId === post.id)
      .forEach(x => {
        const li = document.createElement("li");
        li.textContent = x.text;

        html.postComments().appendChild(li);
      });
  } catch (err) {
    showError(err.message);
  }
}

const actions = {
  btnLoadPosts: loadPosts,
  btnViewPost: viewPost
};

const html = {
  select: () => document.getElementById("posts"),
  postTitle: () => document.getElementById("post-title"),
  postBody: () => document.getElementById("post-body"),
  postComments: () => document.getElementById("post-comments"),
  commentsHeading: () => document.getElementById("comments-heading")
};

const baseUrl = "https://blog-apps-c12bf.firebaseio.com/";

document.addEventListener("click", function(evt) {
  if (actions[evt.target.id] !== undefined) {
    actions[evt.target.id]();
  }
});
