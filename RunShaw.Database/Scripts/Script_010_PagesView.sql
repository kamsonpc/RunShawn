CREATE VIEW Pages.PagesListView
AS
SELECT  
	Pages.Pages.Id,
	Pages.Pages.Title,
	Pages.Pages.Active,
	Pages.Pages.[Content],
	Pages.Pages.UrlSlug,
	Pages.Pages.CreatedBy,
	Pages.Pages.CreatedDate,
	Pages.Pages.ModifiedBy,
	Pages.Pages.ModifiedDate, 
    Pages.Pages.DeletedBy,
	Pages.Pages.DeletedDate,
	dbo.AspNetUsers.UserName AS CreatedByName
FROM	
		Pages.Pages 
	CROSS JOIN
        dbo.AspNetUsers