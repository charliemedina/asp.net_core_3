# basic-crud
This project shows how to build a basic React CRUD adn Asp.NET Core 3

1 - Create a new ASP.NET Core Web Application (disabled HTTP configurations).
    - Install NuGet packages.
        . Microsoft.EntityFrameworkCore
        . Microsoft.EntityFrameworkCore.SqlServer
        . Microsoft.EntityFrameworkCore.Tools

2 - Add a model class and a database context.
    - Add a model class.
    - Add a database context.
    - Register the database context.

3 - Scaffold a controller with CRUD methods.
    - Create a controller.

4 - Configure routing, URL paths, and return values.
    - Replace [controller] with the name of the controller, which by convention is the controller class name minus the "Controller" suffix. 

5 - Call the web API with Postman.
    - Examine CRUD methods:

        Test Post with Postman.
            . Create a new request.
            . Set the HTTP method to POST.
            . Select the Body tab.
            . Select the raw radio button.
            . Set the type to JSON (application/json).
            . Create the request body in JSON.

        Test the location header URI.
            . Select the Headers tab in the Response pane.
            . Set the method to GET.
            . Paste the URI (for example, https://localhost:55314/api/users/1).
            . Select Send.

        Test the GET methods.
            These methods implement two GET endpoints:
                GET /api/TodoItems
                GET /api/TodoItems/{id}
            Test the app by calling the two endpoints from a browser or Postman. For example:
                https://localhost:55314/api/users
                https://localhost:55314/api/users/1


        Test the PutTodoItem method
            . Set new value in any item and before making a PUT call.

        Test the DeleteTodoItem method
            . Set the method to DELETE.
            . Set the URI of the object to delete (for example https://localhost:55314/api/users/1).
            . Select Send.

6 - Add FluentValidation for automatic validation.
https://docs.fluentvalidation.net/en/latest/index.html


7 - Swagger tooling for API's built with ASP.NET Core. Generate beautiful API documentation, including a UI to explore and test operations, directly from your routes, controllers and models.
https://github.com/domaindrivendev/Swashbuckle.AspNetCore#explicit-responses