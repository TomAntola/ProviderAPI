/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the unique constraints for the tables.                               | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'provider_hierarchy' and c.name = 'uk1_provider_hierarchy' and c.type = 'uq')
  alter table dbo.provider_hierarchy drop constraint uk1_provider_hierarchy;

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'vehicle_type' and c.name = 'uk1_vehicle_type' and c.type = 'uq')
  alter table dbo.vehicle_type drop constraint uk1_vehicle_type;
go
