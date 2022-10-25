# Desafio - ACT

    Descritivo

    Um comerciante precisa controlar o seu fluxo de caixa diario 
    com os lançamentos (debitos e creditos), também precisa de um 
    relatorio que disponibilize o saldo diario consolidado.

    Requisitos de negócio

        Serviço que faça o controle de lançamentos
        Servico que gera relatorio do tipo consolidado diário

    Requisitos Tecnicos

    * Desenho da Solução
    * Pode ser feito na linguagem que voce domina
    * Boas praticas são bem vindas (Design Patterns, Padrões de arquitetura, SOLID e etc)
    * Readme com instruções de como subir a aplicação local, container e utilização dos serviços
    * Hospedar em repositorio publico (Github) 

    Dicas
    - criar teste unitário, 
    - usar abstrações e exceções da forma correta, 
    - aplicar conceitos e padrões de REST e Minimal API etc.

    Tecnologias:

    Swagger
    Apis Rest
    Arquitetura de linguagem monolítica
    Microsserviços
    Docker (Conteinerização e aplicações).
    Git
    .net core
    .net/Web Api, WCF, Log4Net e Nhibernate

    Levantamentos de requisitos funcionais não funcionais e não funcionais

    Intermediário:

    Docker
    Kafka/RabbitMQ
    Bancos de dados MySQL, Oracle, ou SQL Server
    Ferramenta de monitoração

## Pontos observados

    Arquitetura
    Infraestrutura
    Design patterns
    SOLID
    Minimal API
    Plano de testes
    Documentação

## Requisitos

### Definições

    Enuciado:

    Ampliando o enunciado do desafio, definiu-se que o comerciante compra e vende NFTs, um produto digital representado por um token associado a um ativo digital.

    Foi utlizado o conceito de carteira (wallet) para representar o caixa do comerciante de NFTs.

    Será necessario para a movimentação da carteira as funções de lançamentos do tipo credito e tipo debito, neste ponto define-se, lançamento do tipo Credito e Debito.

    Ator:
            Comerciante, responsavel pelo uso da aplicação para o registro da movimentação de compra e venda de NFTs.

    Sistemas : 
                App, responsavel pela entrada de dados do ator
                Servicos, e composto de dois serviços, lançamento e consolidado. 
                Gateway, gerenciamento das apis
                Api, responsavel pela implementação dos serviços.
                Mensageria, responsavel pela comunicação entre App e Api        
    
    Informações dos NFTs:

            Nome do nft,
            Descriçao do nft,
            Chave do NFT,
            Tipo do lançamento,
            Valor, 
            Data e hora do lançamento.

    A carteira não poderá ter saldo negativo.

    Na ocorrencia de um lançamento do tipo debito deve-se verificar se existe saldo suficiente 
    para que o lançamento seja realizado, caso o valor do saldo seja menor que o de debito, 
    deve ser informado ao ator e o lançamento não realizado.  

    Consolidado diario: 
        Lista dos lançamentos do tipo credito e lançamentos do tipo debito realizados no intervalo de 24 horas, informando o total dos dois tipos de lançameto e o saldo.

    Saldo:
         Obtido da diferença da soma dos lançamentos do tipo credito menos os lançamento do tipo debito.   

    Regras: 
        A cada lançamento do tipo debito deve ser verificado o saldo para que o lançamento seja efetivado.

         Caso o valor do saldo seja menor que o valor do debito, uma msg deve ser apresentada informando o saldo e a impossibilidade de efetuar o lançamento.

         A cada lançamento seja do tipo debito ou credito uma mensagem de confirmação da efetividade do lançamento deve ser emitida. 

## Plano de testes

    Utilização do pattern Page Object para a elaboração dos testes.
    Utilização de testes unitarios
    Testes integrados 

### Casos de testes

    Abrir a carteira
    Efetuar lançamento do tipo credito na carteira
    Efetuar lançamento do tipo debito na carteira com saldo negativo
    Efetuar lançamento do tipo debito na carteira com saldo positivo
    Obter o consolidado do periodo diario.
    Obter o consolidado em um periodo definido.

## Desenvolvimento

    IDEs
    Frameworks

    - Criação do projeto central
        Solução 
        - Elaboração da arquitetura
            Design
        - Testes
            Tests
        - Infraestrutura
            Midleware - Kafka
        - Api-Serviços
            Lancamento
            Consolidado
        - Aplicação

