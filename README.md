# desafio-mt
Desafio técnico .NET Core 9 + Angular 19


### Passo-a-passo

#### PgAdmin 
  1. Criar um novo banco de dados chamado "Desafio"
  2. Criar as credenciais: usuário _admin_ e senha _@dm1n_
  3. Criar a tabela Produto:

> CREATE TABLE Produto ( 
    ID uuid NOT NULL,
    Codigo VARCHAR(4) NOT NULL,
    Descricao VARCHAR(50) NOT NULL,
    DepartamentoId uuid NOT NULL,
    Preco numeric NOT NULL,
    Status boolean NOT NULL,
    PRIMARY KEY (ID)
);

  4. Criar a tabela Departamento:
> CREATE TABLE Departamento
(
    ID uuid NOT NULL,
    Codigo VARCHAR(4) NOT NULL,
    Descricao VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID)
);

  5. Garantir permissões:
> GRANT ALL PRIVILEGES ON TABLE produto TO admin;
> GRANT ALL PRIVILEGES ON TABLE departamento TO admin;

#### Executar o backend

> Abrir a solução no Visual Studio 2022, que a aplicação, com Swagger, se iniciará no endereço: **https://localhost:44353/swagger/index.html**

#### Executar o frontend

> Entrar no diretório principal e entrar com o comando *npm install* e, sem seguida, *ng serve*.
