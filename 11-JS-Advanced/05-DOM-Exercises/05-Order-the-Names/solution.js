function solve() {
    document.querySelector("#exercise button")
        .addEventListener("click", () => {
            let input = document.querySelector('#exercise input');
            let list = document.querySelectorAll("li");

            if(input.value !== ""){
                let firstChar = input.value[0].toUpperCase();
                let name = firstChar + input.value.substring(1).toLowerCase();

                let index = firstChar.charCodeAt() - 65;

                list[index].innerHTML += list[index].innerHTML.length === 0 ?
                    name :
                    `, ${name}`;

                input.value = "";
            }
        });
}