dotnet new sln -o StorageSolution #Solution
dotnet new classlib -o StorageWebAPI.Contracts #Lib de tipagens
dotnet new webapi -o StorageWebAPI #Webapi
dotnet sln ./StorageSolution/StorageSolution.sln add ./StorageWebAPI #Adiciona projeto á solution
dotnet sln ./StorageSolution/StorageSolution.sln add ./StorageWebAPI.Contracts #Adiciona projeto á solution