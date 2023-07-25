#  This project is an MVC project running on C#. #

## The project establishes a connection with a database running locally with in the computer and provides CRUD operations through Api requests. ##

In order for the user to perform API operations, he must first post himself with the admin and password hidden in the database. If it cannot verify, it cannot take any action.

In addition, there are criteria for Post transactions to be made.

Control operations and API requests within the project take place within the homecontroller.
In the BLL part, authorization and authtentication operations take place.
<br>
In the DLL part, the connection with the database is based.
<br>
The DTO file performs the connection and data extraction operations with the database.
