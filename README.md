# school-administration
The second assignment for programming paradigms: A maintenance system for students and lecturers

## The Assignment
The assignment is the second assignment for the module Programming Paradigms(ppar). The module mainly covers three different paradigms: OOP, functional and logical. This assignment is a recap of OOP principles which have been previously covered in multiple courses during uni. The goal of the assignment is to improve on OOP skills by implementing a general administration CLI application. The application is written in C# using the .NET framework. The full assignment details can be found below.

## Details

This assignment is an extension of assignment part 1. Within this assignment, you will develop a small
console application for the maintenance of users (Students or Lecturers) for an administrative system.
Users can be created and their information is stored in XML-format. Furthermore, an overview and a
detail view of users can be given. Of course, the goal of this assignment is not the functionality as such,
but the application of OO-, design- and language concepts.
Write a console application with the following functional requirements / characteristics:
  - After execution, a menu with the following menu options is displayed:
    1 Create user
    2 Show overview users in database
    3 Show user details
    4 Exit application
  - After choosing the first menu option, you’ll respectively be asked to enter the following data:
    § User type (student or lecturer)
    § First name
    § Last name
    § Email address
    § Study Program (students only)
    § Cohort (students)
    § Class (students)
    § Phone number work (lecturers)
    § Lecturers abbreviation (lecturers)
    § Nationality
    § Date started (lecturers)
  - All the information is stored in one or more structured text files (XML). You don’t have to use
XML schema’s.
  - The email address and dates have to be validated. Regarding the email address, use your own
regular expression or be able to explain an existing one.
  - All users get a unique id (a sequence number) automatically.
  - After choosing the second menu option, a list of all users in your ‘database’ is displayed. For
each user, the id, first name and last name are displayed.
  - After choosing the third menu option, you’ll be asked to enter a user id. All details for this user
have to be displayed.
  - In general, exceptions are properly handled.
  - Assume it’s a single-user application, so don’t worry about concurrent use.
  - Optional: create an additional command and menu-option to generate an html-file containing
an overview of all users listed in a table. The html-file is generated, using XSLT.
  - Optional: the key combination ‘ctrl-C’ can be used to abort during entrance of a new user. The
main menu is displayed again.

The following non-functional requirements must be met:
  • The console application uses a Command object for each menu-option. A command
encapsulates an Action delegate object and contains a Description property.
  • Currently, data is stored in one or more XML files. In the future, persistence in a relational
database is required. Make sure that your application is designed in such a way that the
console application itself is completely unaware of the persistence back-end. E.g. Use the
abstract factory pattern to do so. The AbstractDBFactory class determines, based on the
configuration in App.config, which DBFactory class is instantiated. The XMLDBFactory reads 
the file details from the App.config as well. Note: we’ll not implement the relational database
option! Here it is just about future-ready design.
  • The application needs to be extendible. New types of users (any other sub type of the abstract
class User) can be created by writing a new sub class. The application automatically detects
the existence of that type, and offers the possibility to enter a new user of that type. No
change in the existing application should be necessary. To achieve this, you have to use
Reflection at several places. Idea is that you’re not hard-coding which properties a certain
user type has, but that you use reflection to obtain that information.
  • Make use of a home-made annotation (called Attribute in .NET). You’ll probably find a use
case for that during the implementation.

Use the SDK documentation to find out how to use the FCL (Framework Class Library).
