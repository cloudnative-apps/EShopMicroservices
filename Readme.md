
#### HTTP and HTTPs Porta for all the services 
|Service Name | Local Env| Docker | Docker Inside|
|-----|----|---|---|
|Catalog API | 5000- 5050 | 6000-6060 | 8080-8081 |
|Basket API | 5001- 5051 | 6001-6061 | 8080-8081 |
|Discount API | 5002- 5052 | 6002-6062 | 8080-8081 |
|Ordering API | 5003- 5053 | 6003-6063 | 8080-8081|

---------------------------------
Docker-compose  down
Docker-compose -f docker-compose.yml  -f docker-compose.override.yml  up -d 

--------------------------
npx create-react-app eshop-app --template typescript-


-------------------------------------
## Tag images for docker repo

docker tag basketapi:latest sharadit/basketapi
docker tag catalogapi:latest sharadit/catalogapi
docker tag discountgrpc:latest sharadit/discountgrpc
docker tag yarpapigateway:latest sharadit/yarpapigateway
docker tag orderingapi:latest sharadit/orderingapi
docker tag shoppingweb:latest sharadit/shoppingweb


## Push Images to docker hub
docker push sharadit/basketapi
docker push sharadit/catalogapi
docker push sharadit/discountgrpc
docker push sharadit/yarpapigateway
docker push sharadit/orderingapi
docker push sharadit/shoppingweb



## Kubesctl list Pods, Services and Deployments

kubectl get deployments
kubectl get pods
kubectl get services


## Check logs of container


kubectl get pods
kubectl logs <pod_name> -c <container_name>
kubectl logs catalog-api-677f778455-6qmdn -c catalog-api



Sure, here's a formatted version of the provided text suitable for a Markdown file:

# Catalog Microservice
- **Tech Stack:**
  - ASP.NET Core Minimal APIs
  - .NET 8 and C# 12
  - Vertical Slice Architecture with Feature folders
  - CQRS implementation using MediatR library
  - CQRS Validation Pipeline Behaviours with MediatR and FluentValidation
  - Marten library for .NET Transactional Document DB on PostgreSQL
  - Carter library for Minimal API endpoint definition
  - Cross-cutting concerns Logging, global Exception Handling, and Health Checks
  - Dockerfile and docker-compose file for running Multi-container in Docker environment

# Basket Microservice
- **Tech Stack:**
  - ASP.NET 8 Web API application
  - Following REST API principles, CRUD operations
  - Redis as a Distributed Cache over basketdb
  - Implements Proxy, Decorator, and Cache-aside Design Patterns
  - Consumes Discount gRPC Service for inter-service sync communication to calculate product final price
  - Publish BasketCheckout Queue with using MassTransit and RabbitMQ

# Discount Microservice
- **Tech Stack:**
  - ASP.NET gRPC Server application
  - Highly Performant inter-service gRPC Communication with Basket Microservice
  - Exposes gRPC Services with creating Protobuf messages
  - Entity Framework Core ORM - SQLite Data Provider and Migrations
  - SQLite database connection and containerization
  - Sync inter-service gRPC Communication
  - Async Microservices Communication with RabbitMQ Message-Broker Service
  - Using RabbitMQ Publish/Subscribe Topic Exchange Model
  - Using MassTransit for abstraction over RabbitMQ Message-Broker system
  - Publishes BasketCheckout event queue from Basket microservices and Subscribes to this event from Ordering microservices

# Ordering Microservice
- **Tech Stack:**
  - DDD, CQRS, and Clean Architecture with Best Practices
  - CQRS with MediatR, FluentValidation, and Mapster packages
  - Domain Events & Integration Events
  - Entity Framework Core Code-First Approach, Migrations, DDD Entity Configurations
  - Consumes RabbitMQ BasketCheckout event queue with MassTransit-RabbitMQ Configuration
  - SqlServer database connection and containerization
  - Using Entity Framework Core ORM and auto migrate to SqlServer when application startup

# Yarp API Gateway Microservice
- **Tech Stack:**
  - API Gateways with Yarp Reverse Proxy applying Gateway Routing Pattern
  - Yarp Reverse Proxy Configuration; Route, Cluster, Path, Transform, Destinations
  - Rate Limiting with FixedWindowLimiter on Yarp Reverse Proxy Configuration
  - Sample microservices/containers to reroute through the API Gateways

# WebUI ShoppingApp Microservice
- **Tech Stack:**
  - ASP.NET Core Web Application with Bootstrap 4 and Razor template
  - Consumes YarpApiGateway APIs using Refit Library with Generated HttpClientFactory
  - ASPNET Core Razor Tools — View Components, partial Views, Tag Helpers, Model Bindings and Validations, Razor Sections, etc.
  - Docker Compose establishment with all microservices on docker
  - Containerization of microservices
  - Orchestrating of microservices and backing services (databases, distributed caches, message brokers, etc.)
  - Override Environment variables


## Observability

dotnet add package OpenTelemetry.Exporter.Console
dotnet add package OpenTelemetry.Extensions.Hosting
dotnet add package OpenTelemetry.Instrumentation.AspNetCore
dotnet add package OpenTelemetry.Instrumentation.EventCounters --prerelease
dotnet add package OpenTelemetry.Instrumentation.Runtime
dotnet add package OpenTelemetry.Instrumentation.SqlClient --prerelease
dotnet add package OpenTelemetry.Instrumentation.Http

