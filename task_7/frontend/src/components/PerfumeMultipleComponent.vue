<template>
    <div>
        <h2>Perfume list</h2>
        <table>
            <tr>
                <th>Name</th>
                <th>Brand</th>
                <th>Country</th>
                <th>Volume</th>
                <th>Price</th>
                <th>Count</th>
            </tr>
            <tr v-for="perfume in perfumes" :key="perfume.id">
                <td>
                    <router-link
                        :to="{ name: 'perfume', params: { id: perfume.id } }"
                    >
                        {{ perfume.name }}
                    </router-link>
                </td>
                <td>{{ BRAND_NAME(perfume.brandId) }}</td>
                <td>{{ BRAND_COUNTRY(perfume.brandId) }}</td>
                <td>{{ perfume.volume }}</td>
                <td>{{ perfume.price }}</td>
                <td>{{ perfume.count }}</td>
            </tr>
        </table>
        <div style="margin-top: 1rem">
            <router-link :to="{ name: 'perfume.create' }" style="color: #000000; text-underline-mode: none !important">
                Create new perfume
            </router-link>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
            data() {
                return {
                    perfumes: [],
                    brands: []
                }
            },
            mounted() {
                axios.get('http://localhost:8081/api/perfumes')
                    .then(({data}) => {
                        this.perfumes = data;
                    });
                axios.get('http://localhost:8081/api/brands')
                    .then(({data}) => {
                        this.brands = data;
                    });
            },
            methods: {
                /**
                 * @return {string}
                 */
                BRAND_COUNTRY: function(id) { return this.brands.find(x => x.id === id).country },
                BRAND_NAME: function(id) { return this.brands.find(x => x.id === id).name }
            }
    }
</script>

<style scoped>

</style>