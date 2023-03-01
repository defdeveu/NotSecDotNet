# NotSecDotnet

## Table of Contents
1. [Introduction](#Introduction)
2. [Building the application](#Build)
3. [Accessing the API via Postman](#Postman)
4. [Exercises](#Exercises)
    1.  [Exercise 1 - Find users of the app and their password](#Exercise_1)
     1. [Exercise 3 - Change another user's password](#Exercise_3)

<a name="Introduction"></a>
## Introduction 

NotSecDotnet is an intentionally vulnerable Dotnet application. It is created for educational purposes. It is intended mainly for developers.
NotSecDotnet is a movie-related application, where you can log in and out, read information about movies, buy movie-related objects, send messages to other users of the application, etc. The functionalities are far from complete or coherent, they just serve the purpose of demonstrating specific vulnerabilities.
This document contains exercises which can be done with NotSecDotnet to understand how to exploit and how to fix specific vulnerabilities.

<a name="Build"></a>
## Building the application 

Use Visual Studio to import and run the project!

<a name="Swagger"></a>
## Accessing the API via the browser using Swagger 
NotSecDotnet in itself does not contain any user interface . It is a RESTfull application accepting http requests and responding JSON strings. The easiest way to intercat with the application is through Swagger at context_root/swagger/index.html. Here you can see the requests and try them out.
<a name="Exercises"></a>
## Exercises 

<a name="Exercise_1"></a>
### Exercise 1 – Find users of the app and their passwords
**Short Description**
The list of the movies of the application is accessible by all users (including anonymous users too). Find a vulnerability in this service and exploit it, so that you can see all users of the application and their passwords!

**Service endpoint**
On the /rest/movie endpoint you can list movies of the database. This endpoint is accessible to anonymous (not logged in) users too.  
*Request Method*: GET  
*URL*: /rest/movie?title=&lt;title&gt;&description=&lt;desc&gt;&genre=&lt;genre&gt;&id=&lt;id&gt; (none of the request parameters are mandatory)  
*Response*: a JSON containg movies which fulfill the search conditions  

**Detailed description**
The service behind this endpoint is vulnerable to one of the most classic exploit of programming. Find the vulnerability, and exploit it so that you can get users and their passwords from the database! (Hint: The table containing the users' data is called APPUSER.)   
When you are done, check the source code (MovieService.findMovie) and fix it.   
Discuss what could have been the developers motivation creating this code!  


<a name="Exercise_3"></a>
### Exercise 3 – change another user's password
**Short Description**
The application contains a password change functionality. Abuse it to change another user's password!

**Service endpoint**
*Request Method*: POST  
*URL*: /rest/user/password?user=Yoda&oldPassword=&lt;old_password&gt;&newPassword=&lt;new_password&gt;  
*Response*:  Ok or Not ok  

**Postman request**
Change password

**Detailed description**
The change password service first creates a password-change xml to call a remote password change service with it (in reality the remote service does nothing remotely, just parses the xml and changes the password locally).  
Find a vulnerability within this service!  
This is how the password service creates the xml file:
```java
public String createXml(ChangePasswordDto changePasswordDto)
        {
            return $"<user><pwd>{changePasswordDto.newPassword}</pwd><userName>{changePasswordDto.user}</userName></user>";
        }
```
After the exploit fix the vulnerability within the code.