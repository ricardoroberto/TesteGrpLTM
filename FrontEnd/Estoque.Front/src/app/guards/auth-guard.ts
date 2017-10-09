import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthService } from '../login/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) : boolean {
      if (!this.authService.permiteAcesso(state.url)){
        this.router.navigate(["/login"]);
        return false;
      }
      else{
        return true;
      }
  }

  constructor(private authService: AuthService, private router: Router) { }

}
