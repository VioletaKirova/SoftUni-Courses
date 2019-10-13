function create(words) {
   function displayParagraph(evt){
      evt.currentTarget.firstElementChild.style.display = "block";
   }

   let content = document.querySelector("#content");

   words.forEach(word => {
      let div = document.createElement("div");
      div.addEventListener("click", displayParagraph);

      let p = document.createElement("p");
      p.innerHTML = word;
      p.style.display = "none";

      div.appendChild(p);
      content.appendChild(div);
   });
}