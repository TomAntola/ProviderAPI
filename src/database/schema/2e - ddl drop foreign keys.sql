/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the foreign keys for the tables.                                     | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select name from sys.foreign_keys where name = 'fk_provider_hierarchy_provider_hierarchy')
  alter table dbo.provider_hierarchy drop constraint fk_provider_hierarchy_provider_hierarchy;

if exists (select name from sys.foreign_keys where name = 'fk_vehicle_provider_hierarchy')
  alter table dbo.vehicle drop constraint fk_vehicle_provider_hierarchy;

if exists (select name from sys.foreign_keys where name = 'fk_vehicle_vehicle_type')
  alter table dbo.vehicle drop constraint fk_vehicle_vehicle_type;
go
