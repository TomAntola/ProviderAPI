/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will drop all of the foreign keys for the tables.                                     | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select name from sys.foreign_keys where name = 'fk_vehicle_company')
  alter table dbo.vehicle drop constraint fk_vehicle_company;

if exists (select name from sys.foreign_keys where name = 'fk_vehicle_vehicle_type')
  alter table dbo.vehicle drop constraint fk_vehicle_vehicle_type;
go
