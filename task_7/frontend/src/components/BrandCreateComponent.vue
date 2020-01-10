<template>
    <div>
        <div>
            <h2>Create new brand</h2>
        </div>
        <div>
            <form @submit.prevent="createBrand">
                <input placeholder="Name" v-model="brand.Name" style="margin: 0.5rem"/>
                <br>
                <input placeholder="Country" v-model="brand.Country" style="margin: 0.5rem"/>
                <br>
                <button type="submit" style="margin: 0.5rem">Create</button>
            </form>
        </div>
    </div>
</template>

<script>
    import axios from '../axios';

    export default {
        data() {
            return {
                brand: {
                    Name: '',
                    Country: ''
                }
            }
        },
        methods: {
            createBrand: function () {
                if (this.brand.Name !== '' && this.brand.Country !== '') {
                    const name = this.brand.Name;
                    const country = this.brand.Country;
                    const brand = { "Name": name, "Country": country };
                    console.log(brand);
                    axios.post('/api/brands', brand)
                        .then(() => {
                            this.$router.push({ name: 'brands' });
                        })
                        .catch(({error}) => {
                            console.log(error);
                        });
                }
            }
        }
    }
</script>

<style scoped>

</style>