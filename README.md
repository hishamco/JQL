JSON Query Language  (JQL)
=========================
JQL is a language used to query a JSON file. It seems like SQL for DBMS.
###Grammer Specification
A grammar specifications may contain directives that are used to customize the generated parser or declare how some symbols will be used in the grammar.
```
<query>		 ::= <identifier> [ (<elements>)? ]
<elements>   ::= <element> | <element> , <elements> 
<element>	 ::= <pair> | <identifier> 
<pair>	     ::= <identifier> : <value>
<value>	     ::= <string> | <number> | <boolean> | null
<identifier> ::= <letter> (<letter> | <digit>)*
<string>	 ::= " (<letter> | <digit>)* "
<number>	 ::= (<digit>)+
<boolean>	 ::= true | false
<letter>     ::= [a-zA-Z]
<digit>      ::= [0-9]
```
> **Notes:**
> * ```<token>``` to declare a token
> * ```x|y``` to say x or y
> * ```x?``` to say that x is optional
> * ```x+``` to say that x can appear at least 1 time
> * ```x*``` to say that x can appear 0 or many times
> * ```[x-y]``` to say that the value between x and y

###Sample Queries
Sample.json
```
{
    "Categories": [
        {
            "Id": 1,
            "Name": "Category 1",
            "Products": [
                {
                    "Name": "Product 1",
                    "Price": "789.3"
                },
                {
                    "Name": "Product 2",
                    "Price": "566"
                }
            ]
        },
        {
            "Id": 2,
            "Name": "Category 2",
            "Products": [
                {
                    "Name": "Product 1",
                    "Price": "789.3"
                },
                {
                    "Name": "Product 2",
                    "Price": "566"
                },
                {
                    "Name": "Product 3",
                    "Price": "231"
                }
            ]
        }
    ]
}
```
The following table shows some of the JQL queries and its equivalent in SQL:

JQL                   | SQL
--------              | ---
Categories[]          | Select * From Categories
Categories[Id]        | Select Id From Categories
Categories[Id,Name]   | Select ID,Name From Categories
Categories[Products[]]| Select *.Departments From Categories,Departments Where Categories.Id=Products.CategoryId
Categories[Id:1]      | Select * From Categories Where Id=1
Categories[4]         | Select * FROM (Select ROW_NUMBER() Over (Order By Id) As RowNum, * From Categories)                                        Where RowNum = 4
> **Hint:** The equivalent SQL statement for the Categories[4] is the SQL Server implementation. And that doesn't mean it's same for other DBMS.
