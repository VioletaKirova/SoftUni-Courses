<template>
  <div id="app">
    <app-cards></app-cards>
  </div>
</template>

<script>
import AppCards from "./components/Cards.vue";

export default {
  name: "App",
  components: {
    AppCards
  }
};
</script>

<style>
* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

body {
  height: 120vh;
  display: flex;
  background-image: linear-gradient(120deg, #d4fc79 0%, #96e6a1 100%);
}

#app {
  width: 100%;
  padding: 7%;
}
</style>
