CREATE procedure [dbo].[sp_getDoctorDropDownList]
(

@Page INT ,
@GetAll bit =0,
@PageSize INT 



)
as 
begin
SET NOCOUNT ON
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED		

		--IF(@SortDirection NOT IN (@ASC, @DESC)) SET @SortDirection = @ASC

		-- Set defaults for PageSize and Page, if value is negative or zero:
		IF(@Page < 1) SET @Page = 1
		IF(@PageSize < 1) SET @PageSize = 10
        
		-- Create output table as Response of this stored procedure
		DECLARE @SpResponseData TABLE(
		     Id             int,
			 Name      NVARCHAR(MAX)
			
			 
		);
		-- Get data from database table and then insert that data into @SpResponseData table
		WITH ListData AS (

			SELECT		
			                        u.Id               AS Id,
									
									(u.FirstName+' '+u.LastName)  As FullName


									from Users as u
									where  u.RoleId= '9'

	      )





INSERT INTO	@SpResponseData	SELECT * FROM ListData;

		-- pagination
		DECLARE @TotalRows		INT = 0;
		DECLARE @TotalPages		INT = 0;
		DECLARE @Offset	    	INT = 0;
		DECLARE @NextCount		INT = 0;
		DECLARE @AllUsersCount  INT = 0;
		
		
		SET @TotalRows	 = (SELECT COUNT(1) from @SpResponseData);
		SET @TotalPages	 = IIF(@TotalRows % @PageSize = 0, (@TotalRows / @PageSize), (@TotalRows / @PageSize) + 1);

		IF (@GetAll = 0)
			BEGIN				
				SET @Offset = @PageSize * (@Page - 1);
				SET @NextCount = @PageSize;
			END
		ELSE
			BEGIN
				SET @Offset = 0;
				SET @NextCount = @TotalRows;
			END

			-- Add a SELECT statement to return the data
--SELECT Id, Name
--FROM @SpResponseData
SELECT * FROM (SELECT * , @TotalRows as [TotalRecords] FROM @SpResponseData) AS Results
ORDER BY Id
OFFSET @Offset ROWS
FETCH NEXT @NextCount ROWS ONLY OPTION (RECOMPILE);
END



		









