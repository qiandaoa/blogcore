import App from './App.vue'
import { createApp } from 'vue'
import { createRouter, createWebHashHistory } from "vue-router"

const router = createRouter({
    history: createWebHashHistory(),
    routes: [
        {
            path: '/',
            component: App
        },

    ]
})

createApp(App).mount('#app')
import App from './App.vue'
import router from "./Router/router";
import { createApp } from 'vue'

createApp(App).use(router).mount('#app')
