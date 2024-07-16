import App from './App.vue'
import router from "./Router/router";
import { createApp } from 'vue'
import api from "./API/"
createApp(App).use(router).mount('#app')
