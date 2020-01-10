<template>
    <div>
        <div>
            <h2>{{ perfume.name }}</h2>
        </div>
        <p>INFO</p>
        <table>
            <tr>
                <td>Brand</td>
                <td>{{ BRAND_NAME(perfume.brandId) }}</td>
            </tr>
            <tr>
                <td>Country</td>
                <td>{{ BRAND_COUNTRY(perfume.brandId) }}</td>
            </tr>
            <tr>
                <td>Volume</td>
                <td>{{ perfume.volume }}</td>
            </tr>
            <tr>
                <td>Price</td>
                <td>{{ perfume.price }} $</td>
            </tr>
            <tr>
                <td>Count</td>
                <td>{{ perfume.count }}</td>
            </tr>
        </table>
        <div style="display: block; margin-top: 1rem">
            <div style="display: inline-block; margin-right: 1rem;">
                <router-link :to="{ name: 'perfume.edit', params: { id: perfume.id } }">Edit</router-link>
            </div>
            <div style="display: inline-block">
                <button @click="deletePerfume">Delete</button>
            </div>
        </div>
    </div>
</template>


<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                perfume: {},
                brands: []
            }
        },
        mounted() {
            axios.get('http://localhost:8081/api/perfumes/' + this.$route.params.id)
                .then(({data}) => {
                    this.perfume = data;
                    localStorage.setItem('P_NAME', data.name);
                    localStorage.setItem('P_VOLUME', data.volume);
                    localStorage.setItem('P_COUNT', data.count);
                    localStorage.setItem('P_PRICE', data.price);
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
            BRAND_NAME: function(id) { return this.brands.find(x => x.id === id).name },
            deletePerfume: function () {
                axios.delete('http://localhost:8081/api/perfumes/' + this.$route.params.id)
                    .then(() => {
                        this.$router.push({ name: 'perfumes' });
                    });
            }
        }
    }
</script>

<style scoped>

</style>