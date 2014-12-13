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
create procedure [dbo].[GetVehicle]
(
 @Provider         varchar (50),
 @Company          varchar (50),
 @CarNo            varchar (15)
) as
begin

  set nocount on;
  set transaction isolation level read uncommitted;

  select Provider			= p.provider_hierarchy_name,
         CompanyId			= cast(c.provider_hierarchy_id as varchar(15)),
         CompanyName			= c.provider_hierarchy_name,
		 CarNo				= v.car_no,
		 Year               = '2011',
		 Make               = 'Licoln',
		 Model              = 'Town Car',
		 Color              = 'Black',
		 VehicleType			= vt.vehicle_type,
		 MaxNoOfPassengers	= v.capacity,
		 VinNo              = 'RJ340SIO221UVBA',
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

if exists (select object_id from sys.procedures where name = 'AddEditProviderApiUser' and type = 'P')
  drop procedure dbo.AddEditProviderApiUser;
go

/* +-------------------------------------------------------------------------------------------------------------------------+ */
/* | Author   - Tom Antola                                                                                                   | */
/* | Created  - 12/3/2014                                                                                                    | */
/* | Parms    - Username - Username within the provider_api_user table.  Usernames must be unique.                           | */
/* |            Password - User's password.                                                                                  | */
/* |            Salt     - Unique salt used when encrypting user's password.                                                 | */
/* | Purpose  - This procedure will add a new user or update an existing one with the parameters passed in.                  | */
/* +-------------------------------------------------------------------------------------------------------------------------+ */
create procedure dbo.AddEditProviderApiUser
(
 @Username         varchar   (50),
 @Password         varbinary (64),
 @Salt             varbinary (64)
) as
begin

  set nocount on;

  update dbo.provider_api_user
     set password = @Password,
	     salt     = @Salt
   where username = @Username;

  if (@@ROWCOUNT = 0)
  begin
    insert into dbo.provider_api_user (username, password, salt)
    values (@Username, @Password, @Salt);
  end;

end;
go
