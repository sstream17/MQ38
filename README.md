# MQ38
A minimal, reproducible example of the issue with mocking IQueryable.ToListAsync() from the MockQueryable package.
[The issue](https://github.com/romantitov/MockQueryable/issues/38) in the MockQueryable repository explains the error.

In this solution, the error is as follows
```
System.InvalidOperationException : The source IQueryable doesn't implement IAsyncEnumerable<MQ38.Accessor.EntityFramework.Models.Event>. Only sources that implement IAsyncEnumerable can be used for Entity Framework asynchronous operations.
```
The exception is thrown on the `queryable.ToListAsync()` call in the EventManager class.

The EventManagerTests class sets up the mock IQueryable. This class contains the failing test.

The EventAccessorTests class sets up a mock DbSet. This class is able to pass its test.
