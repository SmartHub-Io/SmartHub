import { AppConfig, AuthResponse, Device, Group, User } from '@/types/types';

export interface RootState {
  authModule: AuthState;
  appModule: AppState;
  userModule: UserState;
}

/*
  State for all users without myself
*/
export interface UserState {
  user?: User;
}

/*
  State for the home data
*/
export interface AppState {
  groups?: Group[];
  devices?: Device[];
  appConfig?: AppConfig;
}

/*
  State for all identity information with my own user data
*/
export interface AuthState {
  authResponse?: AuthResponse;
  Me?: User;
}
