# CSF Internship Assessment 2024

I have completed the Software Development Assessment.

I have decided to build my app using C# and have MSSQL as my database system as this is what I have the most experience with. I have previously worked on smaller projects to use Angular and Javascript and have used MongoDB as a database point. I will be looking to build this app with Node.js and express at some point later.

In order for my app to run properly and have its database working, you would need to have MSSQL installed and run the DatabaseSetup.sql file. This will build the database and populate a few records.
My app is also built with Visual Studio 2022, having this app would be the best way to run the app.

In regards to the public API, I only noticed later that there was a list of public APIs to choose from. I went ahead and made my own research to find a public API. I came across an animal one at this link: https://api-ninjas.com/api/animals and decided to use it, the only downside for this API; is that each request must have a name value. This is understandable as this API seems to have a boatload of records. I assume that using this API would not be an issue for this assessment. Please let me know otherwise, and I can look to build the app using one from the list provided.

# Here are the steps to run my app.
1. Download/Open MSSQL and run the DatabaseSetup.sql file.
2. Download Visual Studio 2022 if needed.
3. Open the CSharp-rest-api.sln in the CSharp-rest-api folder, this will should open with the Visual Studio 2022.
4. Starting options: The start option should already be set-up to open multiple projects at the same time and you should only need to click the "Start" button towards the top middle part of your screen. If you do not see "Multiple Startup Projects" box next to the "Start button", please access this link and follow the steps to set-up the startup projects. You would need to have the CSharp-rest-api and the Web projects as startup projects. This link likely a better option than explaining it here in the README file. https://stackoverflow.com/questions/60589263/visual-studio-solution-with-api-and-spa-how-to-run-at-the-same-time#:~:text=1)open%20visual%20studio%20and%20go%20to%20Solution%20Explorer.&text=3)By%20default%2C%20a%20single,projects%20loading%20in%20the%20browser.
5. Once the app is started. It will open 2 web windows, 1 web window is a system like Postman to test the API requests. The other web window is the website built for better user interations.

# Improvements and Features for the application
One of the things I can for sure improve on this app, is to have better validation and error handling checks. I have added basic error handling and validation, but it could be improved.
It could also have better flow and descriptions for each of the pages, one option could be to click a button from one of the animals that you like on the index for the Animals page. I mostly left them as tables to display data. The CSS styling could also be improved, like the buttons and location of the buttons.

# Deployment
With the experience I've had with deploying my personal website: https://anthonylevesque.com/ I believe that a Linux VPS(Virtual Private Server) may be a good option, it can most likely have everything setup on that one server. I've had trouble previously setting up the database for it, but I assume that using C# and MSSQL would work better than what I previously used for my Ruby app and its database setup. Linux servers are great, it can host any type of projects, whether its windows or IOS dependant, having a private VPS would also help with the uptime. Although, for the database, an AWS database setup might be a good option, from what I've read and heard all around. Let me know if you think there's a better option.

# Images for references
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/70cd0e48-02dd-48e0-a09b-aa8795794055)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/dfac5192-44fd-4e97-a9bf-c014b49d2222)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/004696b4-edbf-4470-9022-ac4907db71c9)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/a1d2b5e8-e642-4693-8b63-85f9a4497272)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/597ca03c-e386-4fee-994b-e7ee10c67c25)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/ab489743-47b9-4af1-b925-f2f9dee32d6a)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/31187dd0-5674-4f48-98fb-f67cf4131f5f)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/60bf3e56-9623-4909-b7e8-2bc386347058)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/575f10b5-d7de-4136-80d4-295b90070371)
![image](https://github.com/ALevesque03/CSFIntershipAssessment2024/assets/93732487/809210e6-4958-43d1-9636-0e35f47a4971)
