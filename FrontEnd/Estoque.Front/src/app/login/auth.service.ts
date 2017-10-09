import { Injectable, EventEmitter } from '@angular/core';
import { UsuarioLogin } from '../models/usuario-login';
import { Router } from '@angular/router';
import { Http,Headers } from '@angular/http';

@Injectable()
export class AuthService {

  private usuarioLogado : boolean = false;
  mostrarProdutoEmmiter = new EventEmitter<boolean>()  
  
  constructor(private router : Router, private http: Http) { }

  fazerLogin(usuario: UsuarioLogin){
    var usuarioSend = {
      username: usuario.nome,
      password: usuario.senha,
      grant_type: "password"
    };
    console.log(JSON.stringify(usuarioSend));
    var headersSend = new Headers();
    headersSend.append("Content-Type", "application/x-www-form-urlencoded");

    var resp = this.http.post("http://localhost:63736/api/token", this.serializeObj(usuarioSend), { 
      headers: headersSend 
    }).subscribe(
      data => { 
        if (data.ok)
        {
          localStorage.setItem("access_token", JSON.parse(data.text()));
          this.usuarioLogado = true;
          this.mostrarProdutoEmmiter.emit(true);
          this.router.navigate(['/produto']);
        }
        else{
          this.router.navigate(['/login']);
          this.mostrarProdutoEmmiter.emit(false);
        }
      },
      err => { console.log(err); },
    );
  }
  
  private serializeObj(obj) {
    var result = [];
    for (var property in obj)
        result.push(encodeURIComponent(property) + "=" + encodeURIComponent(obj[property]));

    return result.join("&");
  }

  permiteAcesso(caminhoRota:string){
    return this.usuarioLogado;
  }
}
