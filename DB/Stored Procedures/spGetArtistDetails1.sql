CREATE PROCEDURE dbo.spGetArtistDetails1
	@artistID int = 1
AS
BEGIN
	SET NOCOUNT ON
	-- Insert statements for procedure here
	SELECT 
		a.title,
		a.biography, 
		a.imageURL, 
		a.heroURL,
		s.songID, 
		s.title, 
		s.bpm,
		al.albumID, 
		al.title, 
		al.imageURL
	FROM Artist a 
		INNER JOIN Song s ON a.artistID= a.artistID
		INNER JOIN Album al ON a.artistID = al.artistID 
	WHERE a.artistID = @artistID
END
