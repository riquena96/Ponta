Ol�! 

O projeto foi desenvolvido utilizando banco de dados in-memory, n�o sendo necess�rio a cria��o de um banco.

Para executar o projeto � necess�rio confirmar se o projeto "Ponta.WebApi" est� como definido como
projeto de inicializa��o. 

Ap�s iniciar a depura��o do projeto ser� aberto o swagger com os m�todos dispon�veis.
Dois m�todos apenas s�o p�blicos, sendo o CRUD  de Usuario, Criar e Autenticar um usu�rio.

Instru��es para autenticar-se na API e realizar as opera��es no CRUD  de Tarefas.

1� Passo: Criar um novo usu�rio.
2� Passo: Executar o m�todo para se autenticar, passando o login e senha usados na cria��o do usu�rio.
3� Passo: Pegar o token retornado do m�todo de autenticar e coloca-lo no swagger pelo bot�o
do "Authorize", colocando junto com o token o "Bearer" antes do token.
4� Passo: Ap�s autorizar o swagger com o token, ser� poss�vel executar o CRUD de Tarefas.

Observa��o:
	O status das tarefas � um Enum.
		0: Pendente
		1: Em andamento
		2: Concluida