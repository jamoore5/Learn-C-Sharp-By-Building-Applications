# Learn C\# By Building Applications
Some code from a C# Udemy course

## Simple Calculator
As a user I would like to be able to provide two numbers and one of the four basic operations (add(+), subtract(-), multiply(*), (divide(/)) and then see the result of the operation.

## Word Unscrambler

As a user I would like to be able to continuously provide a list of words to be unscrambled either manually or as a file containing them. 

The process of unscrambling the words will be based on an external file. 

The user should have access to this file and could modify, add or remove words as necessary. 

The process of comparing the words together should not care for any language specific rules and should be case insensitive.

You can get creative with the information being displayed to the user as long as it directly conveys the meaning of what the user needs to do based on the acceptance criteria.

(I modified this exercise to have better performance with a larger wordlist and added some more test coverage)

## Simple Web Scraper

As a user I would like to be able to scrape links and their associated description from Craigslist's category and city that I specify.

(I modified the Scraper to create ScrappedElements instead of just strings and added a Name to the ScrapeCriteriaPart so that I could retrieve the Parts in a more structured way. Then I tried to scrape my local funeral pages and ran into the problem that most of them use Javascript to load the obituaries)
