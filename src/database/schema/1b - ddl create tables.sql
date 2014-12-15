/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the application tables.                                            | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select name from sys.tables where name = 'company')
  create table dbo.company
  (
   company_id                                     tinyint             not null identity (1, 1),
   company_name                                   varchar   (50)      not null,
   is_active                                      bit                 not null,
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
   company_id                                     tinyint             not null,
   car_no                                         varchar   (15)      not null,
   vehicle_type_id                                tinyint             not null,
   capacity                                       tinyint             not null,
   state_abbreviation                             varchar    (6)      null,
   license_plate                                  varchar   (10)      null,
   last_inspection_date                           date                null,
   is_active                                      bit                 not null,
   insert_ts                                      datetime            not null,
   update_ts                                      datetime            null
  );
go

if not exists (select name from sys.tables where name = 'provider_api_user')
  create table dbo.provider_api_user
  (
   provider_api_user_id                           smallint            not null identity (1, 1),
   username                                       varchar    (50)     not null,
   [password]                                     varbinary  (64)     not null,
   salt                                           varbinary  (64)     not null,
   insert_ts                                      datetime            not null,
   update_ts                                      datetime            null
  );
go
