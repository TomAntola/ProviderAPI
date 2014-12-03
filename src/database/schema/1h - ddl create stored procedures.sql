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

if exists (select object_id from sys.procedures where name = 'GetProviderApiUser' and type = 'P')
  drop procedure dbo.GetProviderApiUser;
go

/* +-------------------------------------------------------------------------------------------------------------------------+ */
/* | Author   - Tom Antola                                                                                                   | */
/* | Created  - 12/2/2014                                                                                                    | */
/* | Parms    - Username - Username within the provider_api_user table.  Usernames must be unique.                           | */
/* | Purpose  - This procedure returns the user information for the supplied username. The password is verified in the       | */
/* |            application layer.                                                                                           | */
/* +-------------------------------------------------------------------------------------------------------------------------+ */
create procedure dbo.GetProviderApiUser
(
 @Username         varchar (50)
) as
begin

  set nocount on;

  select username, password, salt
    from dbo.provider_api_user
  where username = @Username;

end;
go
