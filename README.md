# vet-clinic-x
Vet Clinic Example is a simple implementation of an application for a veterinary clinic, used to show some sample DDD implementations.

## Requisites
To run this solution it's only needed:
* .Net 7.0.202 or newer feature branch
* Docker
* (Optionally) Docker compose

# How to run
1. Open a terminal and CD to the solution folder;
2. type `docker compose run sql` (or run MS SQL Server 2022 image from Docker Hub)
3. (optionally) if you run the image "by hand" (not using Docker compose), update the connection string at *appsettings.Development.json* accordingly;
4. execute the API project using an IDE profile or executing `dotnet run` (at the *PeikcadLive.VetClinicX.Core.Api* project folder);
5. have fun!