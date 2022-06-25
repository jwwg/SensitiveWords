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


Benchmark current performance (work mask only)
----------------------------------------------

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|       Method |   N |        Mean |     Error |    StdDev | Ratio |
|------------- |---- |------------:|----------:|----------:|------:|
| **ParseMessage** |   **1** |    **50.81 μs** |  **0.426 μs** |  **0.378 μs** |  **1.00** |
|              |     |             |           |           |       |
| **ParseMessage** |  **10** |   **279.19 μs** |  **3.843 μs** |  **3.595 μs** |  **1.00** |
|              |     |             |           |           |       |
| **ParseMessage** | **100** | **2,680.38 μs** | **35.088 μs** | **32.821 μs** |  **1.00** |




Deployment
----------




