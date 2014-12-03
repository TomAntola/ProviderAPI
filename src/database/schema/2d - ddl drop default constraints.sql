/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the default constraints for the tables.                            | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select d.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.default_constraints d on t.object_id = d.parent_object_id where s.name = 'dbo' and t.name = 'provider_hierarchy' and d.name = 'df_provider_hierarchy_insert_ts')
  alter table dbo.provider_hierarchy drop constraint df_provider_hierarchy_insert_ts;

if exists (select d.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.default_constraints d on t.object_id = d.parent_object_id where s.name = 'dbo' and t.name = 'vehicle_type' and d.name = 'df_vehicle_type_insert_ts')
  alter table dbo.vehicle_type drop constraint df_vehicle_type_insert_ts;

if exists (select d.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.default_constraints d on t.object_id = d.parent_object_id where s.name = 'dbo' and t.name = 'vehicle' and d.name = 'df_vehicle_insert_ts')
  alter table dbo.vehicle drop constraint df_vehicle_insert_ts;

if exists (select d.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.default_constraints d on t.object_id = d.parent_object_id where s.name = 'dbo' and t.name = 'provider_api_user' and d.name = 'df_provider_api_user_insert_ts')
  alter table dbo.provider_api_user drop constraint df_provider_api_user_insert_ts;
go
