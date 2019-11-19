function getArticleGenerator(articles) {
  let inputArr = [...articles];

  return function() {
    if (inputArr.length > 0) {
      console.log(articles.length);
      let div = document.querySelector("#content");
      let article = document.createElement("article");

      article.textContent = inputArr.shift();

      div.appendChild(article);
    }
  };
}
