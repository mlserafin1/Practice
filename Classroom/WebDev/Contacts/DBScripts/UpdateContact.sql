-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE UpdateContact 
	-- Add the parameters for the stored procedure here
		@FirstName varchar(50), 
	@LastName  varchar(50),
	@Phone  varchar(11),
	@Email  varchar(50),
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE       Contacts
SET                FirstName =@FirstName, LastName =@LastName, Email =@Email, Phone =@Phone
WHere ID = @ID
END
GO
