# todo_crud_dsc
CRUD Todo Using .Net Core and Sqlite minimal API DDD

### initialize

``` sh
    dotnet new web -o MeuTodo -f net7.0
```



### install dependencies
*Entre na pasta do projeto primeiramente depois rodar a instalaçao abaixo*
``` sh
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
``` sh
    dotnet add package Microsoft.EntityFrameworkCore.Design
```


### Commands
``` sh
    dotnet clean
```

``` sh
    dotnet build
```

``` sh
    dotnet ef migrations add <NameMigration>
```

``` sh
    dotnet ef database update
```

``` sh
    dotnet ef migrations remove
```

``` sh
    dotnet watch run
```