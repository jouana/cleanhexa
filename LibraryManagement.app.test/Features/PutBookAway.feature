Feature: Put Book Away

  Scenario: Place a book on an empty shelf succeeds
    Given a library with 2 rows of 3 shelves each
    And a book with ISBN 111222333 exists in the catalog
    When I put the book with ISBN 111222333 at row 0, shelf 2
    Then the book is placed successfully

  Scenario: Cannot place a book on an occupied shelf
    Given a library with 1 row of 1 shelf
    And a book with ISBN 111222333 exists in the catalog
    And a book is already placed at row 0, shelf 0
    When I try to put the book with ISBN 111222333 at row 0, shelf 0
    Then the operation fails with message "Shelf is already occupied."

  Scenario: Cannot place a book at an invalid row
    Given a library with 1 row of 1 shelf
    And a book with ISBN 111222333 exists in the catalog
    When I try to put the book with ISBN 111222333 at row 5, shelf 0
    Then the operation fails with message "Invalid row index."