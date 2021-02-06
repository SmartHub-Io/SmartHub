/* eslint-disable prettier/prettier */
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { store } from './store';
import IconPlugin from '@/plugins/IconPlugin';
import { client } from './graphql-client';
import urql from '@urql/vue';

import '@/assets/styles/tailwind.scss';

const app = createApp(App)
  .use(urql, client)
  .use(router)
  .use(store)
  .use(IconPlugin);
// app.config.errorHandler((err, vueInstance, vueInfo) => {
//   // send to Sentry e.g
// });
app.config.performance = true;
app.mount('#app');
