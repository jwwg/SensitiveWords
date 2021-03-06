Sensitive Words
----------------

"You are working for a start up company which would like to provide an additional piece of functionality to their clients. The 
definition of this service would be to 'bloop' out sensitive words of the company’s choice, on their chat system i.e., SQL 
sensitive words, profanity, or anything the company deems 'Sensitive'. As an example, we have chosen our words to be in line 
with SQL key words. An example of this would be 'SELECT' or 'DROP' but could be any other word on the companies Sensitive 
list."

Assumptions
---------------------
- Because these words are sensitive, words that are part of a longer word will be masked as well - e.g "SomeTable" will become "Some*****"
- MS SQL is case-insensitive, so words are matched case-insensitive

Building and Running
--------------------
The main project is the SensitiveWords project - run this (the Swagger UI will popup where the API calls can be tested).
This uses SQLite as database provider, no DBMS setup required - the database file is words.db and is saved to local user's appdata folder
 
Endpoints
---------
- WordManagement is the internal CRUD layer
- SensitiveMessage is the external Business logic endpoint
 
Notes
----------
I've kept the code as minimal as possible. In the real world, I'd consider :
- Security (API key if this is a paid service)
- Internal and External would be separate services 
- GET method returning all words should be limited
- Error handling
- Logging/Monitoring
 
Performance enhancements
------------------------
- Use Redis or similar as a shared cache, rather than SQL.  
- Split internal and external API's to separate services, this will scale horizontally easily
- Optimise the word search algorithm last - biggest win is going to be caching. 
- That said, I'd consider building cached data into a tree, then traversing this tree and matching character by character


Benchmark (mask function only)
----------------------------------------------
```
StringLength indicates number of concatenated input strings, with the seed string :
SELECT * FROM BobbyTables; DROP DATABASE

```
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|       Method | StringLength |        Mean |     Error |    StdDev | Ratio |
|------------- |------------- |------------:|----------:|----------:|------:|
| **ParseMessage** |            **1** |    **50.20 μs** |  **0.581 μs** |  **0.515 μs** |  **1.00** |
|              |              |             |           |           |       |
| **ParseMessage** |           **10** |   **287.57 μs** |  **1.595 μs** |  **1.492 μs** |  **1.00** |
|              |              |             |           |           |       |
| **ParseMessage** |          **100** | **2,482.37 μs** | **19.106 μs** | **17.871 μs** |  **1.00** |


Deployment
----------
(assuming split into two services, with Redis cache)
Configure two kubernetes pod's - one for external and one for internal use. 
Put external behind nginx reverse proxy.
Both pods would need access to the same Redis cache.
The external pod in particular should be configured to be horizontally scalable.


 





