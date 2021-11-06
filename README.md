<h1 align="center">Sistema Todo (API)</h1>
<h4 align="center">Aplicação responsável pela persistência e pelo acesso a dados do sistema Todo (confira <a href="https://github.com/Doug-Vitor/Todo-Web/">aqui</a>). Contém um CRUD simples apenas para introdução à criação de API's RESTful.</h3>

<br/>
<p>:warning: É interessante utilizar a <a href="https://github.com/Doug-Vitor/Todo-Web/">esta Aplicação Web</a> (cliente dessa API) para um melhor proveito deste projeto. Certifique-se de ler os requisitos deste projeto e do projeto citado antes de testar.<p>

<br/>
<h3>:computer: Tecnologias utilizadas:</h3>
<h4>
 <ul>
  <li>DotNET 5.0</li>
  <li>SQL Server</li>
  <li>Entity Framework Core</li>
  </ul>
</h4>

<br/>
<h3>:wrench: Quer rodar o projeto? Siga os passos:</h3>
<h4>
 <ul><li>É necessário instalar o Visual Studio 2019 ou Visual Studio Code e SQL Server</li></ul>
 
 <br/>
 <ol>
  <li>Faça o download ou clone o projeto.</li>
  <li>Abra o arquivo de solução chamado TodoApi.sln</li>
  <li>No arquivo appsettings.json (projeto TodoApi.Application), altere o endereço de conexão em "Default" para sua conexão local. Queira utilizar:
   <blockquote>
    "ConnectionStrings": { 
     <p>"Default": "Server=NomeDoSeuServidor;DATABASE=Todos;Trusted_Connection=True;MultipleActiveResultSets=True"</p>
    }
   </blockquote>
  </li>
  <li>Restaure os pacotes NuGet da solução:
   <ul>
    <p>Pelo CLI: <blockquote>dotnet restore</blockquote></p>
    <p>Pelo CLI do NuGet: <blockquote>nuget restore TodoApi.sln</blockquote></p>
   </ul>
  </li>
  
  <li>Abra o Console de Gerenciador de Pacotes do Nuget e execute o seguinte comando para criar e restaurar as tabelas do banco de dados:<blockquote>Update-Database</blockquote></li>
 </ol>
</h4>

<br/>
<h3>O que aprendi neste projeto:</h3>
<h4>
 <ul>
  <li>Criação de uma API respeitando os conceitos da arquitetura RESTful.</li>
  <li>Introdução à criação de testes unitários e de integração.</li>
 </ul>
</h4>

<br/>
<h3>Referências:</h3>
<ul>
  <li>Projeto referência: <a href="https://github.com/dotnet-architecture/eShopOnWeb">Clique aqui</a></li>
</ul>









