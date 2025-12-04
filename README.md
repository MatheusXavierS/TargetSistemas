# Target Sistemas -- Desafios Técnicos em CSharp
Aplicação desenvolvida em **C#** para resolver três desafios
técnicos práticos, envolvendo:

Regras de negócios\
Manipulação de arquivos JSON\
Operações de estoque\
Registro de movimentações\
Cálculo financeiro com juros\
Boas práticas de POO e separação de responsabilidades

------------------------------------------------------------------------

## Estrutura do Projeto

     TargetSistemas.Desafios
     ┣  Models
     ┃ ┣ Produto.cs
     ┃ ┣ Movimentacao.cs
     ┃ ┣ MovimentacaoData.cs
     ┃ ┣ Venda.cs
     ┃ ┣ VendasRoot.cs
     ┃ ┗ EstoqueRoot.cs
     ┣  Services
     ┃ ┣ EstoqueService.cs
     ┃ ┣ VendaService
     ┃ ┗ MovimentacaoService.cs
     ┣  Desafios
     ┃ ┣ Desafio1.cs
     ┃ ┣ Desafio2.cs
     ┃ ┗ Desafio3.cs
     ┣ estoque.json
     ┣ vendas.json
     ┣ movimentacao.json
     ┗ Program.cs

------------------------------------------------------------------------

## Desafios Implementados

### Desafio 1 --- Operações com Estoque

Leitura, atualização e validação de valores no arquivo **estoque.json**.

### Desafio 2 --- Registro de Movimentações

Cada movimentação é armazenada em `movimentacao.json` com ID, data,
quantidade e descrição.

### Desafio 3 --- Cálculo de Juros

Permite inserir data no formato **dd/MM/yyyy** e calcula juros de **2,5%
ao dia**.

------------------------------------------------------------------------

## Tecnologias Utilizadas

-   C#
-   .NET Console App
-   System.Text.Json
-   POO (Programação Orientada a Objetos)

------------------------------------------------------------------------

## Como Executar

``` bash
git clone https://github.com/MatheusXavierS/TargetSistemas.git
dotnet run
```

------------------------------------------------------------------------

## JSONs Exemplos

### estoque.json

``` json
{
  "Estoque": [
    {
      "codigoProduto": 101,
      "descricaoProduto": "Caneta Azul",
      "estoque": 150
    }
  ]
}
```

### movimentacao.json

``` json
{
  "Movimentacoes": []
}
```

------------------------------------------------------------------------

## Aprendizados

-   Boas práticas de separação de camadas\
-   Operações com JSON\
-   Validação de entrada do usuário\
-   Cálculos financeiros

