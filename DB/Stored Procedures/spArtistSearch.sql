CREATE PROCEDURE dbo.spArtistSearch
	@name NVARCHAR (30)
AS
	SELECT artistID, dateCreation, title, biography,imageURL,heroURL 
	FROM Artist 
	WHERE title LIKE  @name;
RETURN 0
