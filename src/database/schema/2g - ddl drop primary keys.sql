/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the primary keys for the tables.                                     | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'provider_hierarchy' and c.type = 'pk')
  alter table dbo.provider_hierarchy drop constraint pk_provider_hierarchy;

if exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'vehicle_type' and c.type = 'pk')
  alter table dbo.vehicle_type drop constraint pk_vehicle_type;

if exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'vehicle' and c.type = 'pk')
  alter table dbo.vehicle drop constraint pk_vehicle;
go