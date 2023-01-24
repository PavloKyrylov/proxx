# proxx

Part 1:
Two dimension array as structure for game field is chosen because the size of game field is known in advance and all elements in algorithm are accessed by index.
Also in order to store black holes, count of adjacent black holes and the sign whether cell is visible or not the "Cell" type was chosen. "Cell" is struct type, because of it all cells store close to each other in array (unlike classes).
This type can be expanded with minimal efforts in the next versions of application (for example we can add flag functionality).


Part 2:
"RandomSequenceGenerator" class is created to populate the place of black holes. This class uses native .NET "Random" class to create pseudo random numbers in uniform distribution.
"RandomSequenceGenerator.NextSequence" method returns single dimension array (to be precise "IEnumerable<>"). 
Single dimension array is chosen because with this aproach we can write uniform algorithm in the next versions of application. For example we will need game field with rectangle, triangle or some three dimension shape form. In this case we just add converter from single dimension array to N-dimension array data structure without toching algorithm of random sequence generating.
Because random can generate black hole places which has already been added it necessary to store this places in "HashSet". "HashSet" is chosen because it has O(1) time for accessing by key.


Part 3:
After generating black holes the next task is to calculate the values of other cells. Because two dimension array is used, we can enumerate all array elements for O(1) time, and also count all nearby elements whish is black hole.

Part 4:
"Flood fill" is used to write logic which updates cell after click. This algoritm is encapsulated in "RectangleGameField.OpenZeroCellsNearby" method.

The other important considerations:
The core of the application are "GameEngine" and "GameField" (to be precise "RectangleGameField", "SquareGameField") classes. "GameEngine" works with "IGameField" interface and it allows us to extend application with another GameField (for example in next versions of the application) without regression on game rules (which is concentrated in "GameEngine").
Also "IGameField" is generic interface. In current inplementation it closes only on two dimension index (we have only two dimension game fields), but we can extend it and for example add three dimension index in next versions of application with minor code changes in consumers of game.

