<template>
    <div>
        <div>
            <h2>Edit {{ name }}</h2>
        </div>
        <div>
            <form @submit.prevent="editPerfume">
                <input
                        placeholder="Volume"
                        v-model="volume"
                        style="margin: 0.5rem"
                        type="number"
                />
                <br>
                <input
                        placeholder="Price $"
                        v-model="price"
                        style="margin: 0.5rem"
                        type="number"
                />
                <br>
                <input
                        placeholder="Count"
                        v-model="count"
                        style="margin: 0.5rem"
                        type="number"
                />
                <br>
                <button type="submit" style="margin: 0.5rem">Edit</button>
            </form>
        </div>
    </div>
</template>

<script>
    import axios from '../axios';

    export default {
        data() {
            return {
                name: localStorage.getItem('P_NAME'),
                volume: localStorage.getItem('P_VOLUME'),
                count: localStorage.getItem('P_COUNT'),
                price: localStorage.getItem('P_PRICE')
            }
        },
        mounted() {

        },
        methods: {
            editPerfume: function () {
                if (
                    this.volume > 0 &&
                    this.price > 0 &&
                    this.count > 0
                ) {
                    const volume = this.volume;
                    const price = this.price;
                    const count = this.count;
                    const perfume = {
                        Id: this.$route.params.id,
                        Volume: volume,
                        Price: price,
                        Count: count
                    };
                    console.log(perfume);
                    axios.put('http://localhost:8081/api/perfumes/' + this.$route.params.id, perfume)
                        .then(() => {
                            this.$router.push({ name: 'perfume', params: { id: this.$route.params.id } });
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