import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import ContactForm from './components/ContactForm.vue'
import SubmissionsList from './components/SubmissionsList.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', component: ContactForm },
        { path: '/submissions', component: SubmissionsList }
    ]
})

const app = createApp(App)
app.use(router)
app.mount('#app')
