function encodeAndDecodeMessages() {
    function encode(){
        if(sender.value !== ""){
            receiver.value = [...sender.value]
                .map(x => String.fromCharCode(x.charCodeAt(0) + 1))
                .join("");

            isDecoded = false;
            sender.value = "";
        }
    }

    function decode(){
        if(!isDecoded){
            receiver.value = [...receiver.value]
                .map(x => String.fromCharCode(x.charCodeAt(0) - 1))
                .join("");
        }
        
        isDecoded = true;
    }
    
    let encodeButton = document.querySelectorAll("button")[0];
    let decodeButton = document.querySelectorAll("button")[1];
    let sender = encodeButton.parentElement.querySelector("textarea");
    let receiver = decodeButton.parentElement.querySelector("textarea");
    let isDecoded = false;

    encodeButton.addEventListener("click", encode);
    decodeButton.addEventListener("click", decode);
}