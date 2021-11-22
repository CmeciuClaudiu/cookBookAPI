# cookBookAPI
Restful API for my cookbook APP

This is the backend for my cookbook application. It can perform all four CRUD operations on Users and Create, Read recipes for the recipes.
For this app I have used .NET Core 5.0, Entity Framework (database first approach) with IDesign pattern.

Endpoints:
  USERS: 
    
    -GET userDetails: It gets your user details from the db for authentication. (except password which is encrypted for security purposes)
    
    -GET usersList: It gets list of all users only for Administrator (permission is checked).
    
    -POST users: It registers a new user (username, email, password, role ...).
    
    -PUT users: Edit username and email (this operation can be completed only by the logged in user. Admins cannot change details for another users)
    
    -DELETE users: Administrator can delete other users (with lower permissions)
    
  RECIPES:
    
    -GET ingredients: Gets all ingredients from the DB (I've tried to add all possible ingredients) (everyone allowed)
    
    -GET dtoRecipe: Gets recipes as Data transfer objects (only Id, recipe name and presentation picture) from DB. (everyone allowed)
    
    -GET recipe: Gets all ingredients, pictures, instructions and details for a specific recipe (by ID). (everyone allowed)
    
    -POST recipe: Posts a new recipe in the DB. (in order to do that you would need administrator permissions)
    

