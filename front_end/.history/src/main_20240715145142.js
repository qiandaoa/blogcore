import App from './App.vue'
import router from "./Router/router.js";
import { createApp } from 'vue'
import api from "./API/http";
import from "element"


createApp(App).use(router).use(api).mount('#app')
