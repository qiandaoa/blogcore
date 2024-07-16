import App from './App.vue'
import Vue from "vue";
import router from "./Router/router";
import { createApp } from 'vue'

createApp(App).use(router).mount('#app')
