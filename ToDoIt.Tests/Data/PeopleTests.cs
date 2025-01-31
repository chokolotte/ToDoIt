﻿using ToDoIt.Data;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests.Data
{
    public class PeopleTests
    {
        [Fact]
        public void Person_ConstructorGetSize_Zero()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = new People();
            int expectedSizeOfPeople = 0;

            //Act
            int myLengthOfPeople = myPeopleCollection.Size();
            
            //Assert
            Assert.Equal(expectedSizeOfPeople, myLengthOfPeople);
        }

        [Fact]
        public void FindAll_NoneAdded_ReturnEmptyArray()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = new People();
            int expectedSizeOfPeople = 0;

            //Act
            int myLengthOfPeople = myPeopleCollection.Size();
            Person[] foundPersons = myPeopleCollection.FindAll();

            //Assert
            Assert.Equal(expectedSizeOfPeople, myLengthOfPeople);
            Assert.Empty(foundPersons);
        }

        [Fact]
        public void FindAll_Added4_ReturnAll()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = new People();
            int expectedNrOfPersons = 4;
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Kalle", "Jonson");
            myPeopleCollection.AddPerson("Nisse", "Johnsson");
            myPeopleCollection.AddPerson("Robert", "Jönsson");

            //Act
            int myNrOfPeople = myPeopleCollection.Size();
            Person[] foundPersons = myPeopleCollection.FindAll();

            //Assert
            Assert.Equal(expectedNrOfPersons, myNrOfPeople);
            Assert.Equal(expectedNrOfPersons, foundPersons.Length);
        }

        [Fact]
        public void FindById_CreatePersonsLook4One_FoundOne()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = new People();
            int selectedPersonId = 3;
            Person myLuckyPerson;
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Kalle", "Jonson");
            myPeopleCollection.AddPerson("Nisse", "Johnsson");
            myPeopleCollection.AddPerson("Robert", "Jönsson");

            //Act
            myLuckyPerson = myPeopleCollection.FindById(selectedPersonId);

            //Assert
            Assert.Equal(selectedPersonId, myLuckyPerson.PersonId);
        }

        [Fact]
        public void FindById_CreatePersonsLook4OneNotThere_FoundNone()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = new People();
            int selectedPersonId = 3000;
            Person myLuckyPerson;
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Kalle", "Jonson");
            myPeopleCollection.AddPerson("Nisse", "Johnsson");
            myPeopleCollection.AddPerson("Robert", "Jönsson");

            //Act
            myLuckyPerson = myPeopleCollection.FindById(selectedPersonId);

            //Assert
            Assert.Null(myLuckyPerson);
        }

        [Fact]
        public void FindById_CreateArrayButEmpty_ReturnNull()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = new People();
            int selectedPersonId = 3000;
            Person myLuckyPerson;

            //Act
            myLuckyPerson = myPeopleCollection.FindById(selectedPersonId);

            //Assert
            Assert.Null(myLuckyPerson);
        }

        [Fact]
        public void AddPerson_OnlyOnePersonAdd_OnlyOnePersonIn()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = null;
            int myFirstTotalNrPersons = 0;
            Person onePerson = null;
            int mySecondTotalNrPersons = 0;

            int myExpectedNumberOfPersons = 1;

            //Act
            myPeopleCollection = new People();
            myFirstTotalNrPersons = myPeopleCollection.Size();
            onePerson = myPeopleCollection.AddPerson("Abel", "Jonsson");
            mySecondTotalNrPersons = myPeopleCollection.Size();

            //Assert
            Assert.NotEqual(myFirstTotalNrPersons, mySecondTotalNrPersons);
            Assert.Equal(myExpectedNumberOfPersons, mySecondTotalNrPersons);
        }

        [Fact]
        public void AddPerson_OnlyOnePersonAdd_DataInPersonRight()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = null;
            Person onePerson = null;
            int myFirstTotalNrPersons = 0;

            string myExpectedName = "Abel Jonsson";

            //Act
            myPeopleCollection = new People();
            onePerson = myPeopleCollection.AddPerson("Abel", "Jonsson");

            myFirstTotalNrPersons = myPeopleCollection.Size();
            onePerson = myPeopleCollection.FindById(myFirstTotalNrPersons);

            //Assert
            Assert.Equal(myExpectedName, onePerson.Name);
        }

        [Fact]
        public void Clear_AddPersonsClear_AllGone()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = null;
            int myFirstTotalNrPersons = 0;
            int mySecondTotalNrPersons = 0;
            int myExpectedNrOfPersons = 0;

            //Act
            myPeopleCollection = new People();
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Ronja", "Axelsson");
            myPeopleCollection.AddPerson("Gottfrid", "Larsson");
            myFirstTotalNrPersons = myPeopleCollection.Size();
            myPeopleCollection.Clear();
            mySecondTotalNrPersons = myPeopleCollection.Size();

            //Assert
            Assert.NotEqual(myFirstTotalNrPersons, mySecondTotalNrPersons);
            Assert.Equal(myExpectedNrOfPersons, mySecondTotalNrPersons);
        }

        [Fact]
        public void Remove_AddPersonsRemoveOne_OnlyOneGone()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = null;
            int myFirstTotalNrPersons = 0;
            int mySecondTotalNrPersons = 0;
            int myExpectedNrOfPersons = 3;

            myPeopleCollection = new People();
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Ronja", "Axelsson");
            Person myPerson = myPeopleCollection.AddPerson("Gottfrid", "Larsson"); // Delete this person
            myPeopleCollection.AddPerson("Sahara", "Hotnight");

            //Act
            myFirstTotalNrPersons = myPeopleCollection.Size();
            myPeopleCollection.Remove(myPerson);
            mySecondTotalNrPersons = myPeopleCollection.Size();

            //Assert
            Assert.NotEqual(myFirstTotalNrPersons, mySecondTotalNrPersons);
            Assert.Equal(myExpectedNrOfPersons, mySecondTotalNrPersons);

        }

        [Fact]
        public void Remove_RemoveOneNotIncluded_NothingRemoved()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = null;
            int mySecondTotalNrPersons = 0;
            int myExpectedNrOfPersons = 4;

            myPeopleCollection = new People();
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Ronja", "Axelsson");
            myPeopleCollection.AddPerson("Gottfrid", "Larsson");
            myPeopleCollection.AddPerson("Sahara", "Hotnight");
            Person myPerson = new Person(0, "Per", "Banan");    // Delete this person

            //Act
            myPeopleCollection.Remove(myPerson);
            mySecondTotalNrPersons = myPeopleCollection.Size();

            //Assert
            Assert.Equal(myExpectedNrOfPersons, mySecondTotalNrPersons);
        }

        [Fact]
        public void Remove_RemoveNull_NothingRemovedNoCrash()
        {
            //Arrange
            PersonSequencer.reset();
            People myPeopleCollection = null;
            int mySecondTotalNrPersons = 0;
            int myExpectedNrOfPersons = 4;

            myPeopleCollection = new People();
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Ronja", "Axelsson");
            myPeopleCollection.AddPerson("Gottfrid", "Larsson");
            myPeopleCollection.AddPerson("Sahara", "Hotnight");
            

            //Act
            myPeopleCollection.Remove(null);
            mySecondTotalNrPersons = myPeopleCollection.Size();

            //Assert
            Assert.Equal(myExpectedNrOfPersons, mySecondTotalNrPersons);
        }
    }
}
