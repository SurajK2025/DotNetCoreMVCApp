drop database if exists keepnotes;
create database keepnotes;
use keepnotes;

create table users(
userid integer auto_increment primary key,
name varchar(250),
username varchar(250),
password varchar(250)
);

create table notes(
noteid integer auto_increment primary key, 
title varchar(255), 
description varchar(500), 
createdDate date, 
userid integer,
constraint fk_userid foreign key(userid) references users(userid)
);

insert into users (name, username, password) values 
("Suraj", "SK2025", "pass"),
("Rohit", "Ro45", "pass");

insert into notes (title, description, createdDate, userid) values 
("Task1", "Complete dotnet project", Curdate(), 1),
("Task2", "Pending Java Notes", Curdate(), 1),
("Task1", "SDM Project is pending", Curdate(), 2);