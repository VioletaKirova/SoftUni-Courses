<template>
  <div id="app">
    <app-header></app-header>
    <main>
      <app-nav
        @navigate="navigationHander($event)"
        :navItems="tutorials.technologies"
        :selectedIndex="selectedTechnologyIndex"
      ></app-nav>
      <!-- <app-home :subjects="subjects"></app-home> -->
      <!-- <app-login></app-login> -->
      <!-- <app-register></app-register> -->
      <app-create-subject
        :subjects="subjects"
        :technologies="tutorials.technologies"
        @create="createHandler($event)"
      ></app-create-subject>
    </main>
    <app-footer></app-footer>
  </div>
</template>

<script>
import data from "./tutorials.json";

// import AppHome from "./components/Home.vue";
// import AppLogin from "./components/Login.vue";
// import AppRegister from "./components/Register.vue";
import AppCreateSubject from "./components/CreateSubject.vue";
import AppHeader from "./components/core/Header.vue";
import AppFooter from "./components/core/Footer.vue";
import AppNav from "./components/core/Navigation.vue";

export default {
  name: "App",
  components: {
    // AppHome,
    // AppLogin,
    // AppRegister,
    AppCreateSubject,
    AppHeader,
    AppFooter,
    AppNav
  },
  data() {
    return {
      tutorials: data,
      selectedTechnologyIndex: 0
    };
  },
  methods: {
    navigationHander(index) {
      this.selectedTechnologyIndex = index;
    },
    createHandler({ technologyId, subject: name, htmlContent: content }) {
      const selectedTechnology = this.tutorials.technologies.find(
        t => t.id === technologyId
      );
      selectedTechnology.subjects = selectedTechnology.subjects.concat({
        name,
        content
      });
    }
  },
  computed: {
    subjects() {
      return this.tutorials.technologies[this.selectedTechnologyIndex].subjects;
    }
  }
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Lato&display=swap");
body {
  font-family: "Lato", sans-serif;
}

#app {
  font-family: "Lato", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

main div.navigation {
  background: #44a9f8;
  font-size: 20px;
  text-align: left;
  display: flex;
}

main div.navigation ul {
  display: inline-block;
  text-align: left;
}

main div.navigation ul:nth-child(1) {
  width: 75%;
}

main div.navigation ul:nth-child(2) {
  width: 20%;
  text-align: right;
}

main div.navigation li {
  list-style: none;
  display: inline-block;
  margin-right: 3%;
}

main div.navigation ul:nth-child(2) li {
  width: 100%;
}

main div.navigation li a {
  padding: 1%;
  color: white;
  text-decoration: none;
  font-weight: bold;
}

main div.navigation li a:hover {
  text-decoration: underline;
}

main div.navigation li a.active {
  text-decoration: underline;
}

main div.main-content {
  display: flex;
}

main div.main-content .content-navigation {
  width: 20%;
  border-right: 3px solid whitesmoke;
  border-left: 3px solid whitesmoke;
}

main div.main-content .subject-info {
  padding: 1%;
}

main div.main-content .subject-info p {
  font-size: 18px;
}

main .main-content .content-navigation ul {
  margin: 0;
  padding: 0;
}

main div.main-content .content-navigation ul li {
  list-style-type: none;
  padding: 10%;
  font-size: 23px;
  cursor: pointer;
  text-align: left;
}

main div.main-content .content-navigation ul li:hover {
  background: whitesmoke;
}

main div.main-content .content-navigation ul li:active {
  border-right: 5px solid #44a9f8;
}

main div.main-content .content-navigation ul li.active {
  border-right: 5px solid #44a9f8;
}

main div.main-content .content-navigation ul li a {
  color: black;
  text-decoration: none;
}

main .content-info {
  width: 80%;
  padding: 1%;
  font-size: 18px;
  display: block;
}

main .content-info .user-form input {
  padding: 1%;
  width: 25%;
  border: none;
  border-bottom: 1px solid black;
  font-size: 16px;
  font-family: inherit;
}

main .content-info .user-form input:focus {
  background: rgb(255, 248, 198);
}

main .content-info .user-form .form-group {
  margin-bottom: 1%;
}

main .content-info .user-form .form-group img {
  vertical-align: bottom;
}

main .content-info .user-form button {
  padding: 1%;
  background: #44a9f8;
  color: white;
  border: none;
  width: 10%;
  font-size: 16px;
  cursor: pointer;
}

main .content-info .user-links a {
  color: black;
  text-decoration: none;
  font-weight: normal;
  margin: 2%;
}

main .content-info .user-links a:hover {
  color: #44a9f8;
  text-decoration: underline;
}

main .content-info .user-links .active-route {
  color: #44a9f8;
  text-decoration: underline;
}

.btn {
  padding: 1%;
  background: #44a9f8;
  color: white;
  border: none;
  width: 10%;
  font-size: 16px;
  cursor: pointer;
  border: 1px solid white;
  display: block;
  margin: 0 auto;
  margin-top: 1%;
  margin-bottom: 1%;
}

.btn:hover {
  color: #44a9f8;
  background: white;
  border: 1px solid #44a9f8;
  text-decoration: underline;
}

div.form-group {
  margin-top: 1%;
  margin-bottom: 1%;
}

div.form-group input,
option,
select {
  font-size: 18px;
  padding: 1%;
  width: 25%;
  border: none;
  border-bottom: 1px solid black;
  font-size: 16px;
  font-family: inherit;
  text-align: center;
  text-align-last: center;
}

select {
  -webkit-appearance: none;
  -moz-appearance: none;
  text-indent: 1px;
  text-overflow: "";
}
</style>
