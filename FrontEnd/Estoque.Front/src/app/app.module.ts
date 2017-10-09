import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { routing } from './app.routing';
import { EstoqueProdutoModule } from './estoque-produto/estoque-produto.module';
import { LoginAcessoComponent } from './login-acesso/login-acesso.component';
import { AuthService } from './login/auth.service';
import { AuthGuard } from './guards/auth-guard';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    LoginAcessoComponent
  ],
  imports: [
    BrowserModule,
    routing,
    BsDropdownModule.forRoot(),
    EstoqueProdutoModule,
    FormsModule,
    HttpModule
  ],
  providers: [AuthService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
