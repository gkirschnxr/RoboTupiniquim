# Robô Tupiniquim

![](https://imgur.com/Fb6vP4X.mp4)

## Introdução

Desafio proposto pela Academia do Programador 2025.

## Detalhes

- O usuário primeiramente digita a área em que o robô poderá andar;
- O sistema cria uma área em m² com base no valor digitado;
- O usuário informa a posição inicial do robô (x, y) e a direção que o robô está olhando (Norte, Sul, Leste, Oeste);
- O sistema valida a posição inicial do robô, garantindo que ele não saia da área informada;
- O usuário informa os comandos que o robô deve executar (Mover para frente, virar à direita, virar à esquerda);
- O sistema valida os comandos informados pelo usuário, garantindo que o robô não saia da área informada;
- O sistema exibe a posição final do robô (x, y) e a direção que ele está olhando (Norte, Sul, Leste, Oeste);
- O sistema pergunta ao usuário se deseja continuar executando o programa;

## Como utilizar

1. Clone o repositório ou baixe o código fonte;
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz;
3. Utilize o comando abaico para restaurar as dependências do projeto.
```
dotnet restore
```
4. Em seguida, compile a solução utilizando o comando:
```
dotnet build --configuration Release
```
5. Para executar o projeto compilando em tempo real
```
dotnet run --project RoboTupiniquim.ConsoleApp
```
6. Para executar o arquivo compilado, navegue até a pasta `./RoboTupiniquim.ConsoleApp/bin/Release/net8.0/` e execute o arquivo:
```
RoboTupiniquim.ConsoleApp.exe
```
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.