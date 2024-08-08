import { createWebHistory, createRouter } from "vue-router"
import Home from "@/components/HelloWorld.vue"
import Books from "@/components/BookRecords.vue"

const routes = [
    {
        path: "/",
        name: "home",
        component: Home
    },
    {
        path: "/BookRecords",
        name: "BookRecords",
        component: Books

    }
];

const router = createRouter({
    mode: 'history',
    history: createWebHistory(),
    routes
});

export default router;