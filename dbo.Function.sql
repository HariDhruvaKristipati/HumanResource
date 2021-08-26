CREATE FUNCTION [dbo].[USER]
(
	@id int,
	@password nvarchar(50)
)
RETURNS bit

AS
BEGIN
   DECLARE 
      @pwd nvarchar(50),
	  @STATUS bit;
	  select @pwd=password from USER where id=@id
	  if @pwd=@password
	  begin 
	  set @STATUS=1;
	  end
	  else
	  begin 
	  set @STATUS=0;
	  end
	RETURN @STATUS;

END
