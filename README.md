# Brake
https://brake.azurewebsites.net/

An ASP.NET CORE MVC platform to buy/sell cars
[![UI.png](https://i.postimg.cc/dVTcJn4S/UI.png)](https://postimg.cc/FYmBZbtj)

Features & Concepts

1.
MVC
[![mvc.png](https://i.postimg.cc/PryQPkFC/mvc.png)](https://postimg.cc/fJ39r1ss)
-Model,View,Control is a design pattern commonly used. The organization of files is important (shown in image above)
-Model: contains classes, objects, schemas for database
-View: contains HTML and CSS that renders pages
-Control: contains controllers 

How it works: 

When a browser sends a request, it is routed to the controller. The controller contains various CRUD operations to handle this request. THe controller will call upon the models to access data
and call upon the corresponding view .cshtml file that contains the webpage's render code. THe controller then sends back this information to the browser and a webpage is loaded.
Note that the model and view do not directly communicate with each other, the controller is like an intermediary to these two.

2.
Migrations, Entity ORM

[![dbcontext.png](https://i.postimg.cc/Hksj3r4t/dbcontext.png)](https://postimg.cc/svqVgDLB)

THe above is a dbcontext which is a class provided by Entity as a gateway to the DBset which queries the database in runtime. 

on the NuGET package manager console:

Add-migration

update-database

These commands perform a migration where the Schema in the SQL server is updated according to the current DbContext. Entity framework helps in automating DB relating activites.

 

3.
SSMS(SQL Server Management Studio) and Backend DB:
[![ssms.png](https://i.postimg.cc/C103Hqbh/ssms.png)](https://postimg.cc/kVjY7Djz)

SSMS was very useful during development to inspect the state of both the local SQL server and the SQL server in the Azure Cloud. 

4.
CRUD operations
[![CRUD.png](https://i.postimg.cc/Pr0FQDkg/CRUD.png)](https://postimg.cc/6yL09yqc)

Create: Add a new Model/Car/Make to database

Read: Read a new Model/Car/Make from database

Update: edit Model/Car/Make in database

Delete: delete entry from database

All operations other than Read are only available to admin after login

5.
Authentication & AUthorization
[![login.png](https://i.postimg.cc/hPn0D0cP/login.png)](https://postimg.cc/z3dhpKy9)

login page 

[![loggedin-page.png](https://i.postimg.cc/dVHR9PdL/loggedin-page.png)](https://postimg.cc/4YchJ0Wg)

logged in page

[![update.png](https://i.postimg.cc/DfrqMbLV/update.png)](https://postimg.cc/G9p8BtXz)

admin edit privilege 


6.
Client and Server side data validation
[![server-side-data-validation.png](https://i.postimg.cc/dQfKgLYB/server-side-data-validation.png)](https://postimg.cc/7bSc2PbG)

used data annotations/attributes above properties for type checking

[![client-side-data-validation.png](https://i.postimg.cc/YS2rMZyf/client-side-data-validation.png)](https://postimg.cc/xX7DPxQc)

If user does not enter the required fields, the text-danger will render in real time. 



7.
Deployment of SQL database and application to Azure

[![deploy.png](https://i.postimg.cc/DycRn0VH/deploy.png)](https://postimg.cc/pppsB2LJ)

Website: https://brake.azurewebsites.net/
