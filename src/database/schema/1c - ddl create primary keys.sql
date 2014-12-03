/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the primary keys for the tables.                                   | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'provider_hierarchy' and c.type = 'pk')
  alter table dbo.provider_hierarchy add constraint pk_provider_hierarchy primary key clustered (provider_hierarchy_id);

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'vehicle_type' and c.type = 'pk')
  alter table dbo.vehicle_type add constraint pk_vehicle_type primary key clustered (vehicle_type_id);

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'vehicle' and c.type = 'pk')
  alter table dbo.vehicle add constraint pk_vehicle primary key clustered (provider_hierarchy_id, car_no);

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'provider_api_user' and c.type = 'pk')
  alter table dbo.provider_api_user add constraint pk_provider_api_user primary key clustered (provider_api_user_id);
go
