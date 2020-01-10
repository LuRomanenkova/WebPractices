<template>
    <div>
        <div>
            <h2>Edit {{ name }}</h2>
        </div>
        <div>
            <form @submit.prevent="editBrand">
                <input
                        v-model="name"
                        style="margin: 0.5rem"
                        type="text"
                />
                <br>
                <input
                        v-model="country"
                        style="margin: 0.5rem"
                        type="text"
                />
                <br>
                <button type="submit" style="margin: 0.5rem">Edit</button>
            </form>
        </div>
    </div>
</template>

<script>
    import axios from "@/axios";

    export default {
        data() {
            return {
                name: localStorage.getItem('B_NAME'),
                country: localStorage.getItem('B_COUNTRY'),
            }
        },
        mounted() {

        },
        methods: {
            editBrand: function () {
                if (
                    this.country !== null &&
                    this.name !== null
                ) {
                    const name = this.name;
                    const country = this.country;
                    const brand = {
                        Name: name,
                        Country: country,
                    };
                    console.log(brand);
                    axios.put('http://localhost:8081/api/brands/' + this.$route.params.id, brand)
                        .then(() => {
                            this.$router.push({ name: 'brand', params: { id: this.$route.params.id } });
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