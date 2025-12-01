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

 <img width="350" height="350" alt="Image" src="https://private-user-images.githubusercontent.com/210450237/520547706-a0b8d0d7-e1ac-410d-90a1-4407055a2f35.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjQ1NDk4NjEsIm5iZiI6MTc2NDU0OTU2MSwicGF0aCI6Ii8yMTA0NTAyMzcvNTIwNTQ3NzA2LWEwYjhkMGQ3LWUxYWMtNDEwZC05MGExLTQ0MDcwNTVhMmYzNS5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMjAxJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTIwMVQwMDM5MjFaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1lOTRkYmIxMzA2NzFlNzI2YmQzNzI2M2Q1OTM5N2MxYjQ2ZjY3NjU3NDhkZGEyYjUyMjYxNmU2YjQyYjRhZGJkJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.dmPI6n2JZswSf18Pu1hZHwBo7x4E__vbHOGrIsK3adA" />

 - Na imagem está incluindo um produto, onde pede o Id, Nome, Quantidade e o Valor do Produto.

- **SubTotal do ItemCarrinho**:

 <img width="350" height="350" alt="Image" src="https://private-user-images.githubusercontent.com/210450237/520548686-f1716ce2-cd45-49f4-b033-d33895ba5a7d.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjQ1NTA0NzgsIm5iZiI6MTc2NDU1MDE3OCwicGF0aCI6Ii8yMTA0NTAyMzcvNTIwNTQ4Njg2LWYxNzE2Y2UyLWNkNDUtNDlmNC1iMDMzLWQzMzg5NWJhNWE3ZC5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMjAxJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTIwMVQwMDQ5MzhaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1kNTJlM2QxZDVmODEzN2NmOTdlNzU4ZTkxNjkxODlmNThkMTZhYTA2NDU1YTAyN2M2M2E3YWIxZjExZDhmNDAyJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.hzs80WBpHf7O9WPLOpvCvj1MaZqBBD26NZ6oPEzzogY" />

 - Na imagem está sendo feito o subtotal do ItemCarrinho, onde pede IdItemCarrinho, IdProduto, Quantidade e Preço.

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
