import { GetterTree } from 'vuex';
import { AuthResponse } from '@/types/types';
import { RootState, AuthState } from '@/store/index.types';

// Getter Types
export type AuthGetters = {
  getRole(state: AuthState): string[] | undefined;
};

// Define Getters
export const getters: GetterTree<AuthState, RootState> & AuthGetters = {
  getRole(state: AuthState): string[] | undefined {
    return state.authResponse?.roles;
  },
  getAuthResponse(state: AuthState): AuthResponse | null {
    return state.authResponse;
  }
};
