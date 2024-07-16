import App from './App.vue'
import { createApp } from 'vue'


const router = createRouter({
    history: createWebHashHistory(),
    routes: [
        {
            path: '/',
            component: App
        }
    ]
})

createApp(App).use(router).mount('#app')
