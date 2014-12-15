/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the foreign keys for the tables.                                   | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select name from sys.foreign_keys where name = 'fk_vehicle_company')
  alter table dbo.vehicle add constraint fk_vehicle_company foreign key (company_id) references dbo.company (company_id);

if not exists (select name from sys.foreign_keys where name = 'fk_vehicle_vehicle_type')
  alter table dbo.vehicle add constraint fk_vehicle_vehicle_type foreign key (vehicle_type_id) references dbo.vehicle_type (vehicle_type_id);
go
