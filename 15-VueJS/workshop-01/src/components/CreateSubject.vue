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
    <template v-slot:info>
      <div class="form-group">
        <input placeholder="Technology subject..." type="text" id="subject" v-model="subject" />
      </div>
      <div>
        <vue-editor v-model="htmlContent"></vue-editor>
      </div>
      <select name="technologies" id="technologies" v-model="technologyId">
        <option :value="null" selected>Select a technology...</option>
        <option v-for="item in technologies" :key="item.id" :value="item.id">{{ item.name }}</option>
      </select>
      <button class="btn" @click="createSubjectHandler()">Create</button>
      <h3>Content preview</h3>
      <div class="content-preview"></div>
    </template>
  </app-content>
</template>

<script>
import AppContent from "./shared/Content.vue";
import { VueEditor } from "vue2-editor";

export default {
  components: {
    AppContent,
    VueEditor
  },
  props: {
    subjects: {
      type: Array,
      required: true
    },
    technologies: {
      type: Array,
      required: true
    }
  },
  data() {
    return {
      selectedSubjectIndex: 0,
      htmlContent: "",
      technologyId: null,
      subject: ""
    };
  },
  methods: {
    selectSubjectHandler(index) {
      this.selectedSubjectIndex = index;
    },
    createSubjectHandler() {
      const { technologyId, htmlContent, subject } = this.$data;
      this.$emit("create", { technologyId, htmlContent, subject });
      this.htmlContent = "";
      this.technologyId = null;
      this.subject = "";
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

.content-preview {
  text-align: left;
  word-wrap: break-word;
  display: block;
  width: 100%;
}
</style>