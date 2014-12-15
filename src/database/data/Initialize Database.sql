/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will populate the database with some default testing data.                            | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

-- Insert Company
if not exists (select company_id from dbo.company where company_name = 'Black Diamond Sedans')
  insert into dbo.company (company_name, is_active)
  values ('Black Diamond Sedans', 1);
go

if not exists (select company_id from dbo.company where company_name = 'Vector Limos')
  insert into dbo.company (company_name, is_active)
  values ('Vector Limos', 1);
go

select * from dbo.company;
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

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Black Diamond Sedans') and car_no = 'BDS-001')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Black Diamond Sedans'),
         'BDS-001',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Sedan'),
	     4,
	     dateadd(week, -43, current_timestamp),
	     1;
go

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Black Diamond Sedans') and car_no = 'BDS-002')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Black Diamond Sedans'),
         'BDS-002',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Sedan'),
	     4,
	     dateadd(week, -26, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Black Diamond Sedans') and car_no = 'BDS-101')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Black Diamond Sedans'),
         'BDS-101',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'SUV'),
	     6,
	     dateadd(week, -34, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Vector Limos') and car_no = 'VL-001')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Vector Limos'),
         'VL-001',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Sedan'),
	     4,
	     dateadd(week, -44, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Vector Limos') and car_no = 'VL-101')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Vector Limos'),
         'VL-101',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'SUV'),
	     6,
	     dateadd(week, -51, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Vector Limos') and car_no = 'VL-201')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Vector Limos'),
         'VL-201',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Limo'),
	     8,
	     dateadd(week, -11, current_timestamp),
	     1;

if not exists (select * from dbo.vehicle where company_id = (select company_id from company where company_name = 'Vector Limos') and car_no = 'VL-301')
  insert into dbo.vehicle (company_id, car_no, vehicle_type_id, capacity, last_inspection_date, is_active)
  select (select company_id from company where company_name = 'Vector Limos'),
         'VL-301',
	     (select vehicle_type_id from dbo.vehicle_type where vehicle_type = 'Van'),
	     10,
	     dateadd(week, -6, current_timestamp),
	     1;

select * from dbo.vehicle
go
