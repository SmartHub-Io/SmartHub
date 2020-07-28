import { NavigationGuardNext, RouteLocationNormalized } from 'vue-router';
import { getAuthResponse, isAuthenticated } from '@/services/auth/authService';

const validateUserRoleToRoute = (to: RouteLocationNormalized, roles: string[], next: NavigationGuardNext) => {
  if (to.matched.some((record) => record.meta.isAdmin)) {
    if (roles.includes('Admin')) {
      next();
    } else {
      next({ path: '/notauth' });
    }
  } else if (to.matched.some((record) => record.meta.isUser)) {
    if (roles.some((role) => role === 'Admin' || role === 'User')) {
      next();
    } else {
      next({ path: '/notauth' });
    }
  } else if (to.matched.some((record) => record.meta.isGuest)) {
    if (roles.some((role) => role === 'Admin' || role === 'User' || role === 'Guest')) {
      next();
    } else {
      next({ path: '/notauth' });
    }
  }
};

export const useRouteAuthGuard = (to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (!isAuthenticated()) {
      next({ name: 'Login' });
    } else {
      // TODO: anstatt den authresponse zu nehmen un die rollen zu prüfen
      // vlt den token nehmen ans BE schicken- prüfen lassen und darauf dann userberechtigungen bekommen
      const authResponse = getAuthResponse();
      if (authResponse === null) {
        next({ name: 'Login' });
      } else {
        validateUserRoleToRoute(to, authResponse.roles, next);
      }
    }
  } else {
    next();
  }
};
