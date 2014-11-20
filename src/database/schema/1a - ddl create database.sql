/* +------------------------------------------------------------------------------------------------------------+ */
/* | Purpose: This script will create the database and set options.                                             | */
/* +------------------------------------------------------------------------------------------------------------+ */

use master;
go

if not exists (select * from sys.databases where name = 'ProviderDB')
  create database ProviderDb
      on (
           name = ProviderDb_Catalog,
           filename = 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012EXPRESS\MSSQL\DATA\ProviderDb_Catalog.mdf',
           size = 10mb,
           maxsize = 15mb,
           filegrowth = 1mb
         ),
         filegroup ProviderDb_Data (
           name = ProviderDb_Data,
           filename = 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012EXPRESS\MSSQL\DATA\ProviderDb_Data.ndf',
           size = 100mb,
           maxsize = 1000mb,
           filegrowth = 100mb
         )
         log on (
           name = ProviderDb_Log,
           filename = 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012EXPRESS\MSSQL\DATA\ProviderDb_Log.ldf',
           size = 25mb,
           maxsize = 250mb,
           filegrowth = 25mb
       );
go

use ProviderDb;
go

if not exists (select * from sys.filegroups where name = 'ProviderDb_Data')
  alter database ProviderDb modify filegroup ProviderDb_Data default;
go

alter database ProviderDb set recovery simple;
go
