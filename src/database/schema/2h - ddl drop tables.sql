/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the application tables.                                              | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select t.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id where s.name = 'dbo' and t.name = 'vehicle')
  drop table dbo.vehicle;

if exists (select t.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id where s.name = 'dbo' and t.name = 'vehicle_type')
  drop table dbo.vehicle_type;

if exists (select t.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id where s.name = 'dbo' and t.name = 'provider_hierarchy')
  drop table dbo.provider_hierarchy;

if exists (select t.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id where s.name = 'dbo' and t.name = 'provider_api_user')
  drop table dbo.provider_api_user;
go
