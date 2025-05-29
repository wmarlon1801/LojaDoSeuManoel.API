# Loja do Seu Manoel API

Esta API foi desenvolvida para automatizar o processo de embalagem de pedidos para a "Loja do Seu Manoel". Dado um conjunto de pedidos com produtos e suas respectivas dimensões, a API retorna quais caixas devem ser utilizadas para cada pedido e quais produtos serão alocados em cada caixa, buscando otimizar o espaço e minimizar o número de caixas. [cite: 3, 4, 7, 12, 13]

## Pré-requisitos

Para rodar esta aplicação, você precisará ter o [Docker](https://www.docker.com/get-started) instalado em sua máquina. [cite: 15, 16]

## Como Rodar a Aplicação

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/wmarlon1801/LojaDoSeuManoel.API.git](https://github.com/wmarlon1801/LojaDoSeuManoel.API.git)
    ```
2.  **Navegue até o diretório da aplicação:**
    ```bash
    cd LojaDoSeuManoel.API
    ```
3.  **Inicie os containers Docker (API e SQL Server):**
    A aplicação utiliza Docker Compose para orquestrar o serviço da API (.NET Core) e o banco de dados SQL Server. [cite: 14, 15]
    ```bash
    docker-compose up -d
    ```
    Isso construirá as imagens (se necessário) e iniciará os containers em segundo plano.

## Acesso à API e Testes com Swagger

Após iniciar os containers, a API estará disponível no seu localhost. [cite: 16]

* **URL Base da API:** `http://localhost:5000`

Para explorar e testar os endpoints interativamente, acesse o **Swagger UI**: [cite: 16]

* **Swagger UI:** `http://localhost:5000/swagger`

## Endpoints

### Embalagem de Pedidos

* **POST /api/Embalagem/embalar**
    * **Descrição:** Processa um pedido, determina a melhor forma de empacotar os produtos nas caixas disponíveis e retorna a alocação. [cite: 5, 7, 11]
    * **Caixas Disponíveis:**
        * Caixa 1: $30 \times 40 \times 80$ cm [cite: 8]
        * Caixa 2: $80 \times 50 \times 40$ cm [cite: 8]
        * Caixa 3: $50 \times 80 \times 60$ cm [cite: 8]
    * **Corpo da Requisição (JSON - Exemplo de `entrada.json`):** [cite: 9, 10, 14]
        ```json
        {
          "id": "123e4567-e89b-12d3-a456-426614174000",
          "produtos": [
            {
              "id": "prod-001",
              "nome": "Livro",
              "altura": 20.0,
              "largura": 15.0,
              "comprimento": 5.0
            },
            {
              "id": "prod-002",
              "nome": "Caneca",
              "altura": 10.0,
              "largura": 10.0,
              "comprimento": 10.0
            },
            {
              "id": "prod-003",
              "nome": "Placa-mãe",
              "altura": 5.0,
              "largura": 30.0,
              "comprimento": 25.0
            }
          ]
        }
        ```
    * **Resposta (JSON - Exemplo de `saida.json`):** [cite: 13, 14]
        ```json
        {
          "pedidoId": "123e4567-e89b-12d3-a456-426614174000",
          "caixas": [
            {
              "caixaId": "id-da-caixa-1",
              "dimensoes": {
                "altura": 80.0,
                "largura": 50.0,
                "comprimento": 40.0
              },
              "produtos": [
                {
                  "id": "prod-001",
                  "nome": "Livro",
                  "dimensoes": {
                    "altura": 20.0,
                    "largura": 15.0,
                    "comprimento": 5.0
                  }
                },
                {
                  "id": "prod-002",
                  "nome": "Caneca",
                  "dimensoes": {
                    "altura": 10.0,
                    "largura": 10.0,
                    "comprimento": 10.0
                  }
                }
              ]
            },
            {
              "caixaId": "id-da-caixa-2",
              "dimensoes": {
                "altura": 50.0,
                "largura": 80.0,
                "comprimento": 60.0
              },
              "produtos": [
                {
                  "id": "prod-003",
                  "nome": "Placa-mãe",
                  "dimensoes": {
                    "altura": 5.0,
                    "largura": 30.0,
                    "comprimento": 25.0
                  }
                }
              ]
            }
          ]
        }
        ```
---

Lembre-se de substituir o `id` e os dados dos produtos nos exemplos de JSON para corresponder aos tipos de dados reais que sua API espera (por exemplo, `string` para `id` se você usou `Guid`).

Edite o `README.md` no seu repositório GitHub (clicando no lápis) ou localmente e faça um `git commit` e `git push`.