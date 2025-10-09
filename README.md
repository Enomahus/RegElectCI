# RegElectCI
Registre électorale

## Développement

### Local
Le projet est composé d'un frontend **Angular 20** et d'un backend en **ASP.NET Core** en **.NET 9**.
L'utilsation de **Docker** est obligatoire afin de pouvoir héberger la base de données **SQL Server 2022**.

#### Backend
Pour démarrer le backend depuis une console: `docker compose -f docker/dev/docker-compose.yml --project-directory ./docker/dev up --build`
depuis la racine du projet.


