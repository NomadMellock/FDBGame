USE DBATest
Go

SELECT titles.title FROM dbo.titles as titles
INNER JOIN dbo.titleauthor as titleauthors
ON (titleauthors.title_id = titles.title_id)
INNER Join dbo.authors as  authors
ON (authors.au_id = titleauthors.au_id)
WHERE authors.au_fname = 'Stearns' and authors.au_lname = 'MacFeather'
ORDER BY titles.ytd_sales DESC

GO