# ISM Tech Test

This is the project to create a simple front end to maintain 3 doors and their states. This project has some flaws I want to address and some decisions made in terms of experimentation. If you wish to see my work with a DB, check https://github.com/ConnorGilhooley/6BTechTest

## Flaws 
1. This should have used a database. Following the brief, I did not use a database for this and makes it an unrealistic way a c# api would store data.
2. This project as a result of not using a DB has problems where the way it mocks the class for testing effectively re-implements the class as a result.
3. This project should be multiple repositories to seperate concerns and build pipelines.
4. This project uses the device local storage for a state, which while functional to allow storage, is strongly ill-advised on anything other than a development machine.

## Experimentation 
1. Used local storage for the first time to get the state to preserve without a database.
2. Retained the Swagger API UI provided by microsoft and used it to help test some of my work

