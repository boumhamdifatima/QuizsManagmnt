use master;
DROP DATABASE QuizExamen;
CREATE DATABASE QuizExamen;

USE QuizExamen;
GO

CREATE TABLE Category(
categoryID int PRIMARY KEY IDENTITY(1,1),
description varchar(50),
);

CREATE TABLE Question(
questionID int PRIMARY KEY IDENTITY(1,1),
text varchar(255),
categoryID int FOREIGN KEY REFERENCES Category(categoryID)
);


CREATE TABLE ItemOption(  -- Option
optionID int PRIMARY KEY IDENTITY(1,1),
text varchar(255),
isRight bit not null,
questionID int FOREIGN KEY REFERENCES Question(questionID)
);


CREATE TABLE Quiz(
quizID int PRIMARY KEY IDENTITY(1,1),
userName varchar(50),
email varchar(50)
);


CREATE TABLE Answer(
answerID int PRIMARY KEY IDENTITY(1,1),
optionID int FOREIGN KEY REFERENCES ItemOption(optionID),
quizID int FOREIGN KEY REFERENCES Quiz(quizID)
);


CREATE TABLE QuestionQuiz(
questionID int,
quizID int,
PRIMARY KEY (questionID, quizID),
FOREIGN KEY (questionID) REFERENCES Question(questionID),
FOREIGN KEY (quizID) REFERENCES Quiz(quizID)
);


/*---------------------------------------------------------------*/
delete from Category;

Insert into Category(description) values
('easy'), 
('medium'), 
('hard')
;
GO

select * from Category;

/*---------------------------------------------------------------*/
delete from Question;

insert into Question(text,categoryID) values
('Java is ……..', 1),
('A Java class', 2),
('What is Java inheritance?', 2),
('Polymorphism is the ability of an object to take on many forms.', 3),
('Local variables are declared in methods, constructors, or blocks.', 1),
('…….. stores a fixed-size sequential collection of elements of the same type?', 2),
('Ennoncé de la question aevce id 7 categorie easy', 1),
('Ennoncé de la question aevce id 8 categorie Medium', 2),
('Ennoncé de la question aevce id 9 categorie Hard', 3),
('Ennoncé de la question aevce id 10 categorie easy', 1),
('Ennoncé de la question aevce id 11 categorie Medium', 2),
('Ennoncé de la question aevce id 12 categorie Hard', 3),
('Ennoncé de la question aevce id 13 categorie easy', 1),
('Ennoncé de la question aevce id 14 categorie Medium', 2),
('Ennoncé de la question aevce id 15 categorie Hard', 3),
('Ennoncé de la question aevce id 16 categorie easy', 1),
('Ennoncé de la question aevce id 17 categorie Medium', 2),
('Ennoncé de la question aevce id 18 categorie Hard', 3),
('Ennoncé de la question aevce id 19 categorie easy', 1),
('Ennoncé de la question aevce id 20 categorie Medium', 2),
('Ennoncé de la question aevce id 21 categorie Hard', 3),
('Ennoncé de la question aevce id 22 categorie easy', 1),
('Ennoncé de la question aevce id 23 categorie Medium', 2),
('Ennoncé de la question aevce id 24 categorie Hard', 3),
('Ennoncé de la question aevce id 25 categorie easy', 1),
('Ennoncé de la question aevce id 26 categorie Medium', 2),
('Ennoncé de la question aevce id 27 categorie Hard', 3),
('Ennoncé de la question aevce id 28 categorie easy', 1),
('Ennoncé de la question aevce id 29 categorie Medium', 2),
('Ennoncé de la question aevce id 30 categorie Hard', 3),
('Ennoncé de la question aevce id 31 categorie easy', 1),
('Ennoncé de la question aevce id 32 categorie Medium', 2),
('Ennoncé de la question aevce id 33 categorie Hard', 3),
('Ennoncé de la question aevce id 34 categorie easy', 1),
('Ennoncé de la question aevce id 35 categorie Medium', 2),
('Ennoncé de la question aevce id 36 categorie Hard', 3),
('Ennoncé de la question aevce id 37 categorie easy', 1),
('Ennoncé de la question aevce id 38 categorie Medium', 2),
('Ennoncé de la question aevce id 39 categorie Hard', 3)
;
GO

