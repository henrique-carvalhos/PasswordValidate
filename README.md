# Documentação – PasswordValidate

### Tecnologias utilizadas:
	•	VisualStudio 2022
	•	.NET 5.0
	•	Web API do ASP.NET Core
	•	MediatR
	•	FluentValidation
	•	Swagger

### Resolução da aplicação

Na resolução do projeto utilizei arquitetura limpa, separadas por camadas (API, Application e Core), onde a camada API é responsável por receber as requisições, e através do **MediatR** (utilizado via injeção de dependência) ser designada pra seus respectivos **command** e **commandHandler** que estão implementados na camada Application.

Para a  validação da string password, optei por utilizar a biblioteca do **FluentValidation**, onde valido os dados assim que são recebidos pela API, ou seja, assim que o PostPassword recebe a string password ela já é validada, caso não atenda aos requisitos estabelecidos dentro do **PasswordValidator**, ela automaticamente retornará uma **lista com os erros**, e caso a string seja válida, retornará a propriedade **isValid = true** que é acessada a partir do PasswordCommand e PasswordCommandHandler.

### [Informações para a execução da aplicação](https://github.com/henrique-carvalhos/PasswordValidate/blob/master/Frattina%20-%20Guia%20de%20execução%20da%20aplicação.pdf)
