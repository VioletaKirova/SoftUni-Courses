<template>
  <app-content>
    <template v-slot:info>
      <h2 class="user-links">
        <a href="login.html">Login</a> |
        <a href="register.html" class="active-route">Register</a>
      </h2>

      <form class="user-form">
        <div class="form-group">
          <img src="https://img.icons8.com/material-sharp/42/000000/user.png" />
          <input type="text" name="username" placeholder="Username" />
        </div>

        <div class="form-group">
          <img src="https://img.icons8.com/material/42/000000/password--v1.png" />
          <input type="password" name="password" placeholder="Password" />
        </div>

        <div class="form-group">
          <img src="https://img.icons8.com/material/42/000000/password--v1.png" />
          <input type="password" name="rePassword" placeholder="Repeat password" />
        </div>

        <button>Register</button>
      </form>
    </template>
  </app-content>
</template>

<script>
import AppContent from "./shared/Content.vue";

export default {
  components: {
    AppContent
  }
};
</script>

<style scoped>
</style>