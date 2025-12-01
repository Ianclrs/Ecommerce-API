# Ecommerce-API
Um código que simula um Ecommerce, tendo as principais funções, regras de negócio e feito para aprendizado.

Link do Vídeo:
> Um código que simula um E-commerce, permitindo ao usuário fazer compras de determinados produtos.
### Encapsulamento e Validações

# 💽Pré Requisitos:

- Você ter instalado a versão mais recente de **c#.net 9 / um aplicativo de console / json**

- Você estar usando um sistema operacional compatível, porém necessário que você possua o **Visual Studio 2022**.

# 🚀 Instalando <E-commerce_API>

- Para instalar o E-commerce_API, siga estas etapas:

- Abra o navegador e pesquise por Visual Studio 2022 Download.

- <comando_de_instalação> -> Windows

  **1- Instale a versão com o nome comunidade**

  **2- Deve-se executar como administrador o aplicativo**

  **3- Selecione o campo desenvolvimento para desktop com.NET**

  **4- Em seguida clique no botão ''*Instalar*''**

# ☕ Evidencias <E-commerce_API>
- **Incluir Produto**:

 <img width="350" height="350" alt="Image" src="https://github.com/user-attachments/assets/a0b8d0d7-e1ac-410d-90a1-4407055a2f35" />

> Na imagem está incluindo um produto, onde pede o Id, Nome, Quantidade e o Valor do Produto.

- **SubTotal do ItemCarrinho**:

 <img width="350" height="350" alt="Image" src="https://github.com/user-attachments/assets/f1716ce2-cd45-49f4-b033-d33895ba5a7d" />

 > Na imagem está sendo feito o subtotal do ItemCarrinho, onde pede IdItemCarrinho, IdProduto, Quantidade e Preço.

- **ListarClientes**:

<img width="350" height="350" alt="Image" src="https://github.com/user-attachments/assets/a0b8d0d7-e1ac-410d-90a1-4407055a2f35" />

> Na imagem está listando um cliente que estaria no banco de dados e retornando a mensagem de erro.

# 📝 Convenções de Marcação <E-commerce_API>
- **Application** -**DTOs**- *ItemCarrinhoDTO*: linha 2-13.

- **Domain** -**Entidades**- *ItemCarrinho*: linha 10.

- **Domain** -**Helpers**- *Utilitarios*: linha 5, 11, 17, 26, 32, 33, 43.

- **Domain** -**Interface**- *IFrete*: linha 6, 10, 19, 27.

- **Ecommerce-API** -**Controllers**- *CarrinhoController*: linha 24, 31, 35, 39, 48, 53, 57, 70, 74.

- **Ecommerce-API** -**Controllers**- *ClienteController*: linha 46, 50, 59, 67, 71, 75, 91, 95, 99, 108.

- **Ecommerce-API** -**Controllers**- *PedidoController*: linha 12, 22, 28, 32, 40, 48, 58, 62, 68.

- **Ecommerce-API** -**Controllers**- *ProdutosController*: linha 24, 42, 50, 54, 62, 85.

- **Ecommerce-API** -**Services**- *CarrinhoService*: linha 34, 64.

- **Ecommerce-API** -**Service**- *ClienteService*: linha 27, 104.

- **Ecommerce-API** -**Service**- *FreteService*: linha 22, 27, 38, 55.

- **Ecommerce-API** -**Program.cs**: linha 5, 12, 19, 24, 27, 31, 34, 40, 43, 48.

- **Infrastructure** -**Repositorios**- *ProdutoRepositoryJson*: 17, 30, 39.

# 🤝 Colaboradores

Agradecemos as seguintes pessoas que colaboram para este projeto:
- *Ian Carlos de Oliveira Leite* - **06012992**

- *Gustavo Ramos* -**06009333**
 
- *Cristiano Cordeiro* - **06010709**
  
- *Thauã Cerqueira Silva Rezende* - **06010400**

- *Felipe Dario da Silva* - **06009691**

- *Erick Lopes dos Santos Carvalho* - **06010632**

<table>
  <tr>
    <td align="center">
      <a>
        <img src="https://avatars.githubusercontent.com/u/210450237?v=4"
             width="150"
             height="150"
             style="object-fit: cover; border-radius: 50%;"
             alt=""/><br>
        <sub><b>Ian Carlos</b></sub>
      </a>
    </td>
    <td align="center">
      <a>
        <img src="https://avatars.githubusercontent.com/u/136202053?v=4"
             width="150"
             height="150"
             style="object-fit: cover; border-radius: 50%;"
             alt=""/><br>
        <sub><b>Gustavo Ramos </b></sub>
      </a>
    </td>
    <td align="center">
      <a>
        <img src="https://avatars.githubusercontent.com/u/181295241?v=4"
             width="150"
             height="150"
             style="object-fit: cover; border-radius: 50%;"
             alt=""/><br>
        <sub><b>Cristiano Cordeiro </b></sub>
      </a>
    </td>  
    <td align="center">
      <a>
        <img src="https://avatars.githubusercontent.com/u/161505109?v=4"
             width="150"
             height="150"
             style="object-fit: cover; border-radius: 50%;"
             alt=""/><br>
        <sub><b>Thauã Cerqueira </b></sub>
      </a>
    </td>
    <td align="center">
      <a>
        <img src="https://avatars.githubusercontent.com/u/146496842?v=4"
             width="150"
             height="150"
             style="object-fit: cover; border-radius: 50%;"
             alt=""/><br>
        <sub><b>Felipe Dario </b></sub>
      </a>
    </td>
    <td align="center">
      <a>
        <img src="https://avatars.githubusercontent.com/u/229840200?v=4"
             width="150"
             height="150"
             style="object-fit: cover; border-radius: 50%;"
             alt=""/><br>
        <sub><b>Erick Lopes</b></sub>
      </a>
    </td>
</table>
