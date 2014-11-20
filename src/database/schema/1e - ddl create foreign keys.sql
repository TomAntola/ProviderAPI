/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the foreign keys for the tables.                                   | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select name from sys.foreign_keys where name = 'fk_provider_hierarchy_provider_hierarchy')
  alter table dbo.provider_hierarchy add constraint fk_provider_hierarchy_provider_hierarchy foreign key (parent_provider_hierarchy_id) references dbo.provider_hierarchy (provider_hierarchy_id);

if not exists (select name from sys.foreign_keys where name = 'fk_vehicle_provider_hierarchy')
  alter table dbo.vehicle add constraint fk_vehicle_provider_hierarchy foreign key (provider_hierarchy_id) references dbo.provider_hierarchy (provider_hierarchy_id);

if not exists (select name from sys.foreign_keys where name = 'fk_vehicle_vehicle_type')
  alter table dbo.vehicle add constraint fk_vehicle_vehicle_type foreign key (vehicle_type_id) references dbo.vehicle_type (vehicle_type_id);
go
