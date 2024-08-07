USE [082024]
GO
/****** Object:  StoredProcedure [dbo].[InsertPersonalData]    Script Date: 8/4/2024 7:10:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertPersonalData]
    @PersonalData dbo.PersonalServer READONLY,
	@UmurData dbo.UmurServer READONLY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblT_Personal (Id, Nama, IdGender, IdHobi, Umur)
    SELECT Id, Nama, IdGender, IdHobi, Umur FROM @PersonalData;
	
    MERGE INTO tblT_Umur AS target
    USING @UmurData AS source
    ON target.Umur = source.Umur
    WHEN MATCHED THEN 
        UPDATE SET target.Total = target.Total + source.Total
    WHEN NOT MATCHED THEN
        INSERT (Umur, Total) VALUES (source.Umur, source.Total);

END;