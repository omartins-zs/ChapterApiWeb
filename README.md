
<h1 align="center"><img align="left" height="40" width="45" src="https://github.com/devicons/devicon/blob/master/icons/csharp/csharp-plain.svg"><img align="left" src="https://github.com/devicons/devicon/blob/master/icons/dot-net/dot-net-original-wordmark.svg" height="40" width="45" >Chapter Api Web<img align="right" height="40" width="45" src="https://github.com/devicons/devicon/blob/master/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg"><img align="right" height="40" width="45"src="https://github.com/devicons/devicon/blob/master/icons/visualstudio/visualstudio-plain.svg" ></h1>


Criação de uma API seguindo padrões que são utilizados em softwares, como padrao MVC e Boas praticas de desenvolvimento usando C#

 <div align="center">

   <cite align="center">`Projeto feito Passo a Passo com o Tutorial de Api do Senai e Meet`</cite>

</div>

 
   <p align="center">
 🚀 Frameworks 
</p>

  <p align="center">
    <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>

  <img src="https://img.shields.io/badge/NuGet-004880?style=for-the-badge&logo=nuget&logoColor=white"/>

  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white"/>
  </p>

 ## Teste
  
  Documentação e Teste da API - [Swagger](https://swagger.io/)
  
  Decodificaçao de Token e Explicação - [JSON Web Tokens - jwt.io](https://jwt.io/)
  
  <hr>
  
  ### Rodando localmente
  
  Swagger
  > `https://localhost:5001/index.html`

  Insomnia
  > `http://localhost:5000/api/`

<hr/>
  <div align="center">

   <h3 align="center"><i>Documentaçao da Api</em></h3>
   
  ##### Configurado Variables {{URL}} no Postman
   
   <cite align="center">`{{URL}} = http://localhost:3000`</cite>
  
   <img align="center" src="/Documentation-API.png">
</div>
 
## Instrucões do banco de dados e Pacotes do Nuget 


* db.sql -> Banco de dados inicial 
* dbAutores.sql -> Usado para criar Tabela Autores
* dbUsuarios.sql -> Usado para criar Tabela Usuarios

    <hr>

* Microsoft.EntityFrameworkCore.SqlServer -> Para utilizar Migrations SQL
* Swashbuckle.AspNetCore -> Para utilizar o Swagger
* System.IdentityModel.Tokens.Jwt -> Para identificação de JWT
* Microsoft.AspNetCore.Authentication.JwtBearer -> Para Interpretar Autenticação JWT


## Aprendizados

***Diferença de Autenticado e Autorizado***

1º  Exemplo

* **Autenticação:** Verifique a carteira de estudante, significa que ele ou ela pertence à nossa escola ou não.
* **Autorização:** Verifique se o aluno tem permissão para sentar ou não no Laboratório de Programação de Computadores.

2º Exemplo

* **A autenticação** trata da validação da conta do usuário. Este é um usuário válido? Este usuário está cadastrado em nosso aplicativo ?. por exemplo: Login
* **A autorização** trata da validação de acesso do usuário a determinado recurso. Este usuário tem autorização / direito de acessar este recurso? por exemplo: reivindicações, funções


## Correçao de Erros

SQL Server não está em execução [Erro de rede ou específico à instância ao estabelecer conexão com o SQL Server](https://cursos.alura.com.br/forum/topico-erro-de-rede-ou-especifico-a-instancia-ao-estabelecer-conexao-com-o-sql-server-89976)

## 📄 Auxiliar e Docs

* HTTP: Status Code [DevMedia](https://www.devmedia.com.br/http-status-code/41222)
* [Introdução ao Swashbuckle e ao ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio)
* [Exemplos de SELECT](https://docs.microsoft.com/pt-br/sql/t-sql/queries/select-examples-transact-sql?view=sql-server-ver15) 
* [Fazer ALTER na Tabela SSMS](https://docs.microsoft.com/pt-br/sql/relational-databases/tables/add-columns-to-a-table-database-engine?view=sql-server-ver15)
* [Documentação e Habilitar CORS](https://docs.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-5.0)
* Documentação do [Swashbuckle.AspNetCore](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio)
* Sintaxe básica de escrita e formatação no GitHub [README](https://docs.github.com/pt/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)
* [Entendendo sobre Single, SingleOrDefault, First e FirstOrDefault – Linq](https://codigosimples.net/2016/03/28/entendendo-sobre-single-singleordefault-first-e-firstordefault-linq/)
* Documentação [C# e ASP.NET Core - Autenticação e Autorização](https://balta.io/blog/aspnet-core-autenticacao-autorizacao)
* Icones [DevIcons](https://github.com/devicons/devicon/tree/master/icons)


## Dicas

* Atalhos [Snippets de código C#](https://docs.microsoft.com/pt-br/visualstudio/ide/visual-csharp-code-snippets?view=vs-2022)
* Indentar -> ```  Ctrl + K + D ```
* Atalhos de [Completaçao de Codigo](https://www.jetbrains.com/pt-br/resharper/features/code_completion.html) 
* Para fazer Using ->  ``` Ctrl + .  ``` 
* O Preenchimento de código com `Ctrl+Space`
* Usar Atalho do IntelliSense  `prop`  -> Para Criar Atributos do Objeto
