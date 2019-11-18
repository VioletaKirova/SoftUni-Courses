function solve() {
  function sendMessage() {
    let text = document.getElementById("chat_input");

    if (text.value !== "") {
      let message = document.createElement("div");
      message.innerHTML = text.value;
      message.classList.add("message");
      message.classList.add("my-message");

      let parentDiv = document.getElementById("chat_messages");
      parentDiv.appendChild(message);

      text.value = "";
    }
  }

  document.getElementById("send").addEventListener("click", sendMessage);
}
