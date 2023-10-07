Olá! 

O projeto foi desenvolvido utilizando banco de dados in-memory, não sendo necessário a criação de um banco.

Para executar o projeto é necessário confirmar se o projeto "Ponta.WebApi" está como definido como
projeto de inicialização. 

Após iniciar a depuração do projeto será aberto o swagger com os métodos disponíveis.
Dois métodos apenas são públicos, sendo o CRUD  de Usuario, Criar e Autenticar um usuário.

Instruções para autenticar-se na API e realizar as operações no CRUD  de Tarefas.

1º Passo: Criar um novo usuário.
2º Passo: Executar o método para se autenticar, passando o login e senha usados na criação do usuário.
3º Passo: Pegar o token retornado do método de autenticar e coloca-lo no swagger pelo botão
do "Authorize", colocando junto com o token o "Bearer" antes do token.
4º Passo: Após autorizar o swagger com o token, será possível executar o CRUD de Tarefas.

Observação:
	O status das tarefas é um Enum.
		0: Pendente
		1: Em andamento
		2: Concluida