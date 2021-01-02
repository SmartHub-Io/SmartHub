import { NavigationGuardNext, RouteLocationNormalized } from 'vue-router';
import { clearStorage, getUserRoles, isAuthenticated } from '@/services/auth/authService';
import { Roles, Routes } from '@/types/enums';

const validateUserRoleToRoute = (to: RouteLocationNormalized, roles: Roles, next: NavigationGuardNext) => {
  if (to.matched.some((record) => record.meta.isAdmin)) {
    if (roles === Roles.Admin) {
      next();
    } else {
      next({ path: Routes.NotAuthorized });
    }
  } else if (to.matched.some((record) => record.meta.isUser)) {
    if (roles === Roles.Admin || roles === Roles.User) {
      next();
    } else {
      next({ path: Routes.NotAuthorized });
    }
  } else if (to.matched.some((record) => record.meta.isGuest)) {
    if (roles === Roles.Admin || roles === Roles.User || roles === Roles.Guest) {
      next();
    } else {
      clearStorage();
      next({ path: Routes.Login });
    }
  }
};

export const useRouteAuthGuard = (
  to: RouteLocationNormalized,
  from: RouteLocationNormalized,
  next: NavigationGuardNext
): void => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    // TODO: BE call machen wenn Token noch im storage ist, wenn der noch gültig ist dann weiter zum dashboard wenn nicht dann einen neuen beantragen
    // Refreshtoken!!!!
    if (!isAuthenticated()) {
      next({ path: Routes.Login });
    } else {
      //  anstatt den authresponse zu nehmen um die rollen zu prüfen
      // TODO: vlt den token nehmen ans BE schicken- prüfen lassen ob es noch valide ist und darauf dann userberechtigungen/authresponse bekommen
      validateUserRoleToRoute(to, getUserRoles(), next);
    }
  } else {
    next();
  }
};
