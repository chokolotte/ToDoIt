﻿using System;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests.Model
{
    public class ToDoTests
    {
        [Fact]
        public void ToDo_constructor_checkAllFields()
        {
            //arrange
            string description = "baka kaka";
            int id = 1;

            //act
            Todo todo1 = new Todo(id, description);

            //assert
            Assert.Equal(description, todo1.Description);
            Assert.False(todo1.Done);
            Assert.Equal(id, todo1.TodoId);
            Assert.Null(todo1.Assignee);
        }

        [Fact]
        public void ToDo_ConstructNoAssignee_GetAssigneeNull()
        {
            //arrange
            string description = "Get to work.";
            int id = 1;
            Person expectedPerson = null;

            //act
            Todo todo1 = new Todo(id, description);
            Person myAssignedPerson = todo1.Assignee;

            //assert
            Assert.Equal(expectedPerson, myAssignedPerson);

        }

        [Fact]
        public void ToDo_CreateEmpty_CreatedAndIdZero()
        {
            //Arrange
            Todo myToDo = new Todo();

            //Act
            int myToDoId = myToDo.TodoId;
            bool ExpectedFalse = myToDoId > 0 ? true : false;

            //Assert
            Assert.NotNull(myToDo);
            Assert.False(ExpectedFalse);
        }


        [Fact]
        public void ToDo_CreateIdOne_GetIdOne()
        {
            //Arrange
            Todo myToDo = new Todo(1, "Hello");
            int expectedOneId = myToDo.TodoId;

            //Act
            bool expectedTrue = expectedOneId == 1 ? true : false;

            //Assert
            Assert.True(expectedTrue);

        }

        [Fact]
        public void ToDo_CreateSetDescipt_GetDescript()
        {
            //Arrange
            string setStringDesciption = "Go walk";
            Todo myToDo = null;
            string expectedDesciption;

            //Act
            myToDo = new Todo(1, setStringDesciption);
            expectedDesciption = myToDo.Description;

            //Assert
            Assert.Equal(setStringDesciption, expectedDesciption);

        }

        [Fact]
        public void ToDo_CreateSetAssignee_GetAssignee()
        {
            //Arrange
            string setStringDesciption = "Go walk";
            Todo myToDo = null;
            Person myPerson = null;

            //Act
            myPerson = new Person(1, "Charlie", "Brown");
            myToDo = new Todo(1, setStringDesciption);
            myToDo.Assignee = myPerson;


            //Assert
            Assert.NotNull(myToDo.Assignee);
        }

        [Fact]
        public void ToDo_CreateSetDone_GetDoneOk()
        {
            //Arrange
            string setStringDesciption = "Go walk";
            Todo myToDo = null;

            //Act
            myToDo = new Todo(1, setStringDesciption);
            myToDo.Done = true;


            //Assert
            Assert.True(myToDo.Done);
        }
    }
}
