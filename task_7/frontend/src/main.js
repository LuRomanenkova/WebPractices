import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import routes from "@/routes";

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes: routes
});

Vue.config.productionTip = false;

export const app = new Vue({
  el: '#app',
  render: h => h(App),
  router: router
});
