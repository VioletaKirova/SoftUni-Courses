function solve(){
  function createOffer(evt) {
    evt.preventDefault();
  
    let offersContainer = document.querySelector("#offers-container");
    let offerNameInput = document.querySelector("#offerName");
    let companyInput = document.querySelector("#company");
    let descriptionInput = document.querySelector("#description");
  
    let offerName = offerNameInput.value;
    let company = companyInput.value;
    let description = descriptionInput.value;
  
    if (offerName !== "" && company !== "" && description !== "") {
      let parentDiv = document.createElement("div");
      parentDiv.classList.add("col-3");
  
      let childDiv = document.createElement("div");
      childDiv.classList.add("card");
      childDiv.classList.add("text-white");
      childDiv.classList.add("bg-dark");
      childDiv.classList.add("mb-3");
      childDiv.classList.add("pb-3");
      childDiv.style.maxWidth = "18rem";
  
      let firstInnerChildDiv = document.createElement("div");
      firstInnerChildDiv.classList.add("card-header");
      firstInnerChildDiv.textContent = offerName;
  
      let secondInnerChildDiv = document.createElement("div");
      secondInnerChildDiv.classList.add("card-body");
  
      let h5 = document.createElement("h5");
      h5.classList.add("card-title");
      h5.textContent = company;
  
      let p = document.createElement("p");
      p.classList.add("card-text");
      p.textContent = description;
  
      secondInnerChildDiv.appendChild(h5);
      secondInnerChildDiv.appendChild(p);
  
      childDiv.appendChild(firstInnerChildDiv);
      childDiv.appendChild(secondInnerChildDiv);
  
      parentDiv.appendChild(childDiv);
  
      offersContainer.appendChild(parentDiv);
  
      offerNameInput.value = "";
      companyInput.value = "";
      descriptionInput.value = "";
    }
  }
  
  function logout() {
    createOffersForm.style.display = "none";
  
    usernameInput.value = "";
    usernameInput.classList.remove("bg-light");
    usernameInput.classList.remove("border-0");
    usernameInput.disabled = false;
  
    loginLogoutBtn.textContent = "Login";
    loginLogoutBtn.removeEventListener("click", logout);
    loginLogoutBtn.addEventListener("click", login);
  }
  
  function login(evt) {
    evt.preventDefault();
  
    let username = usernameInput.value;
  
    if (username.length >= 4 && username.length <= 10) {
      if (notification.textContent !== "") {
        notification.textContent = "";
      }
  
      createOffersForm.style.display = "block";
  
      usernameInput.value = `Hello, ${username}!`;
      usernameInput.classList.add("border-0");
      usernameInput.classList.add("bg-light");
      usernameInput.disabled = true;
  
      loginLogoutBtn.textContent = "Logout";
      loginLogoutBtn.removeEventListener("click", login);
      loginLogoutBtn.addEventListener("click", logout);
    } else {
      notification.textContent =
        "The username length should be between 4 and 10 characters.";
    }
  }
  
  let createOffersForm = document.querySelector("#create-offers");
  let createOfferBtn = document.querySelector("#create-offer-Btn");
  let loginLogoutBtn = document.querySelector("#loginBtn");
  let notification = document.querySelector("#notification");
  let usernameInput = document.querySelector("#username");
  
  createOffersForm.style.display = "none";
  
  createOfferBtn.addEventListener("click", createOffer);
  loginLogoutBtn.addEventListener("click", login);  
}