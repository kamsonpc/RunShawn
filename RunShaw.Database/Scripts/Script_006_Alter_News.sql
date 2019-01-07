ALTER TABLE [News].[News] 
ADD Featured BIT NULL
GO

UPDATE 
	[News].[News]
SET 
	Featured = 0;
GO

ALTER TABLE [News].[News] 
	ALTER COLUMN Featured BIT NOT NULL
GO

ALTER VIEW News.NewsListView
AS
SELECT        
	News.News.Id,
	News.News.Title,
	News.News.Featured,
	News.News.[Content],
	News.News.CategoryId,
	News.News.DeletedDate,
	News.News.DeletedBy,
	News.News.ModifiedDate,
	News.News.ModifiedBy,
	News.News.CreatedDate, 
	News.News.CreatedBy,
	News.News.PublishDate,
	News.Categories.Title AS CategoryTitle,
	dbo.AspNetUsers.UserName AS CreatedByName
FROM            
		News.News 
	INNER JOIN
		News.Categories 
	ON 
		News.News.CategoryId = News.Categories.Id 
	CROSS JOIN
		dbo.AspNetUsers
GO