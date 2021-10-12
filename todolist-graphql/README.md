# GraphQL API for To Do List

## Description

This sample GraphQL API was built to test the integration between EF Core 5 and HotChocolate 12.

## Built with

- [.NET 5](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five)
- [EF Core 5](https://github.com/dotnet/efcore/tree/release/5.0)
- [HotChocolate 12](https://github.com/ChilliCream/hotchocolate)
- [Voyager](https://github.com/graphql-dotnet/server)

## Sample queries

```
{
  a: items(where: { id: { eq: 1 } }) {
    nodes {
      id
      title
      done
      list {
        name
      }
    }
  }
  b: items(where: { id: { eq: 1 } }) {
    nodes {
      id
      title
      done
      list {
        name
      }
    }
  }
}
```