## Implementando

    git init --initial-branch=main
    git remote add origin https://github.com/jsaribeiro123/NFT.git
    git add .
    git commit -m "Abertura do projeto"
    git push -u origin main 
    
    * Design
    
    npm i -g c4builder
    c4builder 
    c4builder site    

    O Modelo C4 define quatro níveis de diagramas:

    Contexto(L1):   nível mais alto, mostra como o sistema se relaciona 
                    com os usuários e outros sistemas.
                    Ele é usado como uma introdução rápida ao sistema, 
                    geralmente destinado a ser apresentado às partes interessadas, 
                    este é o diagrama geral.
    Container(L2):  divide o sistema em containers inter-relacionados, 
                    containers são subsistemas executáveis ​​e implementáveis. 
                    Destina-se a ser compartilhado com pessoas que precisam de 
                    mais detalhes técnicos sobre como o sistema é composto.
    Componente(L3): pega os contêineres e os decompõe em componentes inter-relacionados, 
                    relaciona-os com outros contêineres ou outros sistemas. 
                    Ele deve ser lido por engenheiros
                    não familiarizados com o sistema que planejam trabalhar nele.
    Código(L4):     fornece mais detalhes sobre como o código real está sendo implementado. 
                    Destina-se a exibir claramente alguns detalhes concretos
                    sobre as peças mais complexas do sistema.

    Relações
        Representando dependências ou fluxo de dados entre elementos de abstração

    The existing .NET ecosystem built extensibility around 
            IServiceCollection, 
            IHostBuilder,  
            IWebHostBuilder. 

    These properties are available on 
            WebApplicationBuilder as Services, Host, and WebHost.
            WebApplication implements both 
                Microsoft.AspNetCore.Builder.IApplicationBuilder and 
                Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.

Fluxo
    Setup
        criar topico lancamento
        criar topico relatorio
        criar banco de dados

    - post
    api/producer/lancamento/debito 
    registra mensagem de um lancamento do tipo Debito no topico lancamento
        
    - post
    api/producer/lancamento/credito
    registra mensagem de um lancamento do tipo Credito no topico lancamento
        
    - post
    api/producer/report/diario 
    registra mensagem de pedido de relatorio do tipo diario no topico consolidado
        
    - get
    api/producer/report 
    registra mensagem de pedido de relatorio
        
    - get
    api/consumer/lancamento 
    obtem as mensagens do topico lancamento
        
    - get
    api/consumer/relatorio 
    obtem as mensagens do topico relatorio
        

    dotnet new sln
    
    dotnet new web   -o .\Api\Producer\Lancamento   -n  Api.Producer.Lancamento
    dotnet new xunit -o .\Tests\Producer\Lancamento -n  Api.Producer.Lancamento.Test

    dotnet add          .\Tests\Producer\Lancamento\Api.Producer.Lancamento.Test.csproj reference \Api\Producer\Lancamento\Api.Producer.Lancamento.csproj
   
    dotnet sln add      .\Tests\Producer\Lancamento\Api.Producer.Lancamento.Test.csproj
    dotnet sln add      .\Api\Producer\Lancamento\Api.Producer.Lancamento.csproj

    dotnet new web -o   .\Api\Producer\Report  -n Api.Producer.Report
    dotnet new xunit -o .\Tests\Producer\Report -n Api.Producer.Report.Test

    dotnet add          .\Tests\Producer\Report\Api.Producer.Report.Test.csproj reference .\Api\Producer\Report\Api.Producer.Report.csproj

    dotnet new web -o   .\Api\Consumer\Lancamento -n  Api.Consumer.Lancamento
    dotnet new xunit -o .\Tests\Consumer\Lancamento -n  Api.Consumer.Lancamento.Test

    dotnet add          .\Tests\Consumer\Lancamento\Api.Consumer.Lancamento.Test.csproj reference .\Api\Consumer\Lancamento\Api.Consumer.Lancamento.csproj

    dotnet sln add      .\Tests\Consumer\Lancamento\Api.Consumer.Lancamento.Test.csproj
    dotnet sln add      .\Api\Consumer\Lancamento\Api.Consumer.Lancamento.csproj

    dotnet new web -o   .\Api\Consumer\Report  -n Api.Consumer.Report
    dotnet new xunit -o .\Tests\Consumer\Report -n Api.Consumer.Report.Test

    dotnet add          .\Tests\Consumer\Report\Api.Consumer.Report.Test.csproj reference .\Api\Consumer\Report\Api.Consumer.Report.csproj

    dotnet sln add      .\Tests\Consumer\Report\Api.Consumer.Report.Test.csproj
    dotnet sln add      .\Api\Consumer\Report\Api.Consumer.Report.csproj

    dotnet new webapp -o App-Nft
    dotnet watch run

    docker-compose -f docker-compose.yml -f docker-compose-test.override.yml up -d ./run_unit_tests
    docker-compose -f docker-compose.yml -f docker-compose-test.override.yml down

    dotnet tool uninstall --global dotnet-aspnet-codegenerator
    dotnet tool install --global dotnet-aspnet-codegenerator
    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.SQLite
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer

    dotnet aspnet-codegenerator razorpage -m Lancamento -dc RazorAppNftContext -udl -outDir Pages/Lancamentos --referenceScriptLibraries -sqlite

    dotnet tool install --global dotnet-ef
    dotnet ef migrations add InitialCreate
    dotnet ef database update

    dotnet aspnet-codegenerator razorpage -m Report -dc RazorAppNftContext -udl -outDir Pages/Reports --referenceScriptLibraries -sqlite

