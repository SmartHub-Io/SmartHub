import { Module } from 'vuex';
import { AuthState, RootState } from '@/store/index.types';
import { getters } from '@/store/auth/getters';
import { actions } from '@/store/auth/actions';
import { mutations } from '@/store/auth/mutations';

export const state: AuthState = {
  authResponse: null,
  regStepIndex: 1,
  isSignInBtnClicked: false
};

export const auth: Module<AuthState, RootState> = {
  state,
  getters,
  actions,
  mutations
};
