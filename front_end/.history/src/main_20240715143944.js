import App from './App.vue'
import router from "./Router/router";
import { createApp } from 'vue'
import api from "./API/http";


createApp(App).use(router).use(api).mount('#app')
