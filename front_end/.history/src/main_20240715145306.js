import App from './App.vue'
import router from "./Router/router.js";
import { createApp } from 'vue'
import api from "./API/http";
imp


createApp(App).use(router).use(api).mount('#app')
