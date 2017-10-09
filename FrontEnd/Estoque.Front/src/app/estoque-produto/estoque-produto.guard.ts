import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthService } from '../login/auth.service';

@Injectable()
export class EstoqueAuth implements CanActivateChild {

  canActivateChild(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) : boolean {
      if (!this.authService.permiteAcesso("")){
        this.router.navigate(["/login"]);
        return false;
      }
      else{
        return true;
      }
  }

  constructor(private authService: AuthService, private router: Router) { }

}