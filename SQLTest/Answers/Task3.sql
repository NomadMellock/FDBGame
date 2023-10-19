USE DBATest
Go

SELECT CONCAT(authors.au_fname,' ', authors.au_lname) as Author FROM dbo.titleauthor as titleauthors
INNER Join dbo.authors as authors
ON (authors.au_id = titleauthors.au_id)
GROUP BY titleauthors.au_id, authors.au_fname, authors.au_lname
Having count(titleauthors.title_id) > 1
ORDER BY authors.au_lname

GO