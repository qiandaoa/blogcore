// 路由文件,从main.js中抽离出来
import Vue from "vue";
import {createRouter,createWebHashHistory} from "vue-router" // 引用路由
import Home from "../components/home.vue";

const router = createRouter({
    history: createWebHashHistory(),
    routes: [
        {
            path: '/',
            component: Home
        },
    ]
})

export default router;
