function solve() {
  function formatOutput(x) {
    return `visited ${x} times`;
  }

  let siteMap = {};

  let paragraphs = document.getElementsByTagName("p");
  let links = document.getElementsByTagName("a");
  
  for(let i = 0; i < paragraphs.length; i++){
    let site = links[i].textContent.trim();
    let timesClicked = paragraphs[i].innerHTML.match(/\d/gi)[0];
    
    siteMap[site] = timesClicked;
  }

  document.addEventListener("click", (evt) => {
    if(evt.target.nodeName === "SPAN"){
      evt.target.parentNode.parentNode.getElementsByTagName("p")[0].innerHTML = formatOutput(
          ++siteMap[evt.target.parentNode.parentNode.getElementsByTagName("a")[0].textContent.trim()]
        );
    }
  });
}