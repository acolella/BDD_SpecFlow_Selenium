#language: pt-br

Funcionalidade: Login

    Como um cliente
	Desejo realizar o login na aplicação
	Assim posso ver o histórico das minhas ultimas passagens compradas

Cenário: 1) Quando o cliente realizar o login, as inforamções devem ser exibidas
		 Dado Um visitante não cadastrado acessar a tela de login
	     Quando Preencher todos os campos de login
	   		| CPF           | Senha |
			| 1234567898    | 12346 |
	     Entao será apresentado a mensagem de erro "Erro"
