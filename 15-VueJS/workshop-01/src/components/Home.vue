<template>
  <app-content>
    <template v-slot:nav>
      <ul>
        <li
          :class="{ active: index === selectedSubjectIndex }"
          v-for="(subject, index) in subjects"
          :key="index"
          @click="selectSubjectHandler(index)"
        >
          <a>{{ subject.name }}</a>
        </li>
      </ul>
    </template>
    <template v-slot:info>{{ selectSubject.content }}</template>
  </app-content>
</template>

<script>
import AppContent from "./shared/Content.vue";

export default {
  components: {
    AppContent
  },
  props: {
    subjects: {
      type: Array,
      required: true
    }
  },
  data() {
    return {
      selectedSubjectIndex: 0
    };
  },
  methods: {
    selectSubjectHandler(index) {
      this.selectedSubjectIndex = index;
    }
  },
  computed: {
    selectSubject() {
      return this.subjects[this.selectedSubjectIndex];
    }
  }
};
</script>

<style scoped>
li a {
  cursor: pointer;
}
</style>