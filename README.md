ProviderAPI
===========

This repository contains the shell to create a REST API for providers that what to communicate with Sedan Magic.

To get your local environment set up so you can develop, I recommend three things; first, Visual Studio 2013, second, a local instance
of SQL Server running.  I am using SQL Server Express 2014.  Finally, a tool for testing the API.  I am currently using the free tool
from Telerik, Fiddler.  You can download it at http://www.telerik.com/download/fiddler.

Once you have these three components and have made a local copy of the repository, open SQL Server Management Studio and navigate to the 
database DDL scripts.  They can be found in {GitRoot}\ProviderAPI\src\database\schema.  I have my {GitRoot} set to C:\GitProjects.  So far
there are no dependencies on the root being in this location but I make no guarantees that will not change.  Open up and run the DDL scripts
that start with the number one in order, "1a - ddl create database.sql", "1b - ddl create tables.sql", ..., "1h - ddl create stored procedures.sql".
This will give you a fully functional database for the project.  Now populate it with some test data.  Navigate to {GitRoot}\ProviderAPI\src\database\data
and run the "Initialize Database.sql" script.  All scripts are written to be re-entrant.  That means you can run them as many times as you want with no
harmful side effects.  This is in case you forget where you left off on any step.  Also, if you need to revert a particular DDL step, just run its 
counterpart drop script that starts with "2...".  These are in the reverse order of the create script so you can run "2a - ..." and it will undo the
most recent create DDL script you ran.

Finally, you will need to change your connection string.  It is located in the web.config file in the Web.Inbound project.  Once you have your local database
instance created and populated with test data and have changed your connection string, you are ready to test the API.  Run the Visual Studio solution.  You
should see the default.htm page that list the API methods that will eventually be added.  Now fire up Fiddler and navigate to the Composer tab.  Enter the
base URI from your web browser that opened when you started the project.  Mine reads, "http://localhost:2741/Default.htm".  Change the port to match yours.
Bounce over to Fiddler's Composer tab and paste you URI into box next to the HTTP GET Verb.  Replace the Default.htm from the URI with the path to the 
vehicle URI.  Mine reads as follows "http://localhost:2741/vehicle/Rolling%20Thunder%20Enterprises/Black%20Diamond%20Sedans/BDS-001".  The "vehicle" portion
of the URI in the Web API Controller called and the remaining portions of the URI path are the parameters to the vehicle's GET method (i.e. Rolling Thunder 
Enterprises is the provider, Black Diamond Sedans is the company and BDS-001 is the carNo).  Click on the execute button in Fiddler and you should get back a 
JSON representation of the vehicle resource in your database.  It should look something like this:

{"Provider":"Rolling Thunder Enterprises","Company":"Black Diamond Sedans","CarNo":"BDS-001","VehicleType":"Sedan","MaxNoOfPassengers":4,"IsActive":true}.

Click on the Fiddler's Inspector tab then the Raw header in the bottom view to see it.  That's it, you should be up and running and ready for testing!

-- Test GetVehicle.
execute dbo.GetVehicle 'Rolling Thunder Enterprises', 'Black Diamond Sedans', 'BDS-001';
