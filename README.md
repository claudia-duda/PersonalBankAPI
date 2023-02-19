# PersonalBankAPI
API to handler with the personal finance balance



<p align="center">
this API was developed aiming to be a service for registering personal expenses, in which you will be able to register your deposits, transfers, and withdraw made according to the balance you have
</p>

<p align="center">
  <a href="#-downloading-the-project">Downloading</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-installing-dependencies">Installing</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; 
  <a href="#-configuring-the-project">Configuring</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; 
  <a href="#-running-the-project">Running</a>&nbsp;&nbsp;&nbsp;
</p>

<br>

## 🚀 Downloading the Project

1. Go to the project's GitHub page and click the "Clone or download" button.
2. Copy the URL to your clipboard.
3. Open your preferred command line interface (e.g. Git Bash, Windows Command Prompt, PowerShell).
4. Navigate to the directory where you want to store the project.
5. Type the command git clone followed by the URL you copied earlier. Press enter.
6. Wait for the download to complete.

## 🧮 Installing Dependencies

1. Install SQL Server to use the database locally
2. Open the project in Visual Studio.
2. Wait for the solution to load and for Visual Studio to install any necessary packages and dependencies.
3. Open the Package Manager Console by clicking on "Tools" > "NuGet Package Manager" > "Package Manager Console".
4. In the console, type dotnet restore and press enter. This will restore any missing dependencies.
5. Build the project by clicking on "Build" > "Build Solution".

## 💻 Configuring the Project
1. Create a new file named appsettings.Development.json in the project's root directory.
2. Copy the contents of the appsettings.json file into the new file.
3. Replace any placeholder values (e.g. database connection strings accourding to your SQl Server) with the appropriate values for your local environment.
Save the file.

## ▶️ Running the Project
1. Choose PersonalBank.API and set the startup project by right-clicking on the desired project in the Solution Explorer and selecting "Set as Startup Project".
2. Run the project by clicking on the "Play" button in the toolbar, or by pressing F5.
3. Wait for the project to build and for the browser to open.
4. The project should now be running and accessible at the URL displayed in the browser.

<p align="center">
☑️ You are now ready to explore this API :)
</p>
