import { Component } from '@angular/core';
import { AuthService } from './login/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  mostrarMenu: boolean = false;

  constructor(private authService: AuthService){

  }

  ngOnInit(){
    this.authService.mostrarProdutoEmmiter.subscribe(
      mostrar => this.mostrarMenu = mostrar
    );
  }
}
