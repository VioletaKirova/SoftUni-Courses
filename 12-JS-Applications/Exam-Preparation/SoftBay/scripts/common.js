const notifications = {
  success: () => document.getElementById("successNotification"),
  error: () => document.getElementById("errorNotification"),
  loading: () => document.getElementById("loadingNotification")
};

export function getSessionInfo(ctx) {
  ctx.userId = sessionStorage.getItem("userId");
  ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
  ctx.username = sessionStorage.getItem("username");
}

export const partials = {
  header: "./templates/common/header.hbs",
  footer: "./templates/common/footer.hbs"
};

export function showNotification(type, message) {
  notifications[type]().style.display = "block";
  notifications[type]().innerHTML = message;
}

function hideNotification(type) {
  notifications[type]().style.display = "none";
}

export function errorNotify(message) {
  showNotification("error", message);
  setTimeout(() => hideNotification("error"), 4000);
}
