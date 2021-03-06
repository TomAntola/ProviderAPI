/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the triggers for the tables.                                         | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select r.* from sys.tables t inner join sys.triggers r on t.object_id = r.parent_id where t.name = 'company' and r.name = 'company_setupdatets')
  drop trigger dbo.company_setupdatets;

if exists (select r.* from sys.tables t inner join sys.triggers r on t.object_id = r.parent_id where t.name = 'vehicle_type' and r.name = 'vehicle_type_setupdatets')
  drop trigger dbo.vehicle_type_setupdatets;

if exists (select r.* from sys.tables t inner join sys.triggers r on t.object_id = r.parent_id where t.name = 'vehicle' and r.name = 'vehicle_setupdatets')
  drop trigger dbo.vehicle_setupdatets;

if exists (select r.* from sys.tables t inner join sys.triggers r on t.object_id = r.parent_id where t.name = 'provider_api_user' and r.name = 'provider_api_user_setupdatets')
  drop trigger dbo.provider_api_user_setupdatets;
go
