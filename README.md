CLDV6212_POE_ST10393673_

 Summary

The code for the `ST10393673_CLDV6212_POE` project, a portfolio of evidence (POE) for the CLDV6212 module, is available in this repository. Web applications written with ASP.NET Core, C#, and many Azure services comprise the project. It is intended to leverage Azure Storage services to handle an online retail system, including user registration and product administration.

 Project Specifics

The project code is ST10393673_CLDV6212_POE. The student number is [Your Student Number]. The module code is CLDV6212.
Technologies Employed:
  - Azure Blob Storage - C# - ASP.NET Core
  - File Shares on Azure
  - Azure Stack
  - Tables in Azure
  - GitHub

Features

- Home Page: Provides links to other pages while providing a summary of the program.
- items Page: Contains a list of the items that are offered as well as an image upload feature.
- Register Page: Enables people to sign up by entering their information.
- Special deals Page: Shows any active special deals that are available.
- Contact Us Page: Offers a form for users to get in touch with the customer service staff.
- About Us Page: Offers details about the program or company.

 Instructions for Setup

 Required conditions

- Azure Storage Account - Visual Studio 2022 or later -.NET 8 SDK

 Setup

1. Make a copy of the repository at https://github.com/MathewMizrachi/ST10393673_CLDV6212_POE.git.
  

2. Install Dependencies: Launch Visual Studio, open the solution, and import the NuGet packages.

3. Set up Azure Storage: - Change the `appsettings.json` file to include your Azure Storage connection string and further configuration information.
   - Verify that the containers (Blob, File, and Queue) and Azure Storage account are configured.

4. Launch the Program:
   - Configure HTTPS for use in the project.
   Execute the project in Visual Studio after building it.

 Launching the Program

1. Open Visual Studio and run the program.
2. To view various pages, go to the following URLs:
   - Products: {/Products} - Home: {/}
   - Sign up here: `/Register}
   - Exclusive Deals: {/SpecialOffers}
   - Send an email to {/ContactUs}.
   - Contact Us at `/AboutUs}
     
Overview of the Code

 Controllers

- HomeController: Oversees user registration, product uploads, and home page views and interactions.
  
 Services

- BlobService: Manages Azure Blob Storage-related tasks.
- FileService: Azure File Shares are managed.
QueueService: Manages the operations for Azure Queue.
- TableService: Oversees user and product Azure Table Storage.

 Models

ProductViewModel: Serves as a representation of product data for views and storage functions.
- RegisterViewModel: Displays information about user registration.

 Troubleshooting

- Push Protection Errors: Make sure that no sensitive material is included in your contributions if you experience problems with GitHub's push protection. Clear your code of secrets and set up environment variables.

 Deployment

Azure App Service is where the application is deployed. confirming that every setting is OK for the Azure deployment.




 
