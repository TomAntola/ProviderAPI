/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the unique keys for the tables.                                    | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'company' and c.name = 'uk1_company' and c.type = 'uq')
  alter table dbo.company add constraint uk1_company unique nonclustered (company_name);

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'vehicle_type' and c.name = 'uk1_vehicle_type' and c.type = 'uq')
  alter table dbo.vehicle_type add constraint uk1_vehicle_type unique nonclustered (vehicle_type);

if not exists (select c.name from sys.schemas s inner join sys.tables t on s.schema_id = t.schema_id inner join sys.key_constraints c on t.object_id = c.parent_object_id where s.name = 'dbo' and t.name = 'provider_api_user' and c.name = 'uk1_provider_api_user' and c.type = 'uq')
  alter table dbo.provider_api_user add constraint uk1_provider_api_user unique nonclustered (username);
go
