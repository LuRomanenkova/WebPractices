<template>
    <div>
        <h2>Brand list</h2>
        <table>
            <tr>
                <th>Name</th>
                <th>Country</th>
            </tr>
            <tr v-for="brand in brands" :key="brand.id">
                <td>
                    <router-link
                        :to="{ name: 'brand', params: { id: brand.id } }"
                    >
                        {{ brand.name }}
                    </router-link>
                </td>
                <td>{{ brand.country }}</td>
            </tr>
        </table>
        <div style="margin-top: 1rem">
            <router-link :to="{ name: 'brand.create' }" style="color: #000000; text-underline-mode: none !important">
                Create new brand
            </router-link>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                brands: []
            }
        },
        mounted() {
            axios.get('http://localhost:8081/api/brands')
                .then(({data}) => {
                    this.brands = data;
                });
        }
    }
</script>

<style scoped>

</style>