import { AuthResponse } from '@/types/types';

type AuthType = { isAdmin: boolean; isUser: boolean; isGuest: boolean };

export const userAuth = (): AuthType => {
  const localStorageLoginResponse = localStorage.getItem('authResponse');
  if (localStorageLoginResponse == null) {
    return { isAdmin: false, isUser: false, isGuest: false };
  }
  const loginResponse = JSON.parse(localStorageLoginResponse) as AuthResponse;
  if (loginResponse.roles.includes('Admin')) {
    return { isAdmin: true, isUser: false, isGuest: false };
  }
  if (loginResponse.roles.includes('User')) {
    return { isAdmin: false, isUser: true, isGuest: false };
  }
  if (loginResponse.roles.includes('Guest')) {
    return { isAdmin: false, isUser: false, isGuest: true };
  }
  return { isAdmin: false, isUser: false, isGuest: false };
};
