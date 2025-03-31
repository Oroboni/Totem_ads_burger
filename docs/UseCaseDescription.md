# Sistema Totem ADS Burguer

## Caso de Uso 1 – Iniciar Pedido
**Ator Principal**: Cliente

**Objetivo**: Começar o fluxo de pedido.

**Descrição**: O cliente chega em um totem que está na tela inicial e clica no botão “Iniciar Pedido”.

### Fluxo de Eventos Principal:
1.	Cliente chega no Totem.
2.	Cliente clica no botão “Iniciar Pedido”
3.	Sistema redireciona para tela de selecionar pedido.

### Fluxo de Exceção:
•	Cliente inicia em um carrinho abandonado por outro cliente e reseta o carrinho

## Caso de Uso 2 - Realizar Pedido:
**Ator Principal**: Cliente

**Objetivo**: Realizar um pedido de maneira simples e rápida.

**Descrição**: O cliente acessa o totem, escolhe os itens do cardápio, personaliza seu pedido (se necessário), e efetua o pagamento.

### Fluxo de Eventos Principal:
1.	O cliente visualiza o cardápio.
2.	O cliente seleciona os itens desejados.
3.	O cliente personaliza o pedido, se necessário.
4.	O cliente visualiza o valor total e confirma.

### Fluxo de Exceção:
•	Se o pedido não for possível (por falta de estoque, por exemplo), o cliente é informado e pode escolher outro item.

## Caso de Uso 3 – Exibir Carrinho
**Ator Principal**: Cliente

**Objetivo**: Visualizar os produtos que o Cliente pediu.

**Descrição**: Após selecionar os itens desejados, o cliente pode ver os itens no carrinho.

### Fluxo de Eventos Principal:
1.	O Cliente finaliza a seleção de pedidos e clica no carrinho
2.	Ele personaliza os itens (se necessário)
3.	Ele confirma o pedido e procede para pagamento.

## Caso de Uso 4 – Personalizar Pedido
**Ator Principal**: Cliente

**Objetivo**: Personalizar o pedido para se adequar ao gosto do cliente.

**Descrição**: O cliente acessa o carrinho, escolhe os itens específicos, e personaliza o mesmo, tirando ou adicionando itens.

### Fluxo de Eventos Principal:
1.	O cliente seleciona o item que deseja editar.
2.	O cliente personaliza o pedido.
3.	O cliente confirma ou descarta a edição.

### Fluxo de Exceção:
•	Se o pedido não for possível (por falta de estoque, por exemplo), o cliente é informado e pode reeditar o item.

## Caso de Uso 5 – Processar Pagamento
//

## Caso de Uso 6 – Fazer Login
**Ator Principal**: Cliente

**Objetivo**: Permitir que o cliente acesse sua conta no totem.

**Descrição**: O cliente acessa a tela de login do totem, insere suas para acessar funcionalidades personalizadas.

### Fluxo de Eventos Principal:
1.	O cliente acessa a tela de processar pagamento.
2.	O cliente seleciona a opção "Login".
3.	O cliente insere suas credenciais (CPF).
4.	O sistema valida as credenciais.
5.	Se as credenciais forem válidas, o cliente é redirecionado para a tela de cupons da sua conta.

### Fluxo de Exceção:
•	Credenciais inválidas: O sistema informa ao cliente que os dados inseridos estão incorretos e permite tentar novamente.
•	Falha de conexão: O sistema exibe uma mensagem de erro e sugere tentar novamente mais tarde.

## Caso de Uso 7 – Adicionar Cupom
//

## Caso de Uso 8 – Imprimir Nota Fiscal
//
## Caso de Uso 9 – Cadastrar Produto
**Ator Principal**: Administrador

**Objetivo**: Cadastrar os produtos no totem para que os clientes possam visualizar.

**Descrição**: O Administrador cadastra os dados do produto e sua imagem e depois o produto fica disponível para os clientes comprarem

### Fluxo de Eventos Principal:
1.	O administrador acrescenta os dados do produto que deseja acrescentar
2.	O Sistema acrescenta o item
3.	O item passa a ser exibido no totem

### Fluxo de Exceção:
•	Administrador tenta inserir dados incoerentes com o campo (String no preço)

## Caso de Uso 10 – Editar Produto
**Ator Principal**: Administrador

**Objetivo**: Editar os produtos do totem para alterar possiveis erros.

**Descrição**: O Administrador cadastra os dados do produto e sua imagem e depois o produto fica disponível para os clientes comprarem

### Fluxo de Eventos Principal:
1.	O administrador seleciona um produto existente para editar
2.	O Produto é editado.
3.	O Sistema atualiza os dados de exibição do item caso necessário.

### Fluxo de Exceção:
•	Administrador tenta inserir dados incoerentes com o campo (String no preço)

## Caso de Uso 11 – Deletar Produto
**Ator Principal**: Administrador

**Objetivo**: Excluir produtos que não estejam mais no menu ou remover itens errados.

**Descrição**: Exclusão de produtos e faz eles pararem de ser exibidos.

### Fluxo de Eventos Principal:
1.	O Administrador remove o produto desejado.
2.	Sistema remove o produto do totem


