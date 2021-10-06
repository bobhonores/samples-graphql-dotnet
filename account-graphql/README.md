# GraphQL API for Accounts

## Description

This sample GraphQL API was built to handle CRUD operations over accounts.

The main goal of this project was use GraphQL.NET library with EF Core. Also, this project was based on the tutorial of the [GraphQL ASP.NET Core Tutorial](https://code-maze.com/graphql-asp-net-core-tutorial/). You could find the original repo here: [https://github.com/CodeMazeBlog/graphql-series]

## GraphQL sample requests

### Query all owners with their account

```
{
  owners{
    id
    name
    address
    accounts {
      id
      description
      type
    }
  }
}
```

### Query owner by id

```
{
  owner (ownerId: "fdfb7dfa-c283-4a13-bab9-1c81c76f2b3f")
  {
    id
    name
  }
}
```

### Mutation to create owners

```
mutation($owner: ownerInput!) {
  createOwner(owner: $owner) {
    id
    name
    address
  }
}
```

_variables_

```
{
  "owner": {
    "name": "new name",
    "address": "new address"
  }
}
```

### Mutation to update owners

```
mutation($owner: ownerInput!, $ownerId: ID!) {
  updateOwner(owner: $owner, ownerId: $ownerId) {
    id
    name
    address
  }
}
```

_variables_

```
{
  "owner": {
    "name": "update name",
    "address": "update address"
  },
  "ownerId": "56f8a164-6684-4268-9f6c-2ed2ed27463a"
}
```

### Mutation to delete owners

```
mutation($ownerId: ID!) {
  deleteOwner(ownerId: $ownerId)
}
```

_variables_

```
{
  "ownerId": "56f8a164-6684-4268-9f6c-2ed2ed27463a"
}
```

## Built With

- [.NET 5](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five)
- [EF Core 5](https://github.com/dotnet/efcore/tree/release/5.0)
- [GraphQL.NET](https://github.com/graphql-dotnet/graphql-dotnet)
