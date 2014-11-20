/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the application tables.                                            | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select name from sys.tables where name = 'provider_hierarchy')
  create table dbo.provider_hierarchy
  (
   provider_hierarchy_id                          tinyint             not null identity (1, 1),
   provider_hierarchy_name                        varchar   (50)      not null,
   is_active                                      bit                 not null,
   parent_provider_hierarchy_id                   tinyint             not null,
   insert_ts                                      datetime            not null,
   update_ts                                      datetime            null
  );
go

if not exists (select name from sys.tables where name = 'vehicle_type')
  create table dbo.vehicle_type
  (
   vehicle_type_id                                tinyint             not null identity (1, 1),
   vehicle_type                                   varchar   (25)      not null,
   insert_ts                                      datetime            not null,
   update_ts                                      datetime            null
  );
go

if not exists (select name from sys.tables where name = 'vehicle')
  create table dbo.vehicle
  (
   provider_hierarchy_id                         tinyint             not null,
   car_no                                         varchar   (15)      not null,
   vehicle_type_id                                tinyint             not null,
   capacity                                       tinyint             not null,
   last_inspection_date                           date                null,
   is_active                                      bit                 not null,
   insert_ts                                      datetime            not null,
   update_ts                                      datetime            null
  );
go
