function solve() {
   document.getElementById("searchBtn")
      .addEventListener("click", () => {
         let input = document.getElementById("searchField");
         let rows = [...document.querySelectorAll("tr")];

         rows.forEach(r => r.className = "");
         
         if(input.value !== ""){
            rows.forEach(r => {
               if(r.innerHTML.includes(input.value)){
                  r.className = "select";
               }
            });

            input.value = "";
         }
      });
}