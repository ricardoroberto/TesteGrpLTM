# Aplicativo utilizando Angular 2 + WebApi + Autenticação 

# Introdução

Foi criado um aplicativo de controle de estoque.
Ele não está funcionalmente completo (por enquanto) devido ao tempo necessário para completá-lo.


# Back-End

No back-end foi utilizado C# (não Core) com OWIN, Claims e geração de JWT.  
O aplicativo utiliza DDD com injeção de dependência através de Ninject. Optei por não usar o pattern de Specification pois aumentaria a complexidade. Ao invés disso, os prórios DTO´s validam a si mesmos.
Para acesso a dados, devido ao uso do DDD, criei uma camada de acesso a dados intercambiável. Permitindo o uso de SQL Server ou MongoDB. Bastando configurar o aplicativo. Desta maneira aproveitamos a injeção de dependência e a possibilidade de implementar os mesmos repositórios de maneiras diferentes sem afetar o funcionamento do aplicativo como um todo.
Iniciei a criação da camada de serviços com TDD, porém abandoei a ideia devido ao tempo restrito. Mantive a camada, mas vazia.

Para testar apenas a API:
Se executar um POST na url local /token informando :
username: ricardroberto
password: 123456


# Front-End

No front-end utilizei Visual Studio Code para codificar com Angular 2, Bootstrap 3, etc.
Foi criado um módulo EstoqueProduto com Rotas filhas para melhor organização.
Utilizei CanActivate nas rotas obtendo as permissões de acesso do servidor com o token obtido. Tem como diminuir o trafego e diminuir as chamadas, mas no momento mantive desta forma.


