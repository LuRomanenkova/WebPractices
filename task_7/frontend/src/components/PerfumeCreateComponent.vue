<template>
    <div>
        <div>
            <h2>Create new perfume</h2>
        </div>
        <div>
            <form @submit.prevent="createPerfume">
                <input
                        placeholder="Name"
                        v-model="perfume.Name"
                        style="margin: 0.5rem"
                        type="text"
                />
                <br>
                <input
                        placeholder="Volume"
                        v-model="perfume.Volume"
                        style="margin: 0.5rem"
                        type="number"
                />
                <br>
                <input
                        placeholder="Price $"
                        v-model="perfume.Price"
                        style="margin: 0.5rem"
                        type="number"
                />
                <br>
                <input
                        placeholder="Count"
                        v-model="perfume.Count"
                        style="margin: 0.5rem"
                        type="number"
                />
                <br>
                <select
                        v-model="perfume.BrandName"
                        style="margin: 0.5rem"
                >
                    <option disabled value="">Select brand</option>
                    <option
                            v-for="brand in brands"
                            :key="brand.id"
                            :value="brand.Name"
                    >
                        {{ brand.Name }}
                    </option>
                </select>
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
                brands: [],
                perfume: {
                    Name: '',
                    BrandName: '',
                    Volume: null,
                    Price: null,
                    Count: null
                }
            }
        },
        mounted() {
            axios.get('http://localhost:8081/api/brands')
                .then(({data}) => {
                    this.brands = data;
                });
        },
        methods: {
            createPerfume: function () {
                if (
                    this.perfume.Name !== '' &&
                    this.perfume.BrandName !== '' &&
                    this.perfume.Volume > 0 &&
                    this.perfume.Price > 0 &&
                    this.perfume.Count > 0
                ) {
                    const name = this.perfume.Name;
                    const brandId = this.brands.find(x => x.Name === this.perfume.BrandName).id;
                    const volume = this.perfume.Volume;
                    const price = this.perfume.Price;
                    const count = this.perfume.Count;
                    const perfume = {
                        "Name": name,
                        "BrandId": brandId,
                        "Volume": volume,
                        "Price": price,
                        "Count": count
                    };
                    console.log(perfume);
                    axios.post('/api/perfumes', perfume)
                        .then(() => {
                            this.$router.push({ name: 'perfumes' });
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