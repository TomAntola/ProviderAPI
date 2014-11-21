/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the stored procedures from the database.                             | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select object_id from sys.procedures where name = 'GetVehicle' and type = 'P')
  drop procedure dbo.GetVehicle;
go
