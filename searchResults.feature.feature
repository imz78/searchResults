Feature: AS A Search Engine Optimiser
         I WANT to be able to search google.co.uk using the Google Chrome browser with any given search term
         SO THAT I can determine if a given website is in the first page of search results


Scenario Outline: Search on google
          Given I open google in Chrome Webrowser
          When I enter "<SearchTerm>" in search textbox
		  And I click on the search button
          Then I should see <Result> on the first page


Data Set:

|Equiniti Crawley | http://https://equiniti.com/uk/locations | first page | PASS
|Shogun wiktionary | https://en.wiktionary.org/wiki/shogun | first page | PASS