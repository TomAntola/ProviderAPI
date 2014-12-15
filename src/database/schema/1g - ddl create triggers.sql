/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the triggers for the tables.                                       | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select name from sys.triggers where name = 'company_setupdatets')
  execute ('create trigger dbo.company_setupdatets on dbo.company after update as begin set nocount on; if not update(update_ts) update dbo.company set update_ts = current_timestamp from dbo.company u inner join inserted i on u.company_id = i.company_id end;');

if not exists (select name from sys.triggers where name = 'vehicle_type_setupdatets')
  execute ('create trigger dbo.vehicle_type_setupdatets on dbo.vehicle_type after update as begin set nocount on; if not update(update_ts) update dbo.vehicle_type set update_ts = current_timestamp from dbo.vehicle_type u inner join inserted i on u.vehicle_type_id = i.vehicle_type_id end;');

if not exists (select name from sys.triggers where name = 'vehicle_setupdatets')
  execute ('create trigger dbo.vehicle_setupdatets on dbo.vehicle after update as begin set nocount on; if not update(update_ts) update dbo.vehicle set update_ts = current_timestamp from dbo.vehicle u inner join inserted i on u.company_id = i.company_id and u.car_no = i.car_no end;');

if not exists (select name from sys.triggers where name = 'provider_api_user_setupdatets')
  execute ('create trigger dbo.provider_api_user_setupdatets on dbo.provider_api_user after update as begin set nocount on; if not update(update_ts) update dbo.provider_api_user set update_ts = current_timestamp from dbo.provider_api_user u inner join inserted i on u.provider_api_user_id = i.provider_api_user_id end;');
go
