function solve() {
   let spans = document.querySelectorAll("span");

   let count = 0;
   let currentHand = {
      topCard: "",
      bottomCard: ""
   };

   function checkCards(){
      if(Number(currentHand.topCard.name) > Number(currentHand.bottomCard.name)){
         currentHand.topCard.style.border = "2px solid green";
         currentHand.bottomCard.style.border = "2px solid red";
      } else {
         currentHand.bottomCard.style.border = "2px solid green";
         currentHand.topCard.style.border = "2px solid red";
      }

      count = 0;

      spans[0].innerHTML = "";
      spans[2].innerHTML = "";

      document.querySelector("#history").innerHTML += `[${currentHand.topCard.name} vs ${currentHand.bottomCard.name}] `;
   }

   [...document.querySelectorAll("img")]
      .forEach(i => i.addEventListener("click", (evt) => {
         evt.target.src = "images/whiteCard.jpg";
         let cardValue = evt.target.name;
      
         if(evt.target.parentNode.id === "player1Div"){
            spans[0].innerHTML = cardValue;
            currentHand.topCard = evt.target;
         } else {
            spans[2].innerHTML = cardValue;
            currentHand.bottomCard = evt.target;
         }
      
         count++;

         if(count === 2){
            checkCards();
         }
      })); 
}