<template>
  <div id="app">
    <app-regiser></app-regiser>
  </div>
</template>

<script>
import AppRegiser from "./components/Register.vue";

export default {
  name: "App",
  components: {
    AppRegiser
  }
};
</script>

<style>
* {
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
}
</style>
