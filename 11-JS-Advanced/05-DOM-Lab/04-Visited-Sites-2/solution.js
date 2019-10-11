function solve() {
  [...document.querySelectorAll(".link-1 a")]
    .forEach(link => link.addEventListener("click", updateValue));

  function updateValue(link){
    let paragraph = link.currentTarget.nextElementSibling;
    let args = paragraph.innerHTML.split(" ");
    args[1]++;
    paragraph.innerHTML = args.join(" ");
  }
}