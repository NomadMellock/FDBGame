USE DBATest
Go

SELECT authors.au_id, CONCAT(authors.au_fname,' ', authors.au_lname) as Author FROM dbo.titleauthor as titleauthors
INNER Join dbo.authors as authors
ON (authors.au_id = titleauthors.au_id) 
GROUP BY titleauthors.au_id, authors.au_fname, authors.au_lname, authors.au_id
Having count(titleauthors.title_id) > (SELECT Count(titles.title_id) FROM titles WHERE titles.title_id = authors.au_id)
ORDER BY authors.au_lname
