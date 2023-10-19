USE DBATest
Go

SELECT TOP 1 titles.title, CONCAT(authors.au_fname,' ', authors.au_lname) as Author FROM dbo.titles as titles
INNER JOIN dbo.titleauthor as titleauthors
ON (titleauthors.title_id = titles.title_id)
INNER Join dbo.authors as  authors
ON (authors.au_id = titleauthors.au_id)
WHERE titles.type = 'psychology' and titles.pubdate BETWEEN '1991-01-01' AND '1991-12-31'
ORDER BY titles.ytd_sales
GO