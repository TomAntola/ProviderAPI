/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will populate the database with some default testing data.                            | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if not exists (select provider_hierarchy_id from dbo.provider_hierarchy where provider_hierarchy_name = 'ETG')
begin
  set identity_insert dbo.provider_hierarchy on;
  insert into dbo.provider_hierarchy (provider_hierarchy_id, provider_hierarchy_name, is_active, parent_provider_hierarchy_id)
  select isnull(max(provider_hierarchy_id), 1), 'ETG', 1, isnull(max(provider_hierarchy_id), 1)
    from dbo.provider_hierarchy;
  set identity_insert dbo.provider_hierarchy off;
end;
go

-- Insert Provider Hierarchy
if not exists (select provider_hierarchy_id from dbo.provider_hierarchy where provider_hierarchy_name = 'Love')
  insert into dbo.provider_hierarchy (provider_hierarchy_name, is_active, parent_provider_hierarchy_id)
  select 'Love', 1, provider_hierarchy_id
    from dbo.provider_hierarchy
   where provider_hierarchy_name = 'ETG';
go

if not exists (select provider_hierarchy_id from dbo.provider_hierarchy where provider_hierarchy_name = 'NYOne')
  insert into dbo.provider_hierarchy (provider_hierarchy_name, is_active, parent_provider_hierarchy_id)
  select 'NYOne', 1, provider_hierarchy_id
    from dbo.provider_hierarchy
   where provider_hierarchy_name = 'ETG'
go

select * from dbo.provider_hierarchy
go

-- Insert Vehicle Type
with available_type (vehicle_type) as
(
 select 'Sedan' union select 'SUV' union select 'Van' union select 'Limo'
)
insert into dbo.vehicle_type (vehicle_type)
select l.vehicle_type
  from available_type l left join dbo.vehicle_type r on l.vehicle_type = r.vehicle_type
 where r.vehicle_type is null;
go

select * from dbo.vehicle_type
go

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'Love') and car_no = 'L-001')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'Love'),
         'L-001',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Sedan'),
	     4,
	     dateadd(week, -43, current_timestamp),
	     1;
go

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'Love') and car_no = 'L-002')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'Love'),
         'L-002',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Sedan'),
	     4,
	     dateadd(week, -26, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'Love') and car_no = 'L-101')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'Love'),
         'L-101',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'SUV'),
	     6,
	     dateadd(week, -34, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne') and car_no = 'NY-001')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne'),
         'NY-001',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Sedan'),
	     4,
	     dateadd(week, -44, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne') and car_no = 'NY-101')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne'),
         'NY-101',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'SUV'),
	     6,
	     dateadd(week, -51, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne') and car_no = 'NY-201')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne'),
         'NY-201',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Limo'),
	     8,
	     dateadd(week, -11, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where provider_hierarchy_id = (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne') and car_no = 'NY-301')
  insert into dbo.vehicle (provider_hierarchy_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select provider_hierarchy_id from provider_hierarchy where provider_hierarchy_name = 'NYOne'),
         'NY-301',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Van'),
	     10,
	     dateadd(week, -6, current_timestamp),
	     1;

select * from dbo.vehicle
go
