<template>
    <header>
        <nav>
            <router-link to="/">Contact Form</router-link>
            <router-link to="/submissions">View Submissions</router-link>
        </nav>
    </header>

    <main>
        <router-view></router-view>
    </main>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        color: #2c3e50;
        margin: 0;
        padding: 0;
    }

    header {
        background-color: #42b983;
        padding: 1rem;
    }

    nav {
        display: flex;
        justify-content: center;
        gap: 1rem;
    }

        nav a {
            color: white;
            text-decoration: none;
            font-weight: bold;
            padding: 0.5rem 1rem;
            border-radius: 4px;
        }

            nav a.router-link-exact-active {
                background-color: rgba(255, 255, 255, 0.2);
            }

    main {
        padding: 2rem;
        min-height: calc(100vh - 64px);
        box-sizing: border-box;
    }

    body {
        margin: 0;
    }
</style>