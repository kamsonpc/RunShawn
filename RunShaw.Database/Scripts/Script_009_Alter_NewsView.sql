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
	News.Categories.Color AS CategoryColor,
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