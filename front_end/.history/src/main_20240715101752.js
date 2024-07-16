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
