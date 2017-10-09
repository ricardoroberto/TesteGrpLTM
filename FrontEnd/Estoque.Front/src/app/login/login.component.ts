import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { UsuarioLogin } from '../models/usuario-login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario : UsuarioLogin = new UsuarioLogin();

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  fazerLogin(){
    this.authService.fazerLogin(this.usuario);
    //console.log(this.usuario);
  }
}
