![alt text](image.png)

# Market Data Service

Este é um dos serviços que compõem a aplicação "WalletProfile", a proposta é capturar dados de mercado utilizando uma API externa e salvar na base de dados do projeto para disponilizar para os outros serviços que compõem o `WalletProfile`.

## Propósito do projeto

Este projeto tem como objetivo exercitar algumas práticas relacionadas ao desenvolvimento de aplicações ASP.NET, desde a modelagem do domínio a implementação utilizando padrões conhecidos no mercado.

🔹 Responsável por:

- Recuperar e salvar dados de mercado
- Disponibilizar os dados via API

🔹 Como funciona:

O cliente solicita as informações de investimento, caso esteja disponível na base de dados, fornece, caso não esteja a aplicação busca em outro serviço, salva internamente e disponibiliza
