# Instruções para Rodar o Projeto com Docker e PostgreSQL

## Requisitos

Certifique-se de que você tenha as seguintes ferramentas instaladas em sua máquina:

- Docker
- Docker Compose
- Um banco de dados PostgreSQL configurado para trabalhar com o projeto
- Um navegador de sua preferência

## Passos para Configuração e Execução

1. **Configurar o Banco de Dados com PostgreSQL**  
   O projeto requer um banco de dados PostgreSQL. Siga os passos abaixo para configurar o ambiente.

2. **Definir os Detalhes da Conexão**  
   A conexão com o banco de dados deve ser configurada com as seguintes informações:

   - **Host**: `0.0.0.0`
   - **Port**: `5432`
   - **Database**: `postgres`
   - **Username**: `postgres`
   - **Password**: `1234`

3. **Clonar o Repositório**  
   Clone o repositório em sua máquina utilizando a [URL](https://github.com/liam-stori/Challenge.git.)

4. **Ligar o Docker**  
   Certifique-se de que o Docker está em execução em sua máquina. Caso ainda não tenha iniciado o Docker, abra o aplicativo Docker Desktop (ou inicie o serviço Docker, se estiver usando Linux) e aguarde até que o Docker esteja pronto para uso.

5. **Subir o Container com Docker Compose**  
   Navegue até o diretório onde você clonou o repositório e abra o terminal e execute o comando `docker-compose up --build` para construir e subir o container do PostgreSQL. Isso irá configurar o banco de dados necessário para o funcionamento do projeto.

   5.1 Caso ocorra alguma falha execute o comando `docker-compose down`, aguarde até ser finalizado e execute novamente `docker-compose up --build`

7. **Acessar o Banco de Dados**  
   Após o container do PostgreSQL (`postgres_app`) estar em execução, acesse o diretório `Migrations` dentro da pasta do repositório clonado. Abra o arquivo `initial_create.sql` e copie todo o conteúdo do script.

8. **Conectar ao Banco de Dados**  
   Acesse o banco de dados PostgreSQL usando as informações de conexão fornecidas e conecte-se ao banco de dados `postgres`.

9. **Executar o Script de Criação do Banco de Dados**  
   No editor de SQL, cole o conteúdo copiado do arquivo `initial_create.sql` e execute o script para criar a estrutura do banco de dados, tabelas e relacionamentos necessários.

10. **Acessar a API via Navegador**  
   Após a configuração do banco de dados, abra seu navegador de preferência e [acesse a URL](http://localhost:8080/swagger/index.html)
 para interagir com a API através da interface Swagger.

Agora você está pronto para utilizar o sistema e interagir com a API diretamente no Swagger.
