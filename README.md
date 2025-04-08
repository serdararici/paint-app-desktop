# Paint Application - Desktop

A **Windows Forms-based drawing application** that implements Object-Oriented Programming principles to create a flexible and extensible paint program.

![Project Preview](https://github.com/serdararici/paint-app-desktop/blob/main/images/project_images/PaintApp_3.JPG)


## Features

-  **Free Drawing**: Use the pencil tool for freehand drawing
-  **Shape Drawing**: Create various geometric shapes including rectangles, ellipses, triangles, and hexagons
-  **Color Selection**: Choose from a palette of colors for your drawings
-  **Selection Tool**: Select shapes to manipulate or delete them
-  **Eraser Tool**: Erase parts of your drawing
-  **File Operations**: Save and load your drawings with custom `.shapes` format
-  **New Canvas**: Clear the drawing area to start a fresh drawing

 
##  Object-Oriented Programming Concepts
This project emphasizes OOP principles:

###  Abstraction
- Created an abstract Shape base class that defines common properties and behaviors for all shapes.
- All shape classes implement their own drawing logic through overridden methods.

###  Inheritance
Specialized shape classes inherit from the abstract Shape class:
- `RectangleShape`
- `EllipseShape`
- `TriangleShape`
- `HexagonShape`

###  Encapsulation
- Shape properties are encapsulated within classes.
- Drawing logic is contained within specific shape implementations.

###  Polymorphism
- The `Draw()` method is implemented differently by each shape class.
- The application treats all shapes polymorphically using their base class interface.


##  Class Hierarchy

![Class Hierarchy](https://github.com/serdararici/paint-app-desktop/blob/main/images/project_images/Class_Hierarchy.JPG)


## What I Learned
During this project, I gained experience in:

- Implementing OOP principles in a real-world application.
- Working with the Graphics system in Windows Forms.
- Handling mouse events to create interactive UI.
- Using JSON serialization for data persistence.
- Managing UI state and visual feedback for user interactions.
- Creating a boundary-aware drawing system that prevents shapes from exceeding canvas limits.


## Technologies Used

- **C# programming language** (Object-Oriented Programming)
- **Windows Forms** for UI
- `System.Drawing` graphics operations
- **JSON** JSON serialization for file operations


## Drawing Workflow
The drawing process follows these steps:

1. User selects a shape type and color.
2. User clicks and drags on the canvas to define shape dimensions.
3. The shape is created and added to the collection of shapes.
4. All shapes are redrawn on each refresh of the canvas.


## File Operations

Drawings are saved in a custom `.shapes` format using JSON serialization:
- Each shape's type, coordinates, and color information are saved.
- When loading, the application reconstructs shapes from the saved data.
  

## How to Use

1. Select a shape tool (rectangle, ellipse, triangle, hexagon) or drawing tool (pencil, eraser).
2. Choose a color from the color palette
3. Draw on the canvas by clicking and dragging
4. Use the selection tool to select shapes
5. Delete selected shapes with the delete button
6. Save your work using the save button
7. Open previous works using the open button
8. Start a new drawing with the new button

---

![Project Preview](https://github.com/serdararici/paint-app-desktop/blob/main/images/project_images/PaintApp_2.JPG)


## Future Improvements

- [ ] Add more shape types
- [ ] Implement shape resizing
- [ ] Add a text tool
- [ ] Implement undo/redo functionality
- [ ] Add shape rotation
- [ ] Implement layer system


##  Installation

1. Clone this repository
2. Open the solution in Visual Studio
3. Build and run the application

---

This project was developed as a case study demonstrating the application of Object-Oriented Programming principles in .NET development.