select * from Question;


/*---------------------------------------------------------------*/
delete from ItemOption;

insert into ItemOption(text, isRight, questionID) values
('a coffee', 0, 1), 
('a high-level programming language', 1, 1), 
('a source code editor', 0, 1),
('is a template that describes the behavior that the object of its type support', 1, 2),
('can have any number of methods', 0, 2),
('the process where one class acquires the properties methods and fields of another.', 1, 3), 
('a problem that arises during the execution of a program.', 0, 3), 
('it mainly used to traverse collection of elements including arrays.', 0, 3),
('true', 1, 4), 
('false', 0, 4), 
('true', 1, 5), 
('false', 0, 5), 
('variables', 0, 6),
('arrays', 1, 6), 
('methods', 0, 6),
('option réponse id 16 question id 7 isRight 0', 0, 7),
('option réponse id 17 question id 7 isRight 1', 1, 7),
('option réponse id 18 question id 7 isRight 0', 0, 7),
('option réponse id 19 question id 8 isRight 0', 0, 8),
('option réponse id 20 question id 8 isRight 1', 1, 8),
('option réponse id 22 question id 8 isRight 0', 0, 8),
('option réponse id 22 question id 9 isRight 1', 1, 9),
('option réponse id 23 question id 9 isRight 0', 0, 9),
('option réponse id 24 question id 9 isRight 0', 0, 9),
('option réponse id 25 question id 10 isRight 1', 1, 10),
('option réponse id 26 question id 10 isRight 0', 0, 10),
('option réponse id 27 question id 10 isRight 0', 0, 10),
('option réponse id 28 question id 10 isRight 0', 0, 10),
('option réponse id 29 question id 11 isRight 1', 1, 11),
('option réponse id 30 question id 11 isRight 0', 0, 11),
('option réponse id 31 question id 11 isRight 0', 0, 11),
('option réponse id 32 question id 11 isRight 0', 0, 11),
('option réponse id 33 question id 12 isRight 0', 0, 12),
('option réponse id 34 question id 12 isRight 0', 0, 12),
('option réponse id 35 question id 12 isRight 1', 1, 12),
('option reponse id 36 question id 13 isRight 1',1,13),
('option reponse id 37 question id 13 isRight 0',0,13),
('option reponse id 38 question id 13 isRight 0',0,13),
('option reponse id 39 question id 14 isRight 1',1,14),
('option reponse id 40 question id 14 isRight 0',0,14),
('option reponse id 41 question id 14 isRight 0',0,14),
('option reponse id 42 question id 15 isRight 1',1,15),
('option reponse id 43 question id 15 isRight 0',0,15),
('option reponse id 44 question id 15 isRight 0',0,15),
('option reponse id 45 question id 16 isRight 1',1,16),
('option reponse id 46 question id 16 isRight 0',0,16),
('option reponse id 47 question id 16 isRight 0',0,16),
('option reponse id 48 question id 17 isRight 1',1,17),
('option reponse id 49 question id 17 isRight 0',0,17),
('option reponse id 50 question id 17 isRight 0',0,17),
('option reponse id 51 question id 18 isRight 1',1,18),
('option reponse id 52 question id 18 isRight 0',0,18),
('option reponse id 53 question id 18 isRight 0',0,18),
('option reponse id 54 question id 19 isRight 1',1,19),
('option reponse id 55 question id 19 isRight 0',0,19),
('option reponse id 56 question id 19 isRight 0',0,19),
('option reponse id 57 question id 20 isRight 1',1,20),
('option reponse id 58 question id 20 isRight 0',0,20),
('option reponse id 59 question id 20 isRight 0',0,20),
('option reponse id 60 question id 21 isRight 1',1,21),
('option reponse id 61 question id 21 isRight 0',0,21),
('option reponse id 62 question id 21 isRight 0',0,21),
('option reponse id 63 question id 22 isRight 1',1,22),
('option reponse id 64 question id 22 isRight 0',0,22),
('option reponse id 65 question id 22 isRight 0',0,22),
('option reponse id 66 question id 23 isRight 1',1,23),
('option reponse id 67 question id 23 isRight 0',0,23),
('option reponse id 68 question id 23 isRight 0',0,23),
('option reponse id 69 question id 24 isRight 1',1,24),
('option reponse id 70 question id 24 isRight 0',0,24),
('option reponse id 71 question id 24 isRight 0',0,24),
('option reponse id 72 question id 25 isRight 1',1,25),
('option reponse id 73 question id 25 isRight 0',0,25),
('option reponse id 74 question id 25 isRight 0',0,25),
('option reponse id 75 question id 26 isRight 1',1,26),
('option reponse id 76 question id 26 isRight 0',0,26),
('option reponse id 77 question id 26 isRight 0',0,26),
('option reponse id 78 question id 27 isRight 1',1,27),
('option reponse id 79 question id 27 isRight 0',0,27),
('option reponse id 80 question id 27 isRight 0',0,27),
('option reponse id 81 question id 28 isRight 1',1,28),
('option reponse id 82 question id 28 isRight 0',0,28),
('option reponse id 83 question id 28 isRight 0',0,28),
('option reponse id 84 question id 29 isRight 1',1,29),
('option reponse id 85 question id 29 isRight 0',0,29),
('option reponse id 86 question id 29 isRight 0',0,29),
('option reponse id 87 question id 30 isRight 1',1,30),
('option reponse id 88 question id 30 isRight 0',0,30),
('option reponse id 89 question id 30 isRight 0',0,30),
('option reponse id 90 question id 31 isRight 1',1,31),
('option reponse id 91 question id 31 isRight 0',0,31),
('option reponse id 92 question id 31 isRight 0',0,31),
('option reponse id 93 question id 33 isRight 1',1,32),
('option reponse id 94 question id 33 isRight 0',0,32),
('option reponse id 95 question id 33 isRight 0',0,32),
('option reponse id 96 question id 33 isRight 1',1,33),
('option reponse id 97 question id 33 isRight 0',0,33),
('option reponse id 98 question id 33 isRight 0',0,33),
('option reponse id 99 question id 34 isRight 1',1,34),
('option reponse id 100 question id 34 isRight 0',0,34),
('option reponse id 101 question id 34 isRight 0',0,34),
('option reponse id 102 question id 35 isRight 1',1,35),
('option reponse id 103 question id 35 isRight 0',0,35),
('option reponse id 104 question id 35 isRight 0',0,35),
('option reponse id 105 question id 36 isRight 1',1,36),
('option reponse id 106 question id 36 isRight 0',0,36),
('option reponse id 107 question id 36 isRight 0',0,36),
('option reponse id 108 question id 37 isRight 1',1,37),
('option reponse id 109 question id 37 isRight 0',0,37),
('option reponse id 110 question id 37 isRight 0',0,37),
('option reponse id 111 question id 38 isRight 1',1,38),
('option reponse id 112 question id 38 isRight 0',0,38),
('option reponse id 113 question id 38 isRight 0',0,38),
('option reponse id 114 question id 39 isRight 1',1,39),
('option reponse id 115 question id 39 isRight 0',0,39),
('option reponse id 116 question id 39 isRight 0',0,39)
;
GO
/*---------------------------------------------------------------*/
delete from Quiz;

insert into Quiz(userName, email) values
('williamo', 'william@gmail.com'),
('allo21', 'alex.gh@gmail.com')
;

select * from Quiz;

/*---------------------------------------------------------------*/
delete from Answer;

insert into Answer(optionID, quizID) values
(1, 1), (5, 1), (9, 1), (14, 1), 
(1, 2), (7, 2), (9, 2), (11, 2);
GO

select * from Answer ;

/*---------------------------------------------------------------*/
delete from QuestionQuiz; 

insert into QuestionQuiz(questionID, quizID) values 
(1, 1), (2, 1), (4, 1), (6, 1), 
(1, 2), (3, 2), (4, 2), (5, 2);
GO


select * from QuestionQuiz;

GO

/*---------------------------------------------------------------*/


