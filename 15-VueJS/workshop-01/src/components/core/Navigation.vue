<template>
  <div class="navigation">
    <ul>
      <li v-for="(item, index) in navItems" :key="item.id">
        <a
          :class="{ active: index === selectedIndex }"
          @click="navItemClickHandler(index)"
        >{{item.name}}</a>
      </li>
    </ul>

    <ul>
      <li>
        <a href="#">SUBJECT [+]</a>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  props: {
    navItems: {
      type: Array,
      required: true
    },
    selectedIndex: {
      type: Number,
      required: true
    }
  },
  methods: {
    navItemClickHandler(index) {
      this.$emit("navigate", index);
    }
  }
};
</script>

<style scoped>
li a {
  cursor: pointer;
  text-transform: uppercase;
}
</style>