# DDD_RestAPI_NET
Template para criar uma API REST com Net Core 5 seguindo o Domain Driven Design
* .Net 5
* EntityFramework 5.03
* AutoMapper (convert dto to entity and vice versa)

# Configuring Database
* In the SqlContext there is a command that force the instantion of the database: Database.EnsureCreated();

* But, if you want to use Migration, use the commands bellow
   * Add-Migration InitialCreate
   * Update-Database