## Resultado Esperado

    Prototipo para um mvp

## Resultados Obtidos

    * ASP.NET Web API application
    * REST API principles, CRUD operations
    * Redis database connection and containerization
    * Consume Discount Grpc Service for inter-service sync communication to calculate product final price
    * Publish BasketCheckout Queue with using MassTransit and RabbitMQ
    * ASP.NET Core Web API application 
    * REST API principles, CRUD operations
    * MongoDB database connection and containerization
    * Repository Pattern Implementation
    * Swagger Open API implementation

## Microservices Communication

    * Sync inter-service gRPC Communication
    * Async Microservices Communication with RabbitMQ Message-Broker Service**
    * Using RabbitMQ Publish/Subscribe Topic Exchange Model
    * Using MassTransit for abstraction over RabbitMQ Message-Broker system
    * Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices
    * Create RabbitMQ EventBus.Messages library and add references Microservices

## Ordering Microservice

    * Implementing DDD, CQRS, and Clean Architecture with using Best Practices
    * Developing CQRS with using MediatR, FluentValidation and AutoMapper packages
    * Consuming RabbitMQ BasketCheckout event queue with using MassTransit-RabbitMQ Configuration
    * SqlServer database connection and containerization
    * Using Entity Framework Core ORM and auto migrate to SqlServer when application startup

## API Gateway Ocelot Microservice

    * Implement API Gateways with Ocelot
    * Sample microservices/containers to reroute through the API Gateways
    * Run multiple different API Gateway/BFF container types
    * The Gateway aggregation pattern in Shopping.Aggregator

## WebUI ShoppingApp Microservice

    * ASP.NET Core Web Application with Bootstrap 4 and Razor template
    * Call Ocelot APIs with HttpClientFactory and Polly

## Microservices Cross-Cutting Implementations

    * Implementing Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog for Microservices
    * Use the HealthChecks feature in back-end ASP.NET microservices
    * Using Watchdog in separate service that can watch health and load across services, and report health about the microservices by querying with the HealthChecks

## Microservices Resilience Implementations

    * Making Microservices more resilient Use IHttpClientFactory to implement resilient HTTP requests
    * Implement Retry and Circuit Breaker patterns** with exponential backoff with IHttpClientFactory and Polly policies

## Ancillary Containers

    * Use Portainer for Container lightweight management UI which allows you to easily manage your different    
      Docker environments pgAdmin PostgreSQL Tools feature rich Open Source administration and development platform for PostgreSQL

## Docker Compose establishment with all microservices on docker

    * Containerization of microservices
    * Containerization of databases
    * Override Environment variables

## Run The Project

## Installing

    docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

    launch microservices as below urls:

    * Catalog API -> http://host.docker.internal:8000/swagger/index.html
    * Basket API -> http://host.docker.internal:8001/swagger/index.html
    * Discount API -> http://host.docker.internal:8002/swagger/index.html
    * Ordering API -> http://host.docker.internal:8004/swagger/index.html
    * Shopping.Aggregator -> http://host.docker.internal:8005/swagger/index.html
    * API Gateway -> http://host.docker.internal:8010/Catalog
    * Rabbit Management Dashboard -> http://host.docker.internal:15672   -- guest/guest
    * Portainer -> http://host.docker.internal:9000  -- admin/admin1234
    * pgAdmin PostgreSQL -> http://host.docker.internal:5050   -- admin@aspnetrun.com/admin1234
    * Elasticsearch -> http://host.docker.internal:9200
    * Kibana -> http://host.docker.internal:5601

    * Web Status -> http://host.docker.internal:8007
    * Web UI -> http://host.docker.internal:8006

    5. Launch http://host.docker.internal:8007 in your browser to view the Web Status. Make sure that every microservices are healthy.

    6. Launch http://host.docker.internal:8006 in your browser to view the Web UI. You can use Web project in order to call microservices over API Gateway. When you checkout the basket you can follow queue record on RabbitMQ dashboard.

## Referencias

    https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio

    https://www.twilio.com/blog/test-aspnetcore-minimal-apis

    https://anasdidi.dev/articles/200713-docker-compose-postgres/

    https://github.com/adrianvlupu/C4-Builder

    https://www.codeproject.com/Articles/5323228/Blazor-Web-Assembly-WASM-Theme-Switching

    https://learn.microsoft.com/pt-br/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-6.0&tabs=visual-studio-code

    https://github.com/adrianvlupu/C4-Builder

    https://github.com/adrianvlupu/C4Builder-Demo    
