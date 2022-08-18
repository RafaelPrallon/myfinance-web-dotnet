# myfinance-web-dotnet
- [myfinance-web-dotnet](#myfinance-web-dotnet)
  - [Sobre](#sobre)
  - [Script Database](#script-database)

## Sobre
MyFinance - Projeto do Curso de Pós-Graduação em Engenharia de Software da PUC-MG

Nesse projeto será utilizada a stack dotnet e maria db.
O script pra a criação das entidades se encontra na sessão [Script Database](#script-database)

<img src="images/db-diagram.png">

## Script Database
create table plano_contas(
	id int not null auto_increment,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table transacao(
	id bigint  not null auto_increment,
	data datetime not null,
	valor decimal(9,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta  int not null,
	primary key(id),
	foreign key(id_plano_conta) references plano_contas(id)
);