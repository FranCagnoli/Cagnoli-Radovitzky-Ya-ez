import { Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { SessionRoutes } from '../routes';

@Injectable({providedIn:'root'})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  public canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const isAdminAllowed = route?.data['isAdminAllowed'] as boolean;
    if (localStorage.getItem('userInfo')) {
      // logged in so return true
      return isAdminAllowed;
    }

    return !isAdminAllowed;
  }
}
