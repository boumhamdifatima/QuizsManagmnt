# QuizsManagmnt

This is a quiz management web application GestionQuiz that allows you to: 

Generate a new quiz. 

Take a given quiz and save the result. 

Review the obtained grade.

## ARTISANA Description

The GestionQuiz project is a web application developed using Visual Studio 2019, ASP.Net Core MVC, Entity Framework Core 3.1.32 (Database-First) and Sql Server for data persistence. 
It uses Bootstrap/jQuery to improve display.
This is a Quiz management app for exams where users can generate a new quiz, take and save a given quiz, and review their obtained grade.

## Prerequisites

Before starting this project, make sure you have installed Visual Studio 2019.

## Install

1. Clone this repository on your local machine:

   git clone https://github.com/boumhamdifatima/QuizsManagmnt.git


2. Import the project into your IDE.

3. Create a Sql Server database by running the sql script: GestionQuiz_DB_SQL.sql

4. Configure your database by modifying the `ConnectionStrings` in appsettings.json file to add your database connection information.

5. Run the application.


## Features

### Generate a new quiz 
This feature allows the user to choose the number of questions per category (Easy, Medium, Hard) and create the quiz with a random choice of questions. 

### Take a given quiz
This feature allows the user to search the list of quizzes they can take, choose one and take it.

### Review the obtained grade
This feature allows the user to search the list of past quizzes, choose one to review and get the obtained grade.

## Demonstration

![Mon GIF](GestionQuiz_Demo.gif)

## Contribute

If you would like to contribute to this project, please follow these steps:

   Fork the project
   
   Create a new branch (git checkout -b feature/new-feature)
   
   Make changes and add features
   
   Commit changes (git commit -am 'Add new feature')
   
   Push changes to the branch (git push origin feature/new-feature)
   
   Create a new Pull Request 

## Author 

Fatima Boumhamdi - @FatimaBoumhamdi 

## License 

This project is licensed under the MIT License - see the LICENSE file for details.
