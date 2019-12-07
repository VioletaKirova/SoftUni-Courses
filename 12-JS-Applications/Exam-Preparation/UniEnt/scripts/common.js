const htmlNotifications = {
  successBox: () => document.getElementById("successBox"),
  loadingBox: () => document.getElementById("loadingBox"),
  errorBox: () => document.getElementById("errorBox")
};

export function getSessionInfo(ctx) {
  ctx.userId = sessionStorage.getItem("userId");
  ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
  ctx.username = sessionStorage.getItem("username");
}

export const partials = {
  header: "./templates/common/header.hbs",
  footer: "./templates/common/footer.hbs",
  notifications: "./templates/common/notifications.hbs"
};

export function showNotification(boxType, message) {
  htmlNotifications[boxType]().style.display = "block";
  htmlNotifications[boxType]().textContent = message;
}

export function hideNotification(boxType) {
  htmlNotifications[boxType]().style.display = "none";
  htmlNotifications[boxType]().textContent = "";
}

export function errorNotify(message = "Something went wrong!"){
  showNotification("errorBox", message);
  setTimeout(() => hideNotification("errorBox"), 5000);
}
