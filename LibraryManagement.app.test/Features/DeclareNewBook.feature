Feature: Declare New Book

  Scenario: Register a book with valid data saves the ISBN
    Given a book with ISBN 123456789, title "Clean Architecture" and author 1
    When I register the book
    Then the book is saved with ISBN 123456789 and title "Clean Architecture"

  Scenario: Register a book with valid data saves the author
    Given a book with ISBN 123456789, title "Clean Architecture" and author 1
    When I register the book
    Then the book is saved with author 1

  Scenario: Registering a book with a duplicate ISBN is rejected
    Given the ISBN 123456789 already exists in the catalog
    When I try to register a book with ISBN 123456789
    Then the registration fails with a conflict
