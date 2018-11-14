CREATE PROCEDURE spGetVehicles
AS
SELECT v.Id, v.Vin, v.ColorId, v.MakeId, v.ModelId, v.Year,
c.ColorCode, c.Description ColorName,
ma.Description MakeName,
mo.Description ModelNAME
FROM tblVehicle v
INNER JOIN tblColor c ON v.ColorId = c.Id
INNER JOIN tblMake ma ON v.MakeId = ma.Id
INNER JOIN tblModel mo ON v.ModelId = mo.Id
