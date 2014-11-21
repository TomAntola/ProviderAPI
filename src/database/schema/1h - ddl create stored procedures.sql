/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create all of the stored procedures for the database.                            | */
/* +------------------------------------------------------------------------------------------------------------+ */

use ProviderDb;
go

if exists (select object_id from sys.procedures where name = 'GetVehicle' and type = 'P')
  drop procedure dbo.GetVehicle;
go

/* +-------------------------------------------------------------------------------------------------------------------------+ */
/* | Author   - Tom Antola                                                                                                   | */
/* | Created  - 11/20/2014                                                                                                   | */
/* | Parms    - None                                                                                                         | */
/* | Purpose  - This procedure returns the searched for vehicle.                                                             | */
/* +-------------------------------------------------------------------------------------------------------------------------+ */
create procedure dbo.GetVehicle
(
 @Provider         varchar (50),
 @Company          varchar (50),
 @CarNo            varchar (15)
) as
begin

  set nocount on;

  select Provider			= p.provider_hierarchy_name,
         Company				= c.provider_hierarchy_name,
		 CarNo				= v.car_no,
		 VehicleType			= vt.vehicle_type,
		 MaxNoOfPassengers	= v.capacity,
		 IsActive			= v.is_active
    from dbo.vehicle v inner join dbo.provider_hierarchy c on v.provider_hierarchy_id = c.provider_hierarchy_id
	                   inner join dbo.provider_hierarchy p on c.parent_provider_hierarchy_id = p.provider_hierarchy_id
					   inner join dbo.vehicle_type vt on v.vehicle_type_id = vt.vehicle_type_id
  where p.provider_hierarchy_name = @Provider
    and c.provider_hierarchy_name = @Company
	and v.car_no = @CarNo;

end;
go

