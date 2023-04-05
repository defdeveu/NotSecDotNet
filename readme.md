# NotSecDotnet

## Table of Contents
1. [Introduction](#Introduction)
2. [Building the application](#Build)
3. [Accessing the API via  the browser using Swagger](#Postman)
4. [Exercises](#Exercises)
    1.  [Exercise 1 - Find users of the app and their password](#Exercise_1)
    1. [Exercise 3 - Change another user's password](#Exercise_3)
	1. [Exercise 4 - Buy cheaper](#Exercise_4)
	1. [Exercise 5 – Check the authentication](#Exercise_5)
	1. [Exercise 6 – Find concurrency problems](#Exercise_6)
	1. [Exercise 7 – XSS](#Exercise_7)

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
On the /movie endpoint you can list movies of the database. This endpoint is accessible to anonymous (not logged in) users too.  
*Request Method*: GET  
*URL*: /movie?title=&lt;title&gt;&description=&lt;desc&gt;&genre=&lt;genre&gt;&id=&lt;id&gt; (none of the request parameters are mandatory)  
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
*URL*: /user/password?user=Yoda&oldPassword=&lt;old_password&gt;&newPassword=&lt;new_password&gt;  
*Response*:  Ok or Not ok  


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

<a name="Exercise_4"></a>
### Exercise 4 – Buy cheaper
**Short Description**
You can buy movie-related objects with the application. Each object have a name, a description and a price. Try to by something for cheaper than the original price!

**Service endpoint**
*Request Method*: PUT  
*URL*: /order  
*Body*: a JSON string containing the order  
	
Response: a JSON containing the details of the order and the final price.
	

**Detailed description**
Find a way to buy something for a cheaper price than intended!  
After you found the vulerability, fix the code!


<a name="Exercise_5"></a>
### Exercise 5 – Check the authentication

**Short Description**
Discover what kind of authentication the application uses. Find vulnerabilities in the solution.

**Service endpoint**
*Request Method*: PUT  
*URL*: /login/  
*Body*: a JSON string containing `UserName` and `Password`  
	
Response: a JSON containing the username or errorcode
	

**Detailed description**
You can log in to the application through the login endpoint.
After you logged in, you will be to access endpoints related to users (change password at `/user/password`, get info about the logged in user at `/me`, or get detailed info about the curren tuser at `user/profile/{userName}`.
Check that all of this works as intended.
What kind of authentication does application use?
Have a look at the AuthController class. Can you find any problems with this implementation? Name them? 
How would you fix the found problems (if there are any)?

<a name="Exercise_6"></a>
### Exercise 6 – Find concurrency problems

**Short Description**
Users of the app have tokens, that they can send to each-other. Hack the token-transfer endpoint!

**Service endpoint**
*Request Method*: PUT  
*URL*: /transfertoken/  
*Body*: a JSON string liket this 
```
{
  "toUser": "Princess Leia",
  "amount": 10
}
```  

*Request Method*: GET  
*URL*: /mytokens/  
*Result*: give info about the logged in user's tokens
	
Response: a JSON containing the username or errorcode
	

**Detailed description**
Users of the app have tokens, that they can send to each-other. The send happens through the transfertoken endpoint, it sends from the logged in user to the `toUser` of the request and the amount specified (if it is available on the logged in user's account).
Check the code in `UserController.TransferToken`! What kind of problems do you notice? Try to prove, that there is really a vulerability here! It is OK to modify the code by adding some delay here or there to prove your theory. How could you fix this vulerability? 


<a name="Exercise_6"></a>
### Exercise 7 – XSS

**Short Description**
The app has one page, but alas, that one is vulnerable to XSS. Find it and fix it!

**URL of the page**
https://localhost:7018/ 
	

**Detailed description**

At the above URL you will find a movie-search page. You already know from Exercise 1, that this functionality is vulnerable. But your job now is to find and XSS on this page. What kind of XSS is this? Check the source code! Fix it!
