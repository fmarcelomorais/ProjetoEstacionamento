# DIO - Trilha .NET - Fundamentos

## Desafio de Projeto
 Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO. 

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta do desafio
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:

A classe contém três variáveis, sendo:

precoInicial: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

precoPorHora: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

veiculos: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável veiculos.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: precoInicial * precoPorHora, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:

1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar

## Minha Proposta para desafio
Foram criadas 3 classes modelo:
1. Carro
2. Garagem
3. Pagamento

Foram criadas 3 classes para funcionalidades do sistema
1. Estacionamento
2. Financeiro
3. Funcionalidades

## Contexto
SysPark - Sistema criado para gerenciamento de entrada, pagamento e saída de veiculos no Estacionamento.
O sistema conta com as seguintes funcionalidades:
1. Estacionamento
    - Cadastrar Veiculos
    - Listar Veiculos
    - Pesquisar Veiculo
    - Entrar na Vaga
    - Sair da Vaga
    - Vagas Disponiveis
2. Financeiro
    - Receber Pagamento ( essa funcionalidade está imbutida em Sair da Vaga)
    - Listar Pagamento (Em implementação.)
3. Encerrar

## COMO TESTAR
1. Instale o .Net 8.
2. Faça um clone ou baixe o projeto em sua maquina.
3. Abra o projeto usando o Promp do sistema.
4. Entre na pasta MyPark
5. Execulte o comando dotnet run