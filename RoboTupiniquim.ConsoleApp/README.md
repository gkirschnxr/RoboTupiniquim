# Rob� Tupiniquim

![](https://imgur.com/Fb6vP4X.mp4)

## Introdu��o

Desafio proposto pela Academia do Programador 2025.

## Detalhes

- O usu�rio primeiramente digita a �rea em que o rob� poder� andar;
- O sistema cria uma �rea em m� com base no valor digitado;
- O usu�rio informa a posi��o inicial do rob� (x, y) e a dire��o que o rob� est� olhando (Norte, Sul, Leste, Oeste);
- O sistema valida a posi��o inicial do rob�, garantindo que ele n�o saia da �rea informada;
- O usu�rio informa os comandos que o rob� deve executar (Mover para frente, virar � direita, virar � esquerda);
- O sistema valida os comandos informados pelo usu�rio, garantindo que o rob� n�o saia da �rea informada;
- O sistema exibe a posi��o final do rob� (x, y) e a dire��o que ele est� olhando (Norte, Sul, Leste, Oeste);
- O sistema pergunta ao usu�rio se deseja continuar executando o programa;

## Como utilizar

1. Clone o reposit�rio ou baixe o c�digo fonte;
2. Abra o terminal ou o prompt de comando e navegue at� a pasta raiz;
3. Utilize o comando abaico para restaurar as depend�ncias do projeto.
```
dotnet restore
```
4. Em seguida, compile a solu��o utilizando o comando:
```
dotnet build --configuration Release
```
5. Para executar o projeto compilando em tempo real
```
dotnet run --project RoboTupiniquim.ConsoleApp
```
6. Para executar o arquivo compilado, navegue at� a pasta `./RoboTupiniquim.ConsoleApp/bin/Release/net8.0/` e execute o arquivo:
```
RoboTupiniquim.ConsoleApp.exe
```
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.