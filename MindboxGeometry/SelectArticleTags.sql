-- Assuming the following table structure
--Article
--	ID
--	Title
--
--Tag
--	ID
--	Caption
--
--ArticleTag
--	ID
--	ArticleID
--	TagID

-- Get all Article.Title - Tag.Caption pairs including Articles without Tags
select a.Title [Article Title], t.Caption [Tag]
from mbx.Article a
left outer join mbx.ArticleTag atag on a.ID = atag.ArticleID
left outer join mbx.Tag t on atag.TagID = t.ID