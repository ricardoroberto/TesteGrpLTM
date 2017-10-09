import { ModuleWithProviders } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'

import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component'
import { LoginAcessoComponent } from './login-acesso/login-acesso.component';
import { AuthGuard } from './guards/auth-guard';

const APP_ROUTES: Routes = [
    { path: 'login', component: LoginComponent},
    { path: '', component: HomeComponent, canActivate: [AuthGuard]},
    { path: 'loginsolicitar', component: LoginAcessoComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES);
