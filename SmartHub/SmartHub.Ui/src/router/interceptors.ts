import Vue from 'vue';
import { AuthResponse } from '@/types/types';

Vue.axios.interceptors.request.use(
  (config) => {
    const localStorageLoginResponse = localStorage.getItem('authResponse');
    if (localStorageLoginResponse === null) {
      return config;
    }
    const authResponse = JSON.parse(localStorageLoginResponse) as AuthResponse;
    if (authResponse.token) {
      config.headers.Authorization = `Bearer ${authResponse.token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);