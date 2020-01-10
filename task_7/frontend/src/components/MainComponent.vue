<template>
    <div>
        <h1>Welcome HOME!</h1>
        <div style="display: block">
            <div style="display: inline-block; margin-right: 1rem;">
                <router-link :to="{ name: 'perfumes' }">Perfumes</router-link>
            </div>
            <div style="display: inline-block">
                <router-link :to="{ name: 'brands' }">Brands</router-link>
            </div>
        </div>
        <div>
            <router-view/>
        </div>
    </div>
</template>

<script>
    export default {
        name: "MainComponent"
    }
</script>

<style scoped>

</style>