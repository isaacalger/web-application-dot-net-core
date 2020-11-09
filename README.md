# web-application-dot-net-core
test .net core 3.1 web application starting point.

The Solution is structured as followed
- WebApplication.Data 			(Data Access Layer)
-- Core
--- EntityModels
--- Reposities
-- Migrations
--- SeedData
--- EF Migrations
-- Persistence
--- EntityConfiguration
--- Reposities

- WebApplication.Server 		(API Server)
-- Controllers
-- DTOModels
-- Services

- WebApplication.Tests 			(XUnit Tests)
-- UnitTests
--- DataLayer
--- ServerLayer

- WebApplication.UI 			(React Web UI)
-- Blank Project

** WebApplication.Data
The Data Access layer uses the Reposity pattern and Unit Of Work pattern
The Core contain the Models and Repository Interfaces
The Persistence layer Contains the Implementations for the Interfaces

** API Server
The API server only has one end point to manage UserAccount Registration and UserManagement.
There are a few DTO Object that are used to hide the Guid field on the database layer.
They also contain some View Specific Fields and Server side validation that will be used later.
There is a stubbed in Email service but its blank at the mement. 

** XUnit Tests
The XUnit Tests Use Moq to mock the Reposity and Controller and has some basic Happy Case testing.

** React UI
The React UI is currently an Empty Project that does not do anything. I should probably exclude it but I will want to write a front end that uses my API at some point :)