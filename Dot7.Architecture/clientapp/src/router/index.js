import { createWebHistory, createRouter } from "vue-router"
import Home from "@/components/HelloWorld.vue"
import fetchBooks from "@/components/fetchBooks.vue"

const routes = [
    {
        path: "/",
        name: "home",
        component: Home
    },
    {
        path: "/fetchbooks",
        name: "fetchbooks",
        component: fetchBooks

    }
];

const router = createRouter({
    mode: 'history',
    history: createWebHistory(),
    routes
});

export default router;