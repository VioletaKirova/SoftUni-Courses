function lockedProfile() {
    function display(evt){
        let currentButton = evt.currentTarget;
        let [lock, unlock] = [...currentButton.parentElement.querySelectorAll("input")].slice(0, 2);
        
        if(currentButton.innerHTML === "Hide it" && unlock.checked){
            currentButton.previousElementSibling.style.display = "none";
            currentButton.innerHTML = "Show more";
            return;
        }

        if(lock.checked){
            return;
        }

        currentButton.previousElementSibling.style.display = "block";
        currentButton.innerHTML = "Hide it";
    }

    [...document.querySelectorAll("button")]
        .forEach(b => b.addEventListener("click", display));
}