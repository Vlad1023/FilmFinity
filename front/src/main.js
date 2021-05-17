import './element-variables.scss';

import App from './App.vue';
import ElementUI from 'element-ui';
import Vue from 'vue';
import VueSweetalert2 from 'vue-sweetalert2';
import i18n from './plugins/i18n';
import router from '@router';
import store from '@store';
import api from '@apiService';
import filters from '@filters';
import Meta from 'vue-meta';
import 'sweetalert2/dist/sweetalert2.min.css';
Vue.use(Meta);

Vue.use(ElementUI);
Vue.use(filters);
Vue.use(VueSweetalert2);

Vue.config.productionTip = false;

Vue.prototype.$http = api;

const token = localStorage.getItem('token');
if (token) {
  Vue.prototype.$http.defaults.headers.common.Authorization = token;
}

new Vue({
  router,
  store,
  i18n,
  api,
  created () {
    this.$store.commit('locale/INIT_LANGUAGE');
  },
  render: h => h(App)
}).$mount('#app');
