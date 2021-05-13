# TodoAPI - Techdome

## [Assignment: Todo API with JWT Token Authentication](dot-net-2yrs.pdf)

## Description

The **Todo API** is a **ASP.NET Web API** used to save any tasks to be done in an **InMemory database** using **Entity Framework Core**. It additionally utilizes **JWT Token Authentication** to authorize usage of the API endpoints.

The API achieves this using 2 controllers:

* **TodoController**
    * Contains the CRUD APIs for the list of todos
    * Uses the `TodoItem` Model

* **AuthController**
    * Contains the registration and login APIs
    * Uses the `User` Model

## Controllers

The 2 controllers used in the API are:

* TodoController
* AuthController

### TodoController

The `TodoController` contains the CRUD APIs for the todos we are adding to the database.

Here are all the APIs:

* GET `/getall`

    * Get all the todo items from the database
    * Get Http Request Link Example: `https://<YOUR-DOMAIN:PORT>/getall`
    * Response Example:

        ```json
        [
            {
                "id": 1,
                "task": "Task 1"
            },
            {
                "id": 2,
                "task": "Task 2"
            }
        ]
        ```

* GET `/get/{id}`

    * Gets a single todo item from the database using the `id`
    * Get Http Request Link Example: `https://<YOUR-DOMAIN:PORT>/get/1`
    * Response Example:

        ```json
        {
            "id": 1,
            "task": "Task 1"
        }
        ```

* POST `/create/{id}`

    * Creates a new todo item in the database using the `id`
    * Post Http Request Link Example: `https://<YOUR-DOMAIN:PORT>/create/1`
    * Request Body Example:

        ```json
        {
            "task": "Task To Be Done"
        }
        ```

    * Response Example:

        ```json
        {
            "id": 1,
            "task": "Task To Be Done"
        }
        ```

* PUT `/put/{id}`

    * Updates a single todo item in the database using the `id`
    * Put Http Request Link Example: `https://<YOUR-DOMAIN:PORT>/put/1`
    * Request Body Example:

        ```json
        {
            "task": "Edited Task"
        }
        ```

    * Response Example:

        ```json
        Todo 1 updated successfully!
        ```

* DELETE `/delete/{id}`

    * Deletes a single todo item from the database using the `id`
    * Delete Http Request Link Example: `https://<YOUR-DOMAIN:PORT>/delete/1`
    * Response Example:

        ```json
        Todo 1 deleted successfully!
        ```

#### Header Information

Make sure to add the following header information:

* **Content-Type**: `application/json`
* **Authorization**: `Bearer <TOKEN>`

### AuthController

The `AuthController` contains the registration and login APIs we are using to get the JWT token for authentication

* POST `/auth/login`

    * Returns the JWT token along with the user's details from the database after the user enters their email and password
    * Post Http Request Link: `https://<YOUR-DOMAIN:PORT>//auth/login`
    * Request Body Example:

        ```json
        {
            "email": "adityaoberai1@gmail.com",
            "password": "pass1234"
        }
        ```

    * Response Example:

        ```json
        {
            "fname": "Aditya",
            "lname": "Oberai",
            "email": "adityaoberai1@gmail.com",
            "isActive": true,
            "role": "Admin",
            "password": "pass1234",
            "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnaXZlbl9uYW1lIjoiRm9vIiwidW5pcXVlX25hbWUiOiJCYXIiLCJlbWFpbCI6ImZvb0BiYXIueHl6Iiwicm9sZSI6IlVzZXIiLCJuYmYiOjE2MjA5MTkwNDksImV4cCI6MTYyMDkyMDg0OSwiaWF0IjoxNjIwOTE5MDQ5fQ.1HSVK9svUpH-oLQn8NS1I87KnZpr1RbXT3dorDWcPEU"
        }
        ```

* POST `/auth/register`

    * Adds the user's details to the database and returns the JWT token after the user enters their information
    * Post Http Request Link: `https://<YOUR-DOMAIN:PORT>/auth/register`
    * Request Body Example:

        ```json
        {
            "fname": "Foo",
            "lname": "Bar",
            "email": "foo@bar.xyz",
            "role": "User",
            "password": "pass1234"
        }
        ```

        *Note:* `role` *can be removed for a registrant with the* `User` *Role. For a user with the* `Admin` *role, it will have to be added.*
    * Response Example:

        ```json
        {
            "fname": "Foo",
            "lname": "Bar",
            "email": "foo@bar.xyz",
            "isActive": true,
            "role": "User",
            "password": "pass1234",
            "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnaXZlbl9uYW1lIjoiRm9vIiwidW5pcXVlX25hbWUiOiJCYXIiLCJlbWFpbCI6ImZvb0BiYXIueHl6Iiwicm9sZSI6IlVzZXIiLCJuYmYiOjE2MjA5MTkwNDksImV4cCI6MTYyMDkyMDg0OSwiaWF0IjoxNjIwOTE5MDQ5fQ.1HSVK9svUpH-oLQn8NS1I87KnZpr1RbXT3dorDWcPEU"
        }
        ```

        *Note: Token returned will be different from the example*

#### Roles

Each user can have 1 of 2 roles:

* User
* Admin

Here is the access each role has to the **TodoController* APIs:

| Role | APIs Accessible |
| - | - |
| User | `/getall` API only |
| Admin | All TodoController APIs |

This information is claimed in the JWT Token. 
Failure to add the JWT Token as a Bearer Token in the **Authorization** header will result in a `401 Unauthorized` error

## Models

The 2 models used in the API are:

* User
* TodoItem

### User

#### Example

* In C#

```csharp
public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}
```

* In JSON

```json
{
    "fname": "Aditya",
    "lname": "Oberai",
    "email": "adityaoberai1@gmail.com",
    "isActive": false,
    "role": "Admin",
    "password": "pass123",
    "token": ""
}
```

**Note:** JSON Property Names have been mapped in C# Model in the API

### TodoItem

#### Example

* In C#

```csharp
public class TodoItem
{
    public long Id { get; set; }
    public string TaskToDo { get; set; }
}
```

* In JSON

```json
{
    "id": 1,
    "task": "Test Task"
}
```

**Note:** JSON Property Names have been mapped in C# Model in the API