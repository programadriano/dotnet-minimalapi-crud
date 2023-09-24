## Exemplo de API de Controle de Ações

Esta é uma aplicação de exemplo que demonstra como criar uma API de controle de ações usando .NET 8 Minimal API. 
Esta API permite que você realize operações básicas de criação, leitura, atualização e exclusão de informações de ações.

### Endpoints da API

A API possui os seguintes endpoints:

* GET /stocks: Retorna uma lista de todas as ações registradas.
* GET /stocks/{id}: Retorna detalhes de uma ação específica com base em seu ID.
* POST /stocks: Cria uma nova ação.
* PUT /stocks/{id}: Atualiza os detalhes de uma ação existente com base em seu ID.
* DELETE /stocks/{id}: Exclui uma ação com base em seu ID.

Os endpoints de GET estão utilizando uma das novidades do .NET o CacheOutput

### Documentação Swagger

Esta API inclui uma documentação Swagger para facilitar o entendimento e o teste dos endpoints. Você pode acessar a documentação do Swagger em `https://localhost:5001/swagger`.

### Modelo de Dados

A entidade Stock possui os seguintes campos:

* Id: Um identificador único para cada ação.
* Symbol: O símbolo da ação.
* Action: A ação associada (compra ou venda).
* Quantity: A quantidade de ações envolvidas na operação.







