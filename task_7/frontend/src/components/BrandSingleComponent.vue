<template>
    <div>
        <div>
            <h2>{{ brand.name }}</h2>
        </div>
        <p>INFO</p>
        <table>
            <tr>
                <td>Country</td>
                <td>{{ brand.country }}</td>
            </tr>
        </table>
        <div style="display: block; margin-top: 1rem">
            <div style="display: inline-block; margin-right: 1rem;">
                <router-link :to="{ name: 'brand.edit', params: { id: brand.id } }">Edit</router-link>
            </div>
            <div style="display: inline-block">
                <button @click="deleteBrand">Delete</button>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                brand: {}
            }
        },
        mounted() {
            axios.get('http://localhost:8081/api/brands/' + this.$route.params.id)
                .then(({data}) => {
                    this.brand = data;
                    localStorage.setItem('B_NAME', data.name);
                    localStorage.setItem('B_COUNTRY', data.country);
                });
        },
        methods: {
            deleteBrand: function () {
                axios.delete('http://localhost:8081/api/brands/' + this.$route.params.id)
                    .then(() => {
                        this.$router.push({ name: 'brands' });
                    });
            }
        }
    }
</script>

<style scoped>

</style>