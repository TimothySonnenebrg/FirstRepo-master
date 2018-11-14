declare @colorid uniqueidentifier;
declare @makeid uniqueidentifier;
declare @modelid uniqueidentifier;


select @colorid = Id from tblColor
where Description = 'Cornflower Blue'

select @modelid = Id from tblModel
where Description = 'Mustang'

select @makeid = Id from tblMake

where Description = 'Ford'

insert into tblVehicle 
select NEWID(), @colorid, @makeid, @modelid,'HA2898S42GH2S3239', 1967

-----------------------------------------------------

select @colorid = Id from tblColor
where Description = 'Hunter Green'

select @modelid = Id from tblModel
where Description = 'Esprit'

select @makeid = Id from tblMake
where Description = 'Lotus'


insert into tblVehicle 
select NEWID(), @colorid, @makeid, @modelid,'2HA2898SN827H2589', 2018

----------------------------------------------------------------------------

select @colorid = Id from tblColor
where Description = 'Rebecca Purple'

select @modelid = Id from tblModel
where Description = 'Silverado'

select @makeid = Id from tblMake
where Description = 'Chevy'


insert into tblVehicle 
select NEWID(), @colorid, @makeid, @modelid,'2HA2898SN8287H389', 1967

--------------------------------------------------------------------------

select * from tblVehicle